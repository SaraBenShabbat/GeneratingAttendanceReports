using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using System.Globalization;
using Windows.Data.Json;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using DLL;

namespace BL
{
    public class ImageTesting : CloudServices
    {

        #region Variable Declarations

        const string subscriptionKey = "0e122e2fcd89494eb7fa75f392e695f8";
        private string companyName;
        const string uriBase = "https://westeurope.api.cognitive.microsoft.com";
        private Button takingPicBtn;
        private FaceClient faceClient = null;
        private DateTime currentDateTime;

        #endregion

        #region Constructors

        public ImageTesting()
        {
            companyName = File.ReadAllText(@"..\..\..\..\companyName.txt", Encoding.UTF8);
            imageName = companyName + ".jpg";
        }

        public ImageTesting(string path) : this()
        {
            CloneImage(path);
        }

        #endregion

        #region Methods & Functions

        #region Get the desired images

        public void CaptureImage(Form capturingImageFrm, PictureBox picture, Button takingPic, Label results)
        {
            takingPicBtn = takingPic;
            takingPicBtn.Enabled = false;

            // The function opens the form with the webcam and the user is abled to take a profile.
            CaptureImageFromWebcam(capturingImageFrm, picture, results);
        }

        private void CloneImage(string path)
        {
            // In order, not to pay attention to cases which user open file explorer & close it, without selecting an image.
            if (path != "")
                File.Copy(path, @"..\..\..\..\" + imageName, true);
        }

        #endregion

        #region Crop Faces From the picture has taken by the user & Get the current time from the server.

        public async Task CropFacesAsync(Button takingPicBtn, Button fileExplorerBtn, Button ImageTestingBtn, Label results)
        {
            results.Text = "";

            // Some opearations can't be done at the same time; as the system doesn't support asynchronous.
            takingPicBtn.Enabled = false;
            fileExplorerBtn.Enabled = false;
            ImageTestingBtn.Enabled = false;

            // Get DateTime from the server.
            currentDateTime = GetDateTimeFromServer();

            // In order to prevet using server caching, and not to refresh the URL with the new image for testing.
            string guid = "?cache=" + Guid.NewGuid().ToString();

            // I have to upload the image to Azure in order to have an "http" URL & to be able to get the 
            // coordinates of all the faces.
            UploadImageToStorage(imageName);

            faceClient = new FaceClient(
             new ApiKeyServiceClientCredentials(subscriptionKey),
             new DelegatingHandler[] { });
            faceClient.Endpoint = uriBase;

            // Get coordinates of all the faces in the image.
            IList<DetectedFace> faces = await faceClient.Face.DetectWithUrlAsync("https://sarabenshabbatproject.blob.core.windows.net/newcontainer/" + imageName + guid, true, false);

            // Crop all the faces in the image.
            Image img = Image.FromFile(@"..\..\..\..\" + imageName);

            // If, at least - one face detected in the img.
            if (faces.Count != 0)

                //{
                // Go over all the detected coordinates, and create new image(s) according to these.
                //Image croppedFaceImg;
                //FaceRectangle sample;
                //Rectangle cropArea;
                //Bitmap bmpImage = null;
                //int index = 0;
                //
                //foreach (var face in faces)
                //{
                //    sample = face.FaceRectangle;
                //    cropArea = new Rectangle(sample.Left, sample.Top, sample.Width, sample.Height);
                //    bmpImage = new Bitmap(img);
                //
                //    croppedFaceImg = bmpImage.Clone(cropArea, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                //    croppedFaceImg.Save(@"..\..\..\..\" + imageName.Substring(0, imageName.Length - 4) + "_" + (index++) + ".jpg");
                //
                //    bmpImage.Dispose() - 1111111111111111111111111111111111111111111111111111111111111111111;
                //}

                // Go over all the detected faces: Try to find similar from the company employees & if ther's need, wrtie to DB.
                foreach (var face in faces)
                    FindSimilar(face.FaceId.ToString(), results);
            //}
            else
                results.Text += "No faces for testing, have been detected";

            // Dispose the server client
            faceClient.HttpClient.Dispose();
            faceClient.Dispose();

            // Release all resorces used by this image.
            img.Dispose();

            // Delete all the image(s) used in this method, from local PC.
            DeleteImages();

            // The user can do whatever he wants.
            takingPicBtn.Enabled = true;
            fileExplorerBtn.Enabled = true;
        }

        private DateTime GetDateTimeFromServer()
        {
            // The function is intended to provide a correct DateTime, even for the PC's - their clocks are not tuned correctly.
            // That's why the DateTime is taken from the server.
            using (WebResponse response = WebRequest.Create("http://www.microsoft.com").GetResponse())
                return DateTime.ParseExact(response.Headers["date"], "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                    CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.AssumeUniversal);
        }

        #endregion

        #region Find Similiar face from the face list of the current company

        private async void FindSimilar(string faceId, Label res)
        {
            var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            var uri = "https://westeurope.api.cognitive.microsoft.com/face/v1.0/findsimilars?";

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{'faceId':'" + faceId + "','FaceListId':'" + companyName + "'}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);

                string responseBodyAsText;
                responseBodyAsText = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode == false)
                {
                    res.Text += "An error occured; Please try again.";
                    return;
                }

                // If the ICollection (of matched faces) contains any face.
                if (responseBodyAsText != "[]")
                {
                    string currentPersistedFaceId;
                    double currentConfidence;

                    // Format the response & extract the persistedFaceId and the confidence.
                    FormatResponse(responseBodyAsText, out currentPersistedFaceId, out currentConfidence);

                    res.Text += "Highest currentPersistedFaceId = " + currentPersistedFaceId + ";   Highest confidence = " + currentConfidence.ToString();

                    // If there're likely chances for right identification; write this activity in DB.
                    if (currentConfidence >= 0.56)
                        WriteToDB(currentPersistedFaceId);
                }
                else
                    res.Text += "No faces were found as matched.";
            }

            res.Text += "\n----------------\n";
        }

