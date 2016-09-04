using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Consumer.ServiceReference1.ServiceSoapClient webService = new Consumer.ServiceReference1.ServiceSoapClient();

            Console.WriteLine("Fibonnacci(10) = " + webService.Fibonacci(10));
            Console.ReadKey();
        }
    }
}
