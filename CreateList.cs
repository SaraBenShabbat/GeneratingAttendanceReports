using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BL
{
    public class CreateList
    {
        //when user enters the company name while installing the software - keep it in app.config file
        const string companyName = "ramot_college";

        public async void CreateFaceList(Button createFaceListBtn)
        {
            // Do it by put a text box to user & the name of the person group is what's the user enter; Doing also validation 
            // in order that the status cose won't be "Conflict"
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "0e122e2fcd89494eb7fa75f392e695f8");
            var uri = "https://westeurope.api.cognitive.microsoft.com/face/v1.0/facelists/" + companyName;
            HttpResponseMessage response;
            byte[] byteData = Encoding.UTF8.GetBytes("{'name':'" + companyName + "'}");
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PutAsync(uri, content);
                createFaceListBtn.Text = response.StatusCode.ToString();
            }
        }

        private Boolean IsValid(String listName)
        {
            return true;
        }

    }
}
