using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Core.Interfaces;
using Telephony.Models;
using Telephony.Models.Interfaces;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] websites = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ICallable phoneCall;

            foreach(var phoneNumber in phoneNumbers)
            {
                phoneCall = new StationaryPhone();
               
                try
                {
                    string result = phoneCall.Call(phoneNumber);
                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }

            IBrowsable phoneBrowse;

            foreach(var website in websites)
            {
                phoneBrowse = new Smartphone();

                try
                {
                    string result = phoneBrowse.Browse(website);
                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
//0882134215 0882134333 0899213421 0558123 3333123
//http://softuni.bg http://youtube.com http://www.g00gle.com
            }
        }
    }
}
