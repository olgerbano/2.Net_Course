using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer
{
    class Magazine
    {
        private String name;
        private int number;

        public String Name
        {
            get { return name; }
        }

        public int No
        {
            get { return number; }
        }

        public override bool Equals(object obj)
        {
            if (obj is Magazine)
            {
                Magazine other = (Magazine) obj;
                if (this.Name == other.Name && this.No == other.No)
                    return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() * number;
        }

        public Magazine(String name, int number)
        {
            this.name = name;
            this.number = number;
        }
    }
}
