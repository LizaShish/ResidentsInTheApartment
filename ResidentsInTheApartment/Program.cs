
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Wordprocessing;
using ResidentsInTheApartment.Models;
using System;

public class Program
{
    static void Main(string[] args)
    {
        var apartment = new Apartment();

        while (true)
        {
            Console.WriteLine("Привет, выбери действие:\r\n1. Показать всех жильцов квартиры вместе с питомцами" +
                "\r\n2. Показать отдельного жителя квартиры" +
                "\r\n3. Добавить нового жильца/питомца" +
                "\r\n4. Обновить жильца/питомца" +
                "\r\n5. Удалить жильца/питомца " +
                "\r\n6. Выйти ");
        
            string action = Console.ReadLine();
            int choice = Convert.ToInt32(action);

                if (action.Equals("6", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                if (int.TryParse(action, out choice))
                {
                    if (choice == 1)
                    {
                        apartment.PrintPersonsAndPets();
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("Введите Id жильца/питомца");

                        int resdentId;

                        if (int.TryParse(Console.ReadLine(), out resdentId))
                        {
                         apartment.PrintResident(resdentId);
                        }
                        else
                        {
                         Console.WriteLine("Неверное значение");
                        }
                    }
                    else if (choice == 3)
                    {
                        apartment.AddResident(Console.ReadLine());
                    }
                    else if (choice == 4)
                    {
                        Console.WriteLine("Введите Id жильца, которого хотите обновить");
                        string IdPerson = Console.ReadLine();
                        int ChangeResidentsId = Convert.ToInt32(IdPerson);

                        apartment.UpdateResident(ChangeResidentsId);
                    }
                    else if (choice == 5)
                    {
                        Console.WriteLine("Введите id жителя/питомца, которого необходимо удалить");
                    
                        int deleteId;
                        if(int.TryParse(Console.ReadLine(), out deleteId))
                        {
                            apartment.DeleteResident(deleteId);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный выбор.");
                    }
                    action = Console.ReadLine();
                }
        }
    }
}





