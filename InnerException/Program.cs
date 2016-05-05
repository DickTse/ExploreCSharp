using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnerException
{
    class Program
    {
        private static void writeInnerExceptionToConsole(Exception ex)
        {
            if (ex.InnerException != null)
            {
                Console.WriteLine("Inner-exception message:" + ex.InnerException.Message);
                Console.WriteLine("Inner-exception Stack Trace:");
                Console.WriteLine(ex.InnerException.StackTrace);
                writeInnerExceptionToConsole(ex.InnerException);
            }
        }

        private static void innerMethodWithException2()
        {
            throw new Exception("Exception thrown in innerMethodWithException2()");
        }

        private static void innerMethodWithException()
        {
            try
            {
                innerMethodWithException2();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception thrown in innerMethodWithException()", ex);
            }
        }

        private static void methodWithException()
        {
            try
            {
                innerMethodWithException();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception thrown in methodWithException()", ex);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Calling methodWithException()...");
            try
            {
                methodWithException();
                Console.WriteLine("Method is executed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception is encounterd when calling methodWithException().");
                Console.WriteLine("Exception message:" + ex.Message);
                Console.WriteLine("Stack Trace:");
                Console.WriteLine(ex.StackTrace);
                writeInnerExceptionToConsole(ex);
            }
            Console.ReadKey();
        }
    }
}
