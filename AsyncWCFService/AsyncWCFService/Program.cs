using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using AsyncWCFService.AdditionService;

namespace AsyncWCFService
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var additionServiceClient = new AdditionServiceClient();

            Console.WriteLine("Starting");
            while (true)
            {
                string value = Console.ReadLine();
                var serviceFuntion = Observable.FromAsyncPattern<List<decimal>, decimal>(additionServiceClient.BeginAddNumbers,
                                                                        additionServiceClient.EndAddNumbers);
                serviceFuntion(value.ConvertToDecimalList().ToList())
                      .Subscribe(x => Console.WriteLine("Sum of {0} is {1}", value, x));
            }
        }
    }
}