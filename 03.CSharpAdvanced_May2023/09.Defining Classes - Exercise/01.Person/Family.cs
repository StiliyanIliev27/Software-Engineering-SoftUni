using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> peopleList;
       
        public Family()
        {
            peopleList = new List<Person>();
        }
       
        public List<Person> PeopleList { get { return peopleList; } set { peopleList = value; } }       
      
        public void AddMember(Person member)
        {
            peopleList.Add(member);
        }       
        public Person GetOldestMember()
        {
            return PeopleList.MaxBy(p => p.Age);
        }
    }
}
