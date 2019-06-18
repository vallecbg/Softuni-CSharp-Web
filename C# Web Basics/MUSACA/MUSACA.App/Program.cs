using SIS.MvcFramework;
using System;

namespace MUSACA.App
{
    public class Program
    {
        public static void Main()
        {
            WebHost.Start(new Startup());
        }
    }
}
