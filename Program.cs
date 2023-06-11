using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new List<Contact>();

            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            while (true)
            {
                var input = Console.ReadKey().KeyChar;
                Console.Clear();

                var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

                if (!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Страницы не существует");
                }
                else
                {
                    var pageContent = phoneBook.Skip((pageNumber - 1) * 3).Take(3);
                    Console.WriteLine();

                    var sortedpageContent = from page in pageContent
                                            orderby page.Name, page.LastName
                                            select page;

                    foreach (var p in sortedpageContent)
                        Console.WriteLine(p.Name + " " + p.LastName + ": " + p.PhoneNumber + " " + p.Email);

                    Console.WriteLine();
                }
            }
        }
    }
}