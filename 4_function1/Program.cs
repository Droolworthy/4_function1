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
                        FillingArray(ref fio, ref position);
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

        static void AddArray(ref string[] array,int arrayLength)
        {
            string[] newArray = new string[arrayLength];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            array = newArray;
        }

        static void FillingArray(ref string[] fio, ref string[] position)
        {
            Console.WriteLine("Введите ФИО: ");
            AddArray(ref fio, fio.Length + 1);
            fio[fio.Length - 1] = Console.ReadLine();

            Console.WriteLine("Введите должность: ");
            AddArray(ref position, position.Length + 1);
            position[position.Length - 1] = Console.ReadLine();
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

        static void DeleteDossier(ref string[] fio, ref string[] position)
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

                        if (userInput < fio.Length)
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

            fio = DeleteArray(fio, fio.Length + increment, userInput);
            position = DeleteArray(position, position.Length + increment, userInput);
        }

        static bool SearchLastName(string[] fio, string[] positions)
        {
            bool isContinueCycle = true;
            int value = 0;

            Console.Write("Введите фамилию для поиска доссье: ");
            string userInput = Console.ReadLine();

            for (int i = 0; i < fio.Length; i++)
            {
                if (userInput == fio[i].Split(' ')[0])
                {
                    isContinueCycle = false;
                    value = i;
                }
            }

            if (isContinueCycle == false)
            {
                Console.WriteLine(fio[value] + " " + positions[value]);
            }
            else
            {
                Console.WriteLine(userInput + " - отсутствует в списке доссье.");
            }

            return isContinueCycle;
        }
    }
}
