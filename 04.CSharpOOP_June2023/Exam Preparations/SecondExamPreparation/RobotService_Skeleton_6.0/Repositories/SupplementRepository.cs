using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private readonly List<ISupplement> supplements;
        public SupplementRepository()
        {
            supplements = new List<ISupplement>();
        }

        public void AddNew(ISupplement model)
        {
            supplements.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            return Models().FirstOrDefault(s => s.InterfaceStandard == interfaceStandard);
        }
       
        public IReadOnlyCollection<ISupplement> Models() => supplements.AsReadOnly();
      
        public bool RemoveByName(string typeName)
        {
            ISupplement supplementToRemove = Models().FirstOrDefault(s => s.GetType().Name == typeName);

            if(supplementToRemove != null)
            {
                supplements.Remove(supplementToRemove);
                return true;
            }
           
            return false;
        }
    }
}
