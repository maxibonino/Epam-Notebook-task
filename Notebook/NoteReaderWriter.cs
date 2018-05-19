using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Notebook
{
    public class NoteReaderWriter
    {
        // Instance of NoteReaderWriter
        // allows to read from file and
        // from console.
        // Wnen exiting from app
        // we can save changes
        // in file.

        private XDocument rawNotebook;
        private string FileName { get; set; }

        public NoteReaderWriter(string fileName)
        {
            FileName = fileName;

            if (!File.Exists(FileName))
            {
                using (StreamWriter xdoc = new StreamWriter(FileName))
                {
                    xdoc.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                    xdoc.WriteLine("<notebook />");
                }
            }

            rawNotebook = XDocument.Load(FileName);
        }

        public List<Note> ReadAllFromFile()
        {
            List<Note> notes = (
                from note in rawNotebook
                    .Root
                    .Elements("note")
                    .Elements("person")
                select new Note
                 {
                     Person = new Person
                     {
                         Surname = (string)note.Element("surname"),
                         Name = (string)note.Element("name"),
                         BirthDate = (int)note.Element("birthdate")
                     },

                     PhoneNumbers = (
                        from tel in note.Elements("telephones").Elements("telephone")
                        select tel.Value
                        ).ToList()
                 }).ToList();
                 
            return notes;
        }

        public Note Read()
        {
            // Read from Console

            Console.Write("Surname: ");
            string surname = Console.ReadLine();

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Birth Year: ");
            int year;
            int.TryParse(Console.ReadLine(), out year);

            Console.Write("Telephone: ");
            string phoneNumber = Console.ReadLine();

            return new Note(new Person(surname, name, year), phoneNumber);
        }

        public void Write(Notebook notebook)
        {
            // Saving changes from notebook

            if (rawNotebook != null)
            {
                rawNotebook.Element("notebook").Elements("note").Remove();
                
                XElement main_root = new XElement("note");

                foreach (var t in notebook.NotebookList)
                {
                    XElement root = new XElement("person");
                    root.Add(new XElement("surname", t.Person.Surname));
                    root.Add(new XElement("name", t.Person.Name));
                    root.Add(new XElement("birthdate", t.Person.BirthDate));

                    XElement telephones = new XElement("telephones");

                    foreach (var tel in t.PhoneNumbers)
                    {
                        telephones.Add(new XElement("telephone", tel));
                    }

                    root.Add(telephones);
                    main_root.Add(root);
                }

                rawNotebook.Element("notebook").Add(main_root);

                rawNotebook.Document.Element("notebook").Save(FileName);
            }
            else
            {
                throw new FileLoadException();
            }
        }
    }
}
