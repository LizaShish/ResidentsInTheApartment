using DocumentFormat.OpenXml.Office2010.Excel;
using System.Net.Cache;

namespace ResidentsInTheApartment.Models
{
    internal class Apartment
    {
        public List<Person> Persons { get; set; } = new List<Person>
        {
            new Person
            {
                Id = 1,
                FirstName = "Gay",
                Age = 26,

            },
            new Person
            {
                Id = 2,
                FirstName = "Galya",
                Age = 74,
            }
        };

        public List<Pet> Pets { get; set; } = new List<Pet>
        {
            new Pet
            {
                Id = 3,
                FirstName = "Dog",
            },
            new Pet
            {
                Id = 4,
                FirstName = "Cat",
            }
        };

        public void PrintPersonsAndPets()
        {
            Console.WriteLine("Residents");
            foreach ( var person in Persons)
            {
                Console.WriteLine($"\nId: {person.Id} " +
                    $"\nFirstName: {person.FirstName} " +
                    $"\nAge: {person.Age} ");
            }
            
            Console.WriteLine("\nPets");
            foreach (var pet in Pets)
            {
                Console.WriteLine($"\nId: {pet.Id} " +
                    $"\nFirstName:{pet.FirstName}");
            }
        }

        public void PrintResident (int id)
        {
            foreach ( var person in Persons)
            {
                if (person.Id == id)
                {
                    Console.WriteLine($"\nId: {person.Id} " +
                    $"\nFirstName: {person.FirstName} " +
                    $"\nAge: {person.Age} ");
                }
              
            }

            foreach ( var pet in Pets)
            {
               if (pet.Id == id)
                {
                    Console.WriteLine($"\nId: {pet.Id} " +
                   $"\nFirstName:{pet.FirstName}");
                }
            }
        }
        private int GetNextId()
        {
            int maxPersonId = Persons.Any() ? Persons.Max(p => p.Id) : 0;
            int maxPetId = Pets.Any() ? Pets.Max(p => p.Id) : 0;
            return Math.Max(maxPersonId, maxPetId) + 1;
        }
        public void AddResident(string? v)
        {
            Console.WriteLine("Введите имя новго жильца");
            string newName = Console.ReadLine();

            Console.WriteLine("Введите возраст нового жильца");
            int newAge = Convert.ToInt32(Console.ReadLine());

            int newId = GetNextId();
            
            var newPerson = new Person
            {
                Id = newId,
                FirstName = newName,
                Age = newAge
            };

            Persons.Add(newPerson);
            Console.WriteLine($"Новый житель добавлен с Id: {newId}" +
              $"\nFirstName: {newName}" +
              $"\nAge: {newAge} ");
        }

        public void UpdateResident(int id)
        {
            var person = Persons.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                Console.WriteLine("Введите новое имя жильца:");
                person.FirstName = Console.ReadLine();

                Console.WriteLine("Введите новый возраст жильца:");
                if (int.TryParse(Console.ReadLine(), out int newAge))
                {
                    person.Age = newAge;
                    Console.WriteLine("Жилец обновлен.");
                }
                else
                {
                    Console.WriteLine("Некорректный ввод возраста.");
                }
            }
            else
            {
                var pet = Pets.FirstOrDefault(p => p.Id == id);
                if (pet != null)
                {
                    Console.WriteLine("Введите новое имя питомца:");
                    pet.FirstName = Console.ReadLine();
                    Console.WriteLine("Питомец обновлен.");
                }
                else
                {
                    Console.WriteLine("Жилец или питомец с таким Id не найден.");
                }
            }
        }

        public void DeleteResident(int id)
        {
            var person = Persons.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                Persons.Remove(person);
                Console.WriteLine("Жилец удален");
            }
            else
            {
                var pet = Pets.FirstOrDefault(p => p.Id == id);
                if (pet != null)
                {
                    Pets.Remove(pet);
                    Console.WriteLine("Питомец удален");
                }
                else
                {
                    Console.WriteLine("Жилец/Питомец с таким Id не найден.");
                }
            }
        }
    }
}
