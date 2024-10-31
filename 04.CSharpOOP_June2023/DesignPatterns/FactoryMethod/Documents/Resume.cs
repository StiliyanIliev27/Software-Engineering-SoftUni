using FactoryMethod.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Documents
{
    public class Resume : Document
    {
        public override void CreatePages()
        {
            Pages.Add(new EducationPage());
            Pages.Add(new SkillsPage());
            Pages.Add(new ExperiencePage());
        }
    }
}