        private void FormatResponse(string responseBodyAsText, out string currentPersistedFaceId, out double currentConfidence)
        {
            string[] result = responseBodyAsText.Split('}');
            JsonObject json;

            json = JsonObject.Parse(result[0].Substring(1) + "}");

            // Get the persistedFaceId & confidence
            // - of the face which detected as similar, to the current face detected from the image.
            currentPersistedFaceId = json["persistedFaceId"].ToString();
            currentConfidence = Convert.ToDouble((json["confidence"].ToString()));
        }

        private void WriteToDB(string persistedFaceId)
        {
            // Pay attention! activityStatus = true => means entry, activityStatus = false => means exist.
            int employeeNumber;
            Boolean activityStatus;

            using (var DB = new FinalProjectEntities())
            {
                // Find the number of the employee with the current persistedFaceId
                employeeNumber = DB.uploadedProfiles.Where(profile => profile.uploadedProfileNumber.Equals(persistedFaceId.Substring(1, persistedFaceId.Length - 2)))
                    .First().employeeNumber;

                List<activity> activities = DB.activities.Where(act => act.employeeNumber == employeeNumber).ToList();
                // If it's an employee who already has activity\ies in the system.
                if (activities.Count != 0)
                {
                    // Get the last status found of the current employee & write in DB with the complementary one.
                    activityStatus = activities.Last().activityStatus;

                    if (activityStatus == true)
                        activityStatus = false;
                    else
                        activityStatus = true;
                }
                else
                    // If the employee is new, the current activity(- which is the first one.)  is entry.
                    activityStatus = true;

                DB.activities.Add(new activity()
                {
                    employeeNumber = employeeNumber,
                    activityDate = currentDateTime,
                    activityStatus = activityStatus
                });

                DB.SaveChanges();
            }
        }

        #endregion

        #endregion

    }
}