using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLib
{
    abstract partial class Task
    {
        protected string _name;
        protected float _complexity;
        protected float _priority;
        protected float _iterationCounter;
        protected Random _random = new Random();
    }
}
