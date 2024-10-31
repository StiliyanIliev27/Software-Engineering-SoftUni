using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.BorderControl.Models.Interfaces
{
    public interface ISoldier
    {
        public string Id { get; }
        public string GetFakeId(string id);
    }
}
