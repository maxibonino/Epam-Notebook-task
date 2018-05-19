using System;

namespace Notebook
{
    public class Program
    {
        private static void Main(string[] args)
        {
            NoteReaderWriter noteReaderWriter = new NoteReaderWriter("Notebook.xml");

            Notebook notebook = new Notebook(noteReaderWriter.ReadAllFromFile());

            Menu.ShowMenu();

            while (true)
            {
                var pressedKey = Console.ReadKey(true);
                switch (pressedKey.Key)
                {
                    case ConsoleKey.P:
                        Console.Clear();
                        notebook.PrintNotebook();
                        Menu.ShowMenu();
                        break;

                    case ConsoleKey.A:
                        Console.Clear();
                        notebook.AddNote(noteReaderWriter.Read());
                        Menu.ShowMenu();
                        break;

                    case ConsoleKey.R:
                        Console.Clear();
                        notebook.RemoveNote();
                        Menu.ShowMenu();
                        break;

                    case ConsoleKey.U:
                        Console.Clear();
                        notebook.SearchBySurname();
                        Menu.ShowMenu();
                        break;

                    case ConsoleKey.N:
                        Console.Clear();
                        notebook.SearchByName();
                        Menu.ShowMenu();
                        break;

                    case ConsoleKey.T:
                        Console.Clear();
                        notebook.SearchByTel();
                        Menu.ShowMenu();
                        break;

                    case ConsoleKey.O:
                        Console.Clear();
                        notebook.Order(new Notebook.SurnameBirthDateComp());
                        notebook.PrintNotebook();
                        Menu.ShowMenu();
                        break;

                    case ConsoleKey.Escape: // Saving changes only after exit!
                        noteReaderWriter.Write(notebook);
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
