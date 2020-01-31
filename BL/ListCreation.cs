using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BL
{
    public class ListCreation
    {

        #region Variable Declarations

        //when user enters the company name while installing the software - keep it in app.config file
        private const string subscriptionKey = "0e122e2fcd89494eb7fa75f392e695f8";
        private string companyName = "";

        #endregion

        #region Methods & Functions

        public async void CreateFaceListAsync(TextBox faceListTxtBox, Label result)
        {
            result.Text = "";
            companyName = faceListTxtBox.Text.Trim();

            if (IsValid(companyName) == false)
                result.Text = "The company name isn't valid!\nValid character is letter in lower case or digit or '-' or '_', maximum length is 64.";
            else
            {
                string response = await Creation();
                if (response != "OK")
                    result.Text = "Sorry, we ran into a problem; Try create the list again.";
                else
                {
                    WriteCompanyNameToFile();
                    result.Text = "The list has created well.";
                }
            }
        }

        private Boolean IsValid(String listName)
        {
            if (listName.Length > 64 || Regex.IsMatch(listName, @"^[a-z0-9_-]+$") == false)
                return false;
            return true;
        }

        private async Task<string> Creation()
        {
            // Do it by put a text box to user & the name of the person group is what's the user enter; Doing also validation 
            // in order that the status cose won't be "Conflict"
            var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            var uri = "https://westeurope.api.cognitive.microsoft.com/face/v1.0/facelists/" + companyName;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{'name':'" + companyName + "'}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PutAsync(uri, content);
                return response.StatusCode.ToString();
            }
        }

        private void WriteCompanyNameToFile()
        {
            string path = @"C:\Generating Attendance Reports - Files\\companyName.txt";
            FileStream fs = null;
            try
            {
                File.WriteAllText(path, String.Empty);

                fs = new FileStream(path, FileMode.OpenOrCreate);
                using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8, 512))
                {
                    writer.Write(companyName);
                }
            }
            finally
            {
                if (fs != null)
                    fs.Dispose();
            }

            File.SetAttributes(path, FileAttributes.Hidden);
        }

        #endregion

        #region I need these methods ?

        public async void MakeRequest(Button a)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            var uri = "https://westeurope.api.cognitive.microsoft.com/face/v1.0/facelists/" + companyName;

            var response = await client.DeleteAsync(uri);
            a.Text = response.StatusCode.ToString();
        }

        public async Task FuncReturnsListOfAllMyFaceLists_DoIhaveToUseItAsync()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "{subscription key}");

            // Request parameters
            queryString["returnRecognitionModel"] = "false";
            var uri = "https://westeurope.api.cognitive.microsoft.com/face/v1.0/facelists?" + queryString;

            var response = await client.GetAsync(uri);

            Console.WriteLine(response.ToString());
        }

        private async Task FuncReturnsAllPersistedFaceIdsOfFaceList_DoIhaveToUseItAsync()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "{subscription key}");

            // Request parameters
            queryString["returnRecognitionModel"] = "false";
            var uri = "https://westeurope.api.cognitive.microsoft.com/face/v1.0/facelists/{faceListId}?" + queryString;

            var response = await client.GetAsync(uri);
        }

        #endregion

    }
}
