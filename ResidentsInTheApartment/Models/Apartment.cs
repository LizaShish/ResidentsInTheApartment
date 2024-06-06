using DocumentFormat.OpenXml.Office2010.Excel;
using System.Net.Cache;
namespace ResidentsInTheApartment.Models
{
    internal class Apartment
    {
        public List<ResidentBase> Residents { get; set; } = new List<ResidentBase>
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
            },

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
            foreach ( var resident in Residents)
            {
                Console.WriteLine($"\nId: {resident.Id} " +
                    $"\nFirstName: {resident.FirstName} " +
                    $"\nAge: {resident.Age} ");
            }
        }
        public void PrintResident (int id)
        {
            foreach (var resident in Residents)
            {
                if (resident.Id == id)
                {
                    Console.WriteLine($"\nId: {resident.Id} " +
                    $"\nFirstName: {resident.FirstName} " +
                    $"\nAge: {resident.Age} ");
                }
            }
        }
        private int GetNextId()
        {
            int maxResidentId = Residents.Any() ? Residents.Max(p => p.Id) : 0;
            return (maxResidentId) + 1;
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

            Residents.Add(newPerson);
            Console.WriteLine($"Новый житель добавлен с Id: {newId}" +
              $"\nFirstName: {newName}" +
              $"\nAge: {newAge} ");
        }

        public void UpdateResident(int id)
        {
            var person = Residents.FirstOrDefault(p => p.Id == id);
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
                var pet = Residents.FirstOrDefault(p => p.Id == id);
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
            var person = Residents.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                Residents.Remove(person);
                Console.WriteLine("Жилец удален");
            }
            else
            {
                var pet = Residents.FirstOrDefault(p => p.Id == id);
                if (pet != null)
                {
                    Residents.Remove(pet);
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
