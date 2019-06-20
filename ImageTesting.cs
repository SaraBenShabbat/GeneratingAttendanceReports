using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Media.Capture;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.Graphics.Imaging;
using Windows.Foundation;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;

namespace BL
{
    public class ImageTesting
    {

        public void CreateAndTestImage(Label ex)
        {
            ////1.////
            ////בפונקציה זו - אלי להדביק את הקוד של צילום באמצעות מצלמת המחשב ולשמור את התמונה במחשב ולראות שהקוד אכן עובד
            ////Write here the code from github, which I work on it in the college - for openning the camera & taking a picture////
            ////CaptureImage();////
            ////2.////
            ////כעת עלי להעלות את התמונה לבלוב סטורג של אזור
            ////==> כעת אני תקועה כי בשביל לכתוב הקוד הזה צריך להוריד ספריה ולא ניתן להורידה לפרויקט זה כי הוא גרסה נמוכה ולכן עלי 
            ////לעדכן את הפרויקט - על פי הכתוב בגיט אב
            ////רציתי להוריד את הספריה בשביל Extensions.Configuration - ////
            ////UploadImageToStorage().Wait();////
            ////when the nethods works bs"d - put out the label ex;////
            ////it doesnt have to be sent & gotten.( & the next 1 line.)////
            //    var client = new HttpClient();
            //    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "0e122e2fcd89494eb7fa75f392e695f8");
            //    var uri = "https://management.core.windows.net/0e122e2fcd89494eb7fa75f392e695f8/services/ServiceBus/CheckNamespaceAvailability/?namespace=";
            //    HttpResponseMessage response;
            //    byte[] byteData = Encoding.UTF8.GetBytes("{'name':'" + companyName + "'}");
            //    using (var content = new ByteArrayContent(byteData))
            //    {
            //        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //        response = await client.PutAsync(uri, content);
            //        createFaceListBtn.Text = response.StatusCode.ToString();
            //    }
            ex.Text = "success";
            ////3.////
            ////כעת עלי לבצע קריאה לאזור לפונקציה של זיהוי פרצופים בתמונה - ניתוב התמונה יהיה מהבלוב סטורג של  החשבון שלי על התמונה 
            ////שהעחיתי בפונקציה לפני
            ////DetectFaces(this.testImageBtn);////
            ////4.
            ////לעבוד עם הגיסונים החוזרים נהקריאה לאזור
            ////לבדוק האם הפונקציה של זיהוי מרשימה יכולה לקבל תמונה עם קואורדינטות או תמונה שלימה עם פרצוף בודד
            ////זה חשוב בשביל לדעת - האם יש ליצור מהקואורדינטות תמונות ממש או שניתן לשלוח תמונה עם קואורדינטות וזהו
        }

        private async void CaptureImage()
        {
            //declarations of the photo object
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);
            //Look if the user cancelled; else - declarations of the phote storage
            StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);
            if (photo == null)
            {
                // User cancelled photo capture
                return;
            }
            StorageFolder destinationFolder =
       await ApplicationData.Current.LocalFolder.CreateFolderAsync("TestPhotoFolder",
           CreationCollisionOption.OpenIfExists);
            //capturing the screen
            await photo.CopyAsync(destinationFolder, "TestPhoto.jpg", NameCollisionOption.ReplaceExisting);
            await photo.DeleteAsync();
            IRandomAccessStream stream = await photo.OpenAsync(FileAccessMode.Read);
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
            SoftwareBitmap softwareBitmap = await decoder.GetSoftwareBitmapAsync();
            SoftwareBitmap softwareBitmapBGR8 = SoftwareBitmap.Convert(softwareBitmap,
        BitmapPixelFormat.Bgra8,
        BitmapAlphaMode.Premultiplied);
            //convert it to bit map, in order to be able using it afterward - in the software
            SoftwareBitmapSource bitmapSource = new SoftwareBitmapSource();
            await bitmapSource.SetBitmapAsync(softwareBitmapBGR8);

        }

        private static async Task UploadImageToStorage()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(
             new StorageCredentials("sarabenshabbatproject",
                "I9T7WkFCTuZfp9ryMkzg8cvHkAO437Qxx/Kz6HXUbmtYT6j/UUIZ4OprCnDJ4VOuImArGKW6EaDitGSxS+JmKA=="), true);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("sarabenshabbatimages");
            await container.CreateIfNotExistsAsync();
            ////CloudStorageAccount storageAccount = new CloudStorageAccount(////
            ////new StorageCredentials("experienceproject",////
            ////"E6abSzrBkw6Kb++JNpE4o7scDrB2Mao6PAw231lLMvoGrKdLv1TlTUo24u3r7SIDLV4bvbrFC5I+Pv2nq0lezw=="), true);////
            ////CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();////
            ////CloudBlobContainer container = blobClient.GetContainerReference("sarabenshabbat");////
            ////CloudBlockBlob blockBlob = container.GetBlockBlobReference("currentImage");////

            ////using (var fileStream = File.OpenRead(@"..\..\..\..\currentImage.jpg"))////
            ////CloudBlockBlob blockBlob = container.GetBlockBlobReference("currentImage.jpg");////

            CloudBlockBlob blockBlob = container.GetBlockBlobReference("a.txt");

            using (var fileStream = File.OpenRead(@"..\..\..\..\a.txt"))
            {
                await blockBlob.UploadFromStreamAsync(fileStream);
            }
        }

        private static async void DetectFaces(Button TestImageBtn)
        {
            ////The function has to run, bs"d, well; I have only to check about local file for image.////
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "0e122e2fcd89494eb7fa75f392e695f8");
            var uri = "https://westeurope.api.cognitive.microsoft.com/face/v1.0/detect?";
            HttpResponseMessage response;
            byte[] byteData = Encoding.UTF8.GetBytes("{'url': 'https://docs.microsoft.com/learn/data-ai-cert/identify-faces-with-computer-vision/media/clo19_ubisoft_azure_068.png'}");
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
                TestImageBtn.Text = response.StatusCode.ToString();
            }
        }

    }
}


