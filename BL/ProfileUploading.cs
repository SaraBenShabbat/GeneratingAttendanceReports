using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Windows.Forms;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using Windows.Data.Json;
using DLL;

namespace BL
{
    public class ProfileUploading : CloudServices
    {

        #region Variable Decalarations

        private const string subscriptionKey = "0e122e2fcd89494eb7fa75f392e695f8";
        private string companyName;
        public static employee currentEmployee;
        private string persistedFaceId;
        private Button takingProfileBtn;

        #endregion

        #region Constructor

        public ProfileUploading()
        {
            companyName = File.ReadAllText(@"C:\Generating Attendance Reports - Files\companyName.txt", Encoding.UTF8);
        }

        #endregion

        #region Methods & Functions

        #region Validate Current Employee

        public bool IsExist(String employeeId)
        {
            // First of all, the validation tests.
            if (employeeId.Length < 6 || employeeId.Length > 9 || Regex.IsMatch(employeeId, @"^[0-9]+$") == false)
                return false;

            // If the idNumber passed the validation tests, check if it exists in the DB.
            using (var DB = new FinalProjectEntities())
            {
                currentEmployee = DB.employees.Where(x => x.employeeId == employeeId).FirstOrDefault();
                if (currentEmployee is employee)
                    return true;
                return false;
            }
        }

        #endregion

        #region Capturing Image

        public void CaptureImage(Form capturingImageFrm, PictureBox picture, Button takingProfile, Label results)
        {
            takingProfileBtn = takingProfile;
            takingProfileBtn.Enabled = false;
            imageName = ProfileUploading.currentEmployee.employeeId + ProfileUploading.currentEmployee.numUploadedProfiles + ".jpg";

            // The function opens the form with the webcam and the user is abled to take a profile.
            CaptureImageFromWebcam(capturingImageFrm, picture, results);
        }

        #endregion

        #region Saving Image

        public async void SaveImage(Button savingImgBtn, Button confirmIdBtn)
        {
            // As long as the uploading is ongoing, the user can't take a new profile and/or choose a new employee.
            takingProfileBtn.Enabled = false;
            confirmIdBtn.Enabled = false;

            // Since the saving begins, it's not possible to user to click this button; as long as he doesn't take a new image.
            savingImgBtn.Enabled = false;

            // The function upload the image to Azure blob storage, in order to get an 'http' url for the image and to be able to 
            //upload the image to thr compnay's face list.
            UploadImageToStorage(imageName);

            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            // queryString["detectionModel"] = "detection_02";


            // Request parameters
            var uri = "https://westeurope.api.cognitive.microsoft.com/face/v1.0/facelists/" + companyName + "/persistedFaces?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{'url':'https://sarabenshabbatproject.blob.core.windows.net/newcontainer/" + imageName + "'}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);

                if (response.StatusCode.ToString() == "OK")
                {
                    // Converting the response to text, in order to extract the 'persistedFaceId' of the new added face.
                    string responseBodyAsText;
                    responseBodyAsText = await response.Content.ReadAsStringAsync();
                    // Extract from the Json object - the value of the new persistedFaceId.
                    JsonObject root = JsonValue.Parse(responseBodyAsText).GetObject();
                    persistedFaceId = root["persistedFaceId"].GetString();

                    // Show in the form the 'persistedFaceId' of the new added face on called 'showResults' label.
                    showResults.Text = "Successfully uploaded\n persistedFaceId = " + persistedFaceId;

                    // Record the new persisted Id linked to the current employee number.
                    SaveNewPersistedFaceId();
                }
                else
                    showResults.Text = "Sorry, we ran into a problem; Try again to take your profile and upload the image.";
            }

            DeleteBlob(imageName);

            DeleteImages();

            // As the uploading got finished - the user can take a new profile and/or choose a new employee.
            this.takingProfileBtn.Enabled = true;
            confirmIdBtn.Enabled = true;
        }

        private void SaveNewPersistedFaceId()
        {
            using (var DB = new FinalProjectEntities())
            {
                try
                {
                    // Store the information about the uploading the new profile to face list, after this record insertion - 
                    // a trigger will be triggered and increase the 'numUploadedFiles' field of the the current employee.
                    DB.uploadedProfiles.Add(new uploadedProfile()
                    {
                        uploadedProfileNumber = persistedFaceId,
                        employeeNumber = currentEmployee.employeeNumber
                    });

                    // Save the change of the insertion, in the external database.
                    DB.SaveChanges();
                }
                catch (DbUpdateException dbException)
                {
                    showResults.Text = "Sorry, we ran into a problem; Try again to take your profile and upload the image.";
                    throw new DbEntityValidationException();
                }
            }
        }

        #endregion

        #endregion

        #region I have to delete this function, after using it for testing the project;

        public async System.Threading.Tasks.Task xAsync(string imgName, Label l)
        {
            UploadImageToStorage(imgName);

            var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            // Request parameters
            var uri = "https://westeurope.api.cognitive.microsoft.com/face/v1.0/facelists/" + companyName + "/persistedFaces";

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{'url':'https://sarabenshabbatproject.blob.core.windows.net/newcontainer/" + imgName + "'}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);

                // Converting the response to text, in order to extract the 'persistedFaceId' of the new added face
                string responseBodyAsText;
                responseBodyAsText = await response.Content.ReadAsStringAsync();
                responseBodyAsText = responseBodyAsText.Substring(20, responseBodyAsText.Length - 22);
                persistedFaceId = responseBodyAsText;

                // Show in the form the 'persistedFaceId' of the new added face on called 'showResults' label
                l.Text = "Successfully uploaded\n persistedFaceId = " + persistedFaceId;
            }
        }

        #endregion
    }
}