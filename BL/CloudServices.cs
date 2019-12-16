using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace BL
{
    public abstract class CloudServices
    {

        #region Variable Declarations

        private PictureBox pictureBox;
        private VideoCapture capture;
        private Mat frame;
        private Thread camera;
        private Bitmap snapshot;
        protected Label showResults;
        private Form capturingImageFrm;
        protected Button captureBtn;
        protected string imageName = "";

        #endregion

        #region Methods & Functions

        #region Capturing Image 

        protected void CaptureImageFromWebcam(Form capturingImage, PictureBox picture, Label results)
        {
            capturingImageFrm = capturingImage;
            capturingImageFrm.Show();
            pictureBox = picture;
            showResults = results;
            showResults.Text = "";

            // Turn on the camera as a thread, out of the main program.
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }

        private void CaptureCameraCallback()
        {
            frame = new Mat();
            capture = new VideoCapture(0);

            capture.Open(0);

            while (capture.IsOpened())
            {
                capture.Read(frame);
                // image = new Bitmap(frame.Width, frame.Height, PixelFormat.Format16bppRgb555);
                if (pictureBox.Image != null)
                {
                    pictureBox.Image.Dispose();
                }
                pictureBox.Image = BitmapConverter.ToBitmap(frame);
            }
        }

        public void Capture(bool isTesting, Button takingProfileBtn, Button capturingBtn, Button nextStepBtn)
        {
            capturingBtn.Enabled = false;
            snapshot = new Bitmap(pictureBox.Image);

            capture.Release();
            capture.Dispose();
            camera.Abort();

            // The function manages the existance from this form.
            ManageExist(takingProfileBtn);

            capturingImageFrm.Close();
            if (isTesting == true)
                SaveTestingImage();
            else
                SaveProfileImage();
            nextStepBtn.Enabled = true;
        }

        public void ManageExist(Button takingProfileBtn)
        {           
            takingProfileBtn.Enabled = true;
        }

        #endregion

        #region Saving Image

        private void SaveProfileImage()
        {
            snapshot.Save(string.Format(@"C:\Generating Attendance Reports - Files\{0}.jpg",
 ProfileUploading.currentEmployee.employeeId + ProfileUploading.currentEmployee.numUploadedProfiles), ImageFormat.Jpeg);

            File.SetAttributes(string.Format(@"C:\Generating Attendance Reports - Files\{0}.jpg",
 ProfileUploading.currentEmployee.employeeId + ProfileUploading.currentEmployee.numUploadedProfiles), FileAttributes.Hidden);
        }

        private void SaveTestingImage()
        {
            snapshot.Save(string.Format(@"C:\Generating Attendance Reports - Files\" + imageName), ImageFormat.Jpeg);

            File.SetAttributes(string.Format(@"C:\Generating Attendance Reports - Files\" + imageName), FileAttributes.Hidden);
        }

        #endregion

        #region Uploading Image to Azure & Store it as a blob.

        protected void UploadImageToStorage(string imageName)
        {
            string storageConnection = CloudConfigurationManager.GetSetting("BlobStorageConnectionString");
            CloudStorageAccount storageAccount = new CloudStorageAccount(
            new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials("sarabenshabbatproject",
            "I9T7WkFCTuZfp9ryMkzg8cvHkAO437Qxx/Kz6HXUbmtYT6j/UUIZ4OprCnDJ4VOuImArGKW6EaDitGSxS+JmKA=="), true);

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("newcontainer");
            container.CreateIfNotExists(BlobContainerPublicAccessType.Container);

            var blockBlob = container.GetBlockBlobReference(imageName);
            using (var fileStream = File.OpenRead(@"C:\Generating Attendance Reports - Files\" + imageName))
            {
                blockBlob.UploadFromStream(fileStream);
                fileStream.Close();
            }
        }

        protected void DeleteBlob(string imageName)
        {
            string storageConnection = CloudConfigurationManager.GetSetting("BlobStorageConnectionString");
            CloudStorageAccount storageAccount = new CloudStorageAccount(
            new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials("sarabenshabbatproject",
            "I9T7WkFCTuZfp9ryMkzg8cvHkAO437Qxx/Kz6HXUbmtYT6j/UUIZ4OprCnDJ4VOuImArGKW6EaDitGSxS+JmKA=="), true);

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("newcontainer");
            container.CreateIfNotExists(BlobContainerPublicAccessType.Container);

            var blockBlob = container.GetBlockBlobReference(imageName);
            blockBlob.DeleteIfExists();
            //using (var fileStream = File.OpenRead(@"..\..\..\..\" + imageName))
            //{
            //    blockBlob.DeleteIfExists();
            //    fileStream.Close();
            //}
        }

        protected void DeleteImages()
        {
            string fixedImgName = imageName.Substring(0, 3);

            String[] fileNames = Directory.GetFiles(@"C:\Generating Attendance Reports - Files\", fixedImgName + "*.jpg");
            foreach (String fileName in fileNames)
                File.Delete(fileName);

        }

        #endregion

        #endregion

    }
}
