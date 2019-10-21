using System;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VyBillettWebApp.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            DateTime now = DateTime.Now;

            string[] nowString = {
                now.Day.ToString(),
                now.Month.ToString(),
                now.Year.ToString(),
                now.Hour.ToString(),
                now.Minute.ToString(),
                now.Second.ToString()
            };


            string dateFormatString = "dd/MM/yyyy HH:mm:ss";

            string nowToString = now.ToString();

            Console.WriteLine("Time: " + nowToString);


            Thread.Sleep(1000);

            DateTime later = DateTime.ParseExact(nowToString, dateFormatString, null);

            string laterToString = later.ToString();

            Console.WriteLine("Time later: " + laterToString);

            

        }
    }
}
