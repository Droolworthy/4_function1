using System;

namespace _4_function1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] fullName = { "Фамилия Имя Отчество", "Смирнов Николай Николаевич", "Петров Пётр Иванович", "Целиков Павел Сергеевич" };
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
                        AddDossier(ref fullName, ref position);
                        break;
                    case "2":
                        OutputAllDossiers(fullName, position);
                        break;
                    case "3":
                        DeleteDossier(ref fullName, ref position);
                        break;
                    case "4":
                        SearchLastName(fullName, position);
                        break;
                    case "5":
                        canExitApp = false;
                        break;
                    default:
                        OutputAllDossiers(fullName, position);
                        break;
                }
            }
        }
        static void ShowDossier(string[] fullName, string[] position)
        {
            for (int i = 0; i < fullName.Length; i++)
            {
                if (i != 0)
                {
                    Console.WriteLine(i + " " + fullName[i] + " " + position[i]);
                }
                else
                {
                    Console.WriteLine("  " + fullName[i] + " " + position[i]);
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
        static void OutputAllDossiers(string[] fullName, string[] position)
        {
            Console.Clear();
            ShowMenu();
            ShowDossier(fullName, position);
        }
        static string[] AddArray(string[] array, int arrayLength, string stringText)
        {
            string[] newArray = new string[arrayLength];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            newArray[newArray.Length - 1] = stringText;
            return newArray;
        }
        static void AddDossier(ref string[] fullName, ref string[] position)
        {
            Console.WriteLine("Введите фамилию: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Введите имя: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите отчество: ");
            string patronymic = Console.ReadLine();
            Console.WriteLine("Введите должность: ");
            string title = Console.ReadLine();

            string humanData = surname + " " + name + " " + patronymic;
            int increment = 1;

            fullName = AddArray(fullName, fullName.Length + increment, humanData);
            position = AddArray(position, position.Length + increment, title);
        }
        static string[] DeleteArray(string[] array, int arrayLength, int userInput)
        {
            string[] newArray = new string[arrayLength];
            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (userInput != i)
                {
                    newArray[count] = array[i];
                    count++;
                }
            }
            return newArray;
        }
        static void DeleteDossier(ref string[] fullName, ref string[] position)
        {
            bool isContinueCycle = true;
            int userInput = 0;

            while (isContinueCycle)
            {
                Console.Write("Введите номер доссье для удаления: ");
                string number = Console.ReadLine();

                for (int i = 0; i < number.Length; i++)
                {
                    if (char.IsNumber(number, i))
                    {
                        if (number.Length - 1 == i)
                        {
                            userInput = int.Parse(number);
                        }
                        if (userInput < fullName.Length)
                        {
                            isContinueCycle = false;
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели не верный номер.");
                            number = "";
                            userInput = 0;
                        }
                    }
                    else
                    {
                        number = "";
                        Console.Write("Для удаления введите номер. ");
                        Console.WriteLine();
                    }
                }
            }
            int increment = -1;

            fullName = DeleteArray(fullName, fullName.Length + increment, userInput);
            position = DeleteArray(position, position.Length + increment, userInput);
        }
        static bool SearchLastName(string[] fullName, string[] positions)
        {
            bool isContinueCycle = true;
            int value = 0;

            Console.Write("Введите фамилию для поиска доссье: ");
            string userInput = Console.ReadLine();

            for (int i = 0; i < fullName.Length; i++)
            {
                if (userInput == fullName[i].Split(' ')[0])
                {
                    isContinueCycle = false;
                    value = i;
                }
            }
            if (isContinueCycle == false)
            {
                Console.WriteLine(fullName[value] + " " + positions[value]);
            }
            else
            {
                Console.WriteLine(userInput + " - отсутствует в списке доссье.");
            }
            return isContinueCycle;
        }
    }
}
