using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DetectingAzure
{
    class Program
    {
        static void Main(string[] args)
        {
            userPicture = capture.QueryFrame().ToImage<Gray, byte>();
        }
    }
}
