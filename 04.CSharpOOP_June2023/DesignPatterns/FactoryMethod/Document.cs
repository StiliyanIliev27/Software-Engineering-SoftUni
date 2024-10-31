using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public abstract class Document
    {
        private List<Page> pages = new List<Page>();
        public Document()
        {
            CreatePages();
        }
        public List<Page> Pages { get {  return pages; } }
        public abstract void CreatePages();
    }
}


