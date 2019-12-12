using System;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace BL
{
    public class ProcessScheduler
    {

        #region Variable Declarations

        static VideoCaptureDevice Device;
        private Label results = null;
        private string companyName;
        static private string imageName = "";

        int tries = 10000;
        int cnt = 100000;

        #endregion

        #region Constructor

        public ProcessScheduler(Label results)
        {
            this.results = results;
            companyName = File.ReadAllText(@"C:\Generating Attendance Reports - Files\companyName.txt", Encoding.UTF8);
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
            // Thread.Sleep(20000);
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
            bmp.Save(string.Format(@"C:\Generating Attendance Reports - Files\{0}", imageName), ImageFormat.Jpeg);

            bmp.Dispose();

        }

        #endregion

        #region Do I need these methods ?

        public async Task xxx()
        {
            //var startTimeSpan = TimeSpan.Zero;
            //var periodTimeSpan = TimeSpan.FromMinutes(0.25);

            //var timer = new System.Threading.Timer(async (e) =>
            //{
            //    await MainAsync();
            //}, null, startTimeSpan, periodTimeSpan);





            //var startTimeSpan = TimeSpan.Zero;
            //var periodTimeSpan = TimeSpan.FromMinutes(1);

            //var timer = new System.Threading.Timer((e) =>
            //{
            //    MainAsync();
            //}, null, startTimeSpan, periodTimeSpan);






            //while (true)
            //{
            //    MainAsync();

            //    Thread.Sleep(20000);
            //    Console.WriteLine("*** calling MyMethod *** cnt = " + cnt);
            //    cnt++;
            //}

        }

        public void CheckAsync()
        {
            Console.WriteLine("Counted to {0}.", CountRecursivelyAsync(10000).Result);
        }

        public async Task<int> CountRecursivelyAsync(int count)
        {
            if (count <= 0)
                return count;


            FilterInfoCollection WebcamColl;
            WebcamColl = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            Device = new VideoCaptureDevice(WebcamColl[0].MonikerString);
            Device.NewFrame += Device_NewFrame;
            Device.Start();
            Thread.Sleep(1000);
            Device.SignalToStop();

            ImageTesting imageTesting = new ImageTesting();
            await imageTesting.CropFacesAsync(results);


            var result = 1 + await CountRecursivelyAsync(count - 1);
            await Task.Yield();
            return result;
        }

        public async Task CheckAsync(TimeSpan recursiveTimer)
        {
            FilterInfoCollection WebcamColl;
            WebcamColl = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            Device = new VideoCaptureDevice(WebcamColl[0].MonikerString);
            Device.NewFrame += Device_NewFrame;
            Device.Start();
            Thread.Sleep(1000);
            Device.SignalToStop();

            ImageTesting imageTesting = new ImageTesting();
            imageTesting.CropFacesAsync(results);


            await Task.FromResult(5);
            CheckAsync(recursiveTimer);
        }

        public async Task GetDataWithRetry()
        {
            Exception lastexception = null;

            for (int trycount = 0; trycount < tries; trycount++)
                try
                {
                    await MainAsync();
                }
                catch (Exception Ex)
                {
                    lastexception = Ex;
                }

            throw lastexception;
        }

        public void yyy()
        {
            //MainAsync();

            Task.WaitAll(MainAsync());
            //Console.WriteLine("------------------------------------------|||||||||||||||||||||||||||||");

            // MainAsync().Wait();
            // //  task.Wait(); // Blocks current thread until GetFooAsync task completes
            // // For pedagogical use only: in general, don't do this!
            // //  var result = task.Result;
            //return yyy();
        }

        #endregion

    }
}
