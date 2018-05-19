using System;
using System.Collections.Generic;
using System.Linq;

namespace Notebook
{
    public class Notebook
    {
        private List<Note> notebook;

        private void AddNote(Person person, string phoneNumber)
        {
            notebook.Add(new Note(person, phoneNumber));
        }

        private void ShowNote(int index)
        {
            string underline = new string('_', 33);

            Console.WriteLine($"{index + 1}. {notebook[index].Person.Surname} {notebook[index].Person.Name} {notebook[index].Person.BirthDate}");
            Console.WriteLine("Telephones");

            foreach (var tel in notebook[index].PhoneNumbers)
            {
                Console.WriteLine(tel);
            }

            Console.WriteLine(underline);
        }

        public List<Note> NotebookList
        {
            get => notebook;
            set
            {
                if (value == null || value.Any(x => x == null))
                    throw new ArgumentNullException("List or Note of can not be null!");
                else
                    notebook = value;
            }
        }

        public Notebook(List<Note> notebook)
        {
            NotebookList = notebook;
        }

        public void AddNote(Note note)
        {
            bool isInserted = false;

            for (int i = 0; i < notebook.Count; i++)
            {
                if (notebook[i].Person == note.Person)
                {
                    notebook[i].PhoneNumbers = note.PhoneNumbers;
                }
            }

            if (!isInserted)
            {
                notebook.Add(note);
            }
        }

        public void RemoveNote()
        {
            Console.Write("Enter number of note to remove: ");

            int index;
            int.TryParse(Console.ReadLine(), out index);

            if (index < 1 || index > notebook.Count)
            {
                Console.WriteLine("Error number!");
            }
            else
            {
                notebook.RemoveAt(index - 1);
                Console.WriteLine("Done!");
            }
        }

        public void SearchBySurname()
        {
            bool isFound = false;

            Console.Write("Search by surname: ");
            string surname = Console.ReadLine();

            if (surname.Length == 0 || surname.All(x => Char.IsLetter(x)))
            {
                for (int i = 0; i < notebook.Count; i++)
                {
                    if (notebook[i].Person.Surname.ToLower() == surname.ToLower())
                    {
                        ShowNote(i);
                        isFound = true;
                    }
                }
            }

            if (!isFound)
                Console.WriteLine("Not found.");
        }

        public void SearchByName()
        {
            bool isFound = false;

            Console.Write("Search by name: ");
            string name = Console.ReadLine();

            if (name.Length == 0 || name.All(x => Char.IsLetter(x)))
            {
                for (int i = 0; i < notebook.Count; i++)
                {
                    if (notebook[i].Person.Name.ToLower() == name.ToLower())
                    {
                        ShowNote(i);
                        isFound = true;
                    }
                }
            }

            if (!isFound)
                Console.WriteLine("Not found.");
        }

        public void SearchByTel()
        {
            bool isFound = false;

            Console.Write("Search by - telephone number: ");
            string tel = Console.ReadLine();

            if (tel.Length == 0 || tel.All(x => Char.IsDigit(x)))
            {
                for (int i = 0; i < notebook.Count; i++)
                {
                    for (int j = 0; j < notebook[i].PhoneNumbers.Count; j++)
                    {
                        if (notebook[i].PhoneNumbers[j] == tel)
                        {
                            ShowNote(i);
                            isFound = true;
                        }
                    }
                }
            }

            if (!isFound)
                Console.WriteLine("Not found.");
        }

        public void PrintNotebook()
        {
            string stars = new String('*', 33);


            Console.WriteLine(stars);

            if (notebook.Any(note => note == null))
            {
                Console.WriteLine("Nothing to show!");
            }
            else
            {
                for (int i = 0; i < notebook.Count; i++)
                {
                    ShowNote(i);
                }
            }
        }

        public void Order(IComparer<Note> comp)
        {
            notebook.Sort(comp);
        }

        public class SurnameBirthDateComp : IComparer<Note>
        {
            public int Compare(Note note1, Note note2)
            {
                if (note1.Person.Surname == note2.Person.Surname)
                    return note1.Person.BirthDate.CompareTo(note2.Person.BirthDate);

                return note1.Person.Surname.CompareTo(note2.Person.Surname);
            }
        }
    }
}
