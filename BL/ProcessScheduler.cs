using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;
using System.Text;
using System.Threading;
using System;
using System.Threading.Tasks;

namespace BL
{
    public class ProcessScheduler
    {

        #region Variable Declarations

        static VideoCaptureDevice Device;
        private Label results = null;
        private string companyName;
        static private string imageName = "";

        #endregion

        #region Constructor

        public ProcessScheduler(Label results)
        {
            this.results = results;
            companyName = File.ReadAllText(@"..\..\..\..\companyName.txt", Encoding.UTF8);
            imageName = companyName + ".jpg";
        }

        #endregion

        #region Methods & Functions


        public async Task MainAsync()
        {
            FilterInfoCollection WebcamColl;
            WebcamColl = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            Device = new VideoCaptureDevice(WebcamColl[0].MonikerString);
            Device.NewFrame += Device_NewFrame;
            Device.Start();
            Thread.Sleep(1000);
            Device.SignalToStop();

            ImageTesting imageTesting = new ImageTesting();
            await imageTesting.CropFacesAsync(results);
            // Thread.Sleep(25000);
            //  await MainAsync();
            await MainAsync();
        }

        static void Device_NewFrame(object sender, NewFrameEventArgs e)
        {
            Bitmap bmp = new Bitmap(960 * 2, 480 * 2);
            bmp = (Bitmap)e.Frame.Clone();
            bmp.Save(string.Format(@"..\..\..\..\{0}", imageName), ImageFormat.Jpeg);

            bmp.Dispose();

        }

        #endregion

    }
}
