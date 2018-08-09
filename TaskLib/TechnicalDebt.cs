using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLib
{
    class TechnicalDebt : Task
    {
        public TechnicalDebt(string name, string complexity) : base(name, complexity)
        {
            Prioriti = (float)0.5;
        }

        public override float Prioriti
        {
            get
            {
                return _priority;
            }
            set
            {
                _priority = (float)0.5;
            }
        }
    }
}
