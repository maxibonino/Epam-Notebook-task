using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;
using System.Xml;
using System.IO;

namespace Notebook
{
    public class Person
    {
        private string surname;
        private string name;
        private int birthDate;

        public Person()
        {

        }

        public Person(string surname, string name, int birthDate)
        {
            Surname = surname;
            Name = name;
            BirthDate = birthDate;
        }

        public override bool Equals(object o)
        {
            if (o is Person anotherPerson)
                return Surname == anotherPerson.Surname &&
                    Name == anotherPerson.Name &&
                    birthDate == anotherPerson.birthDate;
            else
                throw new ArgumentException();
        }

        public string Surname
        {
            get => surname;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    surname = value;
                else
                    throw new ArgumentException("Invalid surname");
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    name = value;
                else
                    throw new ArgumentException("Invalid name");
            }
        }

        public int BirthDate
        {
            get => birthDate;
            set
            {
                if (value >= 1900)
                    birthDate = value;
                else
                    throw new ArgumentException("Invalid birthdate");
            }
        }
    }
}
