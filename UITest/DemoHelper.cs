
using System.Threading;


namespace UITest
{
    internal static class DemoHelper
    {
        /////<summary>
        ///Brief delay to slow down browser interaction for the test
        /////</summary>
        public static void Pause(int secondsToPause = 3000)
        {
            Thread.Sleep(secondsToPause);
        }
    }
}

