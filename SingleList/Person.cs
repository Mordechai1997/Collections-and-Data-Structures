using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractCollections

{
    class Person
    {
        string name;

        public Person(string name)
        {
            this.name = name;
        }
        public override string ToString()
        {
            return this.name;

        }

    }
}
