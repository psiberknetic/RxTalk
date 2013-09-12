using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Threading.Tasks;
using AsynchWCFUsingTask.AdditionService;

namespace AsynchWCFUsingTask
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var service = new AdditionServiceClient();

            Console.WriteLine("Starting");
            while (true)
            {
                string value = Console.ReadLine();
                service.AddNumbersAsync(value.ConvertToDecimalList().ToList()).ToObservable()
                       .Subscribe(x => Console.WriteLine(string.Format("Sum of {0} is {1}", value, x)));
            }
        }

        
    }
}