//Будет 2 массива: 1) фио 2) должность.
//Описать функцию заполнения массивов досье, функцию форматированного вывода, функцию поиска по фамилии и функцию удаления досье.
//Функция расширяет уже имеющийся массив на 1 и дописывает туда новое значение.
//Программа должна быть с меню, которое содержит пункты:
//1) добавить досье
//2) вывести все досье (в одну строку через “-” фио и должность с порядковым номером в начале)
//3) удалить досье(Массивы уменьшаются на один элемент.Нужны дополнительные проверки, чтобы не возникало ошибок)
//4) поиск по фамилии
//5) выход.
using System;

namespace _4_function1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] fio = { "Фамилия Имя Отчество", "Смирнов Николай Николаевич", "Петров Пётр Иванович", "Целиков Павел Сергеевич" };
            string[] position = { "Должность", "Программист", "Грузчик", "Водитель" };
            bool canExitApp = true;
            string userInput;

            Console.Clear();
            ShowMenu();

            while (canExitApp)
            {
                Console.Write("Ввод: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        InputAddingInfo(ref fio, ref position);
                        break;
                    case "2":
                        OutputAllDossiers(fio, position);
                        break;
                    case "3":
                        DeleteDossier(ref fio, ref position);
                        break;
                    case "4":
                        SearchLastName(fio, position);
                        break;
                    case "5":
                        canExitApp = false;
                        break;
                    default:
                        OutputAllDossiers(fio, position);
                        break;
                }
            }
        }

        static void ShowDossier(string[] fio, string[] position)
        {
            for (int i = 0; i < fio.Length; i++)
            {
                if (i != 0)
                {
                    Console.WriteLine(i + " " + fio[i] + " " + position[i]);
                }
                else
                {
                    Console.WriteLine("  " + fio[i] + " " + position[i]);
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("==========M--------Е---------Н--------Ю============");
            Console.WriteLine("|||||||||-------1)ДОБАВИТЬ ДОСЬЕ---------||||||||||");
            Console.WriteLine("|||||||||-----2)ВЫВЕСТИ ВСЁ ДОСЬЕ--------||||||||||");
            Console.WriteLine("|||||||||-------3)УДАЛИТЬ ДОСЬЕ----------||||||||||");
            Console.WriteLine("|||||||||------4)ПОИСК ПО ФАМИЛИИ--------||||||||||");
            Console.WriteLine("|||||||||___________5)ВЫХОД______________||||||||||");
        }

        static void OutputAllDossiers(string[] fio, string[] position)
        {
            Console.Clear();
            ShowMenu();
            ShowDossier(fio, position);
        }

        static string[] AddArray(string[] array, string stringText)
        {
            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            array = tempArray;
            array[array.Length - 1] = stringText;
            return array;
        }

        static void InputAddingInfo(ref string[] fio, ref string[] position)
        {
            Console.WriteLine("Введите ФИО: ");
            string newFio = Console.ReadLine();
            fio = AddArray(fio, newFio);

            Console.WriteLine("Введите должность: ");
            string newPosition = Console.ReadLine();
            position = AddArray(position, newPosition);
            Console.WriteLine("Досье добавлено!");
        }

        static string[] DeleteArray(string[] array, int userInput)
        {
            string[] newArray = new string[array.Length - 1];

            for (int i = 0; i < userInput; i++)
            {
                newArray[i] = array[i];
            }

            for (int i = userInput; i < newArray.Length; i++)
            {
                newArray[i] = array[i + 1];
            }

            return newArray;
        }

        static void DeleteDossier(ref string[] fio, ref string[] position)
        {
            Console.Write("Введите номер доссье для удаления: ");
            int userInput = Convert.ToInt32(Console.ReadLine()) - 1;
            fio = DeleteArray(fio, userInput);
            position = DeleteArray(position, userInput);
            Console.WriteLine("Досье удалено!");
        }

        static void SearchLastName(string[] fio, string[] positions)
        {
            Console.Write("Введите фамилию для поиска доссье: ");
            string userInput = Console.ReadLine();

            for (int i = 0; i < fio.Length; i++)
            {
                string[] splittedNames = fio[i].Split();

                foreach (string name in splittedNames)
                {
                    if (name.ToLower() == userInput.ToLower())
                    {
                        Console.WriteLine($"Досье {i + 1}: {fio[i]} - {positions[i]} ");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
