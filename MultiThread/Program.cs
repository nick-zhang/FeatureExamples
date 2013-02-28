using System;
using System.Globalization;
using System.Threading;

namespace MultiThread
{
    internal class Program
    {
        private const int INTERVAL = 200;

        private static void Main(string[] args)
        {
            var program = new Program();
            var nonParameterThread = new Thread(program.NonParameterRun);
            nonParameterThread.Start();

            var parameterizedThread1 = new Thread(program.ParameterRun) { Name = "Thread A" };
            parameterizedThread1.Start(300);

            var parameterizedThread2 = new Thread(program.ParameterRun) {Name = "Thread B:"};
            parameterizedThread2.Start(150);

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

        private void ParameterRun(object ms)
        {
            int j;
            int.TryParse(ms.ToString(), out j); //这里采用了TryParse方法，避免不能转换时出现异常  
            int r;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name + "系统当前时间毫秒值：" +
                                  DateTime.Now.Millisecond.ToString(CultureInfo.InvariantCulture));
                Thread.Sleep(j); //让线程暂停  
            }
        }
    }
}