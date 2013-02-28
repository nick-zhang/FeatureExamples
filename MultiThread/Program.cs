using System;
using System.Globalization;
using System.Threading;

namespace MultiThread
{
    internal  class Program
    {
        private const int INTERVAL = 200;

        private static void Main(string[] args)
        {
            var program = new Program();
            var nonParameterThread = new Thread(new ThreadStart(program.NonParameterRun));
            nonParameterThread.Start();
        }

        /// <summary>  
        /// 不带参数的启动方法  
        /// </summary>  
        private void NonParameterRun()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("系统当前时间毫秒值：" + DateTime.Now.Millisecond.ToString(CultureInfo.InvariantCulture));
                Thread.Sleep(INTERVAL); //让线程暂停  
            }
        }
    }
}