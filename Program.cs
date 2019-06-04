using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
//using from as the second, instead of "unionmetadata" - select "Referances"
using Windows.Media.Capture;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.Graphics.Imaging;

namespace TakingPicture
{
    class Program
    {
        static void Main(string[] args)
        {
            CameraCaptureUI();
            Console.WriteLine("111");
        }
        static async void CameraCaptureUI()
        {
            //אם אני מבינה נכון, נוצרת תיקית תמונות בתיקיה הנוכחית ושם נשמרת התמונה הנוכחית
            //אם ישנה תמונה כבר, אזי התמונה הנוכחית מחליפה את הקודמת

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
    }
}
