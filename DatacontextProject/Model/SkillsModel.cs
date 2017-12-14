using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatacontextProject.Model
{
    public class SkillsModel
    {
        private double _amountOfSkills;

        public double amountOfSkills
        {
            get { return _amountOfSkills; }
            set { _amountOfSkills = value; }
        }
    }
}
