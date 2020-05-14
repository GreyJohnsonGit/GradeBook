using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class NamedObject
    {
        public NamedObject(string _name)
        {
            Name = _name;
        }
        public string Name
        {
            get;
            set;
        }
    }
}
