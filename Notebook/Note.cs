using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    public class Note
    {
        private const int PHONE_NUMBER_LENGTH = 11;

        private Person person;
        private List<string> phoneNumbers;

        public Note()
        {

        }

        public Note(string surname, string name, int birthDate, string phoneNumber)
        {
            Person = new Person(surname, name, birthDate);

            phoneNumbers = new List<string>();

            AddPhoneNumber(phoneNumber);
        }

        public Note(Person person, string phoneNumber)
        {
            Person = person;

            phoneNumbers = new List<string>();

            AddPhoneNumber(phoneNumber);
        }

        public static bool IsCorrectPhoneNumber(string phoneNumber)
        {
            return !string.IsNullOrEmpty(phoneNumber) &&
                phoneNumber.Length <= PHONE_NUMBER_LENGTH &&
                phoneNumber.All(x => Char.IsDigit(x));
        }

        public void AddPhoneNumber(string phoneNumber)
        {
            if (IsCorrectPhoneNumber(phoneNumber))
                phoneNumbers.Add(phoneNumber);
            else
                throw new ArgumentException("Wrong phone number!");
        }

        public Person Person
        {
            get => person;
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                else
                    person = value;
            }
        }

        public List<string> PhoneNumbers
        {
            get => phoneNumbers;
            set
            {
                if (value.All(x => IsCorrectPhoneNumber(x)))
                {
                    if (phoneNumbers == null)
                    {
                        phoneNumbers = value;
                    }
                    else
                    {
                        phoneNumbers.AddRange(value);
                    }
                }
                else
                {
                    throw new ArgumentException("Incorrect phone list");
                }
            }
        }
    }
}
