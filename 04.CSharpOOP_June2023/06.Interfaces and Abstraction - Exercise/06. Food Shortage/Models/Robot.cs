using P04.BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.BorderControl.Models
{
    public class Robot : ISoldier
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }
        public string Model { get; private set; }
        public string Id { get; private set; }

        public string GetFakeId(string id)
        {
            if (IsFakeId(id))
            {
                return Id;
            }
            return "";
        }
        private bool IsFakeId(string id)
        {
            int cnt = 0;
            string result = string.Empty;

            for (int i = Id.Length - 1; i >= 0; i--)
            {
                result += Id[i];
                
                cnt++;
                
                if(cnt == id.Length)
                {
                    break;
                }
            }

            string reversedResult = string.Empty;
            
            for (int i = result.Length - 1; i >= 0; i--)
            {
                reversedResult += result[i];
            }

            if (reversedResult == id)
            {
                return true;
            }
            return false;
        }
    }
}
