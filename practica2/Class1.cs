using System;
using System.Collections.Generic;

namespace Practica2
{
    public class BaseClass
    {
        public string Name;
        public string Post;
        public List<Employment> Employments;

        public BaseClass(string name, string post, List<Employment> employments)
        {
            Name = name;
            Post = post;
            Employments = employments;
        }
    }
    public class Employment
    {
        public string DateOfReceipt;
        public string Name;
        public string DateOfDismissal;
        
        public Employment(string dateOfReceipt, string name, string dateOfDismissal)
        {
            DateOfReceipt = dateOfReceipt;
            Name = name;
            DateOfDismissal = dateOfDismissal;
        }
        
    }

    public class Work
    {
        public string DateWork;
        public string NameWork;

        public Work(string dateWork, string nameWork)
        {
            DateWork = dateWork;
            NameWork = nameWork;
        }
    }

    public class Manager : BaseClass
    {
        public List<string> Direction;

        public Manager(string name, string post, List<Employment> employments, List<string> direction) : base(name, post, employments)
        {
            Name = name;
            Post = post;
            Employments = employments;
            Direction = direction;
        }
        
    }

    public class Basic : BaseClass
    {
        public string CountExamples;

        public Basic(string name, string post, List<Employment> employments, string count) : base(name, post, employments)
        {
            Name = name;
            Post = post;
            Employments = employments;
            CountExamples = count;
        }
    }
    
    public class Secondary : BaseClass
    {
        public List<Work> AccessWork;

        public Secondary(string name, string post, List<Employment> employments, List<Work> accessWork) : base(name, post, employments)
        {
            Name = name;
            Post = post;
            Employments = employments;
            AccessWork = accessWork;
        }
    }
    
    public class Class1
    {
        public static List<Manager> Managers = new List<Manager>();
        public static List<Basic> Basics = new List<Basic>();
        public static List<Secondary> Secondaries = new List<Secondary>();
        
        
        public static void Main()
        {
            Menu();
        }
        public static void Menu(string text = "")
        {
            Console.Clear();
            Console.WriteLine("МЕНЮ\n\n" +
                              "1. Заполнить\n" +
                              "2. Выборки\n" +
                              "3. Выход\n" +
                              $"{text}\n");
            Console.Write("Выберите действие: ");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    DoSelect(1);
                    goto default;
                case ConsoleKey.D2:
                    Console.Clear();
                    DoSelect(2);
                    goto default;
                case ConsoleKey.D3:
                    Console.Clear();
                    Console.WriteLine("Вы успешно вышли!");
                    goto default;
                default:
                    break;
            }
        }

        public static void DoSelect(int doIt)
        {
            Console.Clear();
            Console.WriteLine("Выберите категорию:\n" +
                              "1. Управленцы\n" +
                              "2. Основные\n" +
                              "3. Вспомогательные\n" +
                              "4. Назад\n\n");
            Console.Write("Выберите действий");
            var select = Console.ReadKey().Key;
            if (select == ConsoleKey.D4)
            {
                Console.Clear();
                Menu();
            }
            else
            {
                if (doIt == 1)
                {
                    Fill(select);
                } else if (doIt == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Выберите действие: \n" +
                                      "1. По общему стажу работы\n" +
                                      "2. По стажу работы на последнем месте\n" +
                                      "3. По количество экземпляров, отпечатанных за диапозон дат\n" +
                                      "4. Работы, выполненные определённым лицом\n" +
                                      "5. Приказы составленные определённым лицом\n" +
                                      "6. Назад\n");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.D1:
                            Console.Clear();
                            TotalWork(select);
                            break;
                        case ConsoleKey.D2:
                            Console.Clear();
                            TotalLastWork(select);
                            break;
                        case ConsoleKey.D3:
                            Console.Clear();
                            TotalCountWork(select);
                            break;
                        case ConsoleKey.D4:
                            Console.Clear();
                            TotalOrderWork(select);
                            break;
                        case ConsoleKey.D5:
                            Console.Clear();
                            SampleOfOrders(select);
                            break;
                        case ConsoleKey.D6:
                            Console.Clear();
                            Menu();
                            break;
                    }
                    Menu();
                }
            }
        }
        

        public static void TotalWork(ConsoleKey categories)
        {
            switch (categories)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("Введите стаж: ");
                    int inputDate = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    foreach (var manager in Managers)
                    {
                        int summa = 0;
                        foreach (var managerEmployment in manager.Employments)
                        {
                            summa += (Convert.ToInt32(managerEmployment.DateOfDismissal) - Convert.ToInt32(managerEmployment.DateOfReceipt));
                        }
                        if (summa == inputDate)
                        {
                            Console.WriteLine("Имя:" + manager.Name + "\n" +
                                              "Должность:" + manager.Post + "\n");
                        }
                    }
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Введите стаж: ");
                    int inputDate2 = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    foreach (var basic in Basics)
                    {
                        int summa = 0;
                        foreach (var basicEmployment in basic.Employments)
                        {
                            summa += Convert.ToInt32(basicEmployment.DateOfDismissal) - Convert.ToInt32(basicEmployment.DateOfReceipt);
                        }

                        if (summa == inputDate2)
                        {
                            Console.WriteLine("Имя:" + basic.Name + "\n" +
                                              "Должность:" + basic.Post + "\n");
                        }
                    }
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("Введите стаж: ");
                    int inputDate3 = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    foreach (var secondary in Secondaries)
                    {
                        int summa = 0;
                        foreach (var secondaryEmployment in secondary.Employments)
                        {
                            summa += Convert.ToInt32(secondaryEmployment.DateOfDismissal) - Convert.ToInt32(secondaryEmployment.DateOfReceipt);
                        }

                        if (summa == inputDate3)
                        {
                            Console.WriteLine("Имя:" + secondary.Name + "\n" +
                                              "Должность:" + secondary.Post + "\n");
                        }
                    }
                    break;
            }
            Console.WriteLine("Для возврата нажмите любую калвишу...");
            Console.ReadKey();
        }
        
        public static void TotalLastWork(ConsoleKey categories)
        {
            switch (categories)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("Введите стаж: ");
                    int inputDate = Convert.ToInt32(Console.ReadLine());
                    foreach (var manager in Managers)
                    {
                        if (Convert.ToInt32(manager
                                .Employments[manager.Employments.Count - 1].DateOfDismissal) - 
                            Convert.ToInt32(manager
                                .Employments[manager.Employments.Count - 1].DateOfReceipt)==
                            inputDate)
                        {
                            Console.WriteLine("Имя:" + manager.Name + "\n" +
                                              "Должность:" + manager.Post + "\n");
                        }
                    }
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Введите стаж: ");
                    int inputDate1 = Convert.ToInt32(Console.ReadLine());
                    foreach (var basic in Basics)
                    {
                        if (Convert.ToInt32(basic
                                .Employments[basic.Employments.Count - 1].DateOfDismissal) - 
                            Convert.ToInt32(basic
                                .Employments[basic.Employments.Count - 1].DateOfReceipt) ==
                            inputDate1)
                        {
                            Console.WriteLine("Имя:" + basic.Name + "\n" +
                                              "Должность:" + basic.Post + "\n");
                        }
                    }
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("Введите стаж: ");
                    int inputDate2 = Convert.ToInt32(Console.ReadLine());
                    foreach (var secondary in Secondaries)
                    {
                        if (Convert.ToInt32(secondary
                                .Employments[secondary.Employments.Count - 1].DateOfDismissal) - 
                            Convert.ToInt32(secondary
                                .Employments[secondary.Employments.Count - 1].DateOfReceipt) ==
                            inputDate2)
                        {
                            Console.WriteLine("Имя:" + secondary.Name + "\n" +
                                              "Должность:" + secondary.Post + "\n");
                        }
                    }
                    break;
            }
            Console.WriteLine("Для возврата нажмите любую калвишу...");
            Console.ReadKey();
        }

        public static void TotalCountWork(ConsoleKey categories)
        {
            switch (categories)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("Данный вид не печатает экземпляры");
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Введите кол-во экземпляров: ");

                    int inputDate2 = Convert.ToInt32(Console.ReadLine());
                    foreach (var basic in Basics)
                    {
                        if (Convert.ToInt32(basic.CountExamples) == inputDate2)
                        {
                            Console.WriteLine("Имя:" + basic.Name + "\n" +
                                              "Должность:" + basic.Post + "\n");
                        }
                    }
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("Данный вид не печатает экземпляры");
                    break;
            }
            Console.WriteLine("Для возврата нажмите любую калвишу...");
            Console.ReadKey();
        }

        public static void TotalOrderWork(ConsoleKey categories)
        {
            switch (categories)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("Данный вид не выполнял работы");
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Данный вид не выполнял работы");
                    break;
                case ConsoleKey.D3:
                    int count = 1;
                    Console.WriteLine("Введите ФИО определённого лица:");
                    var inputDate = Console.ReadLine();
                    foreach (var secondary in Secondaries)
                    {
                        if (inputDate == secondary.Name)
                        {
                            foreach (var work in secondary.AccessWork)
                            {
                                Console.WriteLine($"{count}.\n" +
                                                  $"Название: {work.NameWork}\n" +
                                                  $"Дата: {work.DateWork}\n");
                            }
                        }
                    }
                    break;
            }
            Console.WriteLine("Для возврата нажмите любую клавишу...");
            Console.ReadKey();
        }

        public static void SampleOfOrders(ConsoleKey categories)
        {
            switch (categories)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("Введите ФИО определённого лица:");
                    var inputDate = Console.ReadLine();
                    foreach (var manager in Managers)
                    {
                        if (manager.Name == inputDate)
                        {
                            var count = 1;
                            foreach (var direction in manager.Direction)
                            {
                                Console.WriteLine($"Указ №{count}: " + direction);
                                count++;
                            }
                        }
                    }
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Данный вид не издавал приказы");
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("Данный вид не издавал приказы");
                    break;
            }
            Console.WriteLine("Для возврата нажмите любую клавишу...");
            Console.ReadKey();
        }
        
        
        public static void Fill(ConsoleKey categories)
        {
            Console.Clear();
            List<Employment> employments = new List<Employment>();
            Console.Write("Введите ФИО: ");
            string name = Console.ReadLine();
            Console.Write("Введите должность:");
            string post = Console.ReadLine();
            Console.Write("Хотите заполнить трудовую кинжку:\n" +
                          "1. Да\n" +
                          "2. Нет\n");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    do
                    {
                        Console.Clear();
                        List<Employment> employmentResult = AddObjectEmployment(employments);
                        employments = employmentResult;
                        Console.Clear();
                        Console.WriteLine("Хотите добавить еще одну организацию:\n" +
                                          "1 - Да\n" +
                                          "2 - Нет");
                    } while (Console.ReadKey().Key != ConsoleKey.D2);
                    break;
                case ConsoleKey.D2:
                    break;
            }
            switch (categories)
            {
                case ConsoleKey.D1:
                    FillManagers(name, post, employments);
                    goto default;
                case ConsoleKey.D2:
                    FillBasics(name, post, employments);
                    goto default;
                case ConsoleKey.D3:
                    FillSecondaries(name, post, employments);
                    goto default;
                default:
                    break;
            }
        }

        public static void FillManagers(string name, string post, List<Employment> employments)
        {
            Console.Clear();
            List<string> directions = new List<string>();
            Console.Write("Хотите добавить распоряжение:\n" +
                          "1. Да\n" +
                          "2. Нет\n");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    do
                    {
                        Console.Clear();
                        List<string> directionsResult = AddObjectDirection(directions);
                        directions = directionsResult;
                        Console.Clear();
                        Console.WriteLine("Хотите добавить еще одно распоряжение:\n" +
                                          "1 - Да\n" +
                                          "2 - Нет");
                    } while (Console.ReadKey().Key != ConsoleKey.D2);
                    break;
                case ConsoleKey.D2:
                    break;
            }
            Console.Clear();
            AddManager(name, post, employments, directions);
            Menu("Вы успешно добавили распоряженца");
        }
        
        public static void FillBasics(string name, string post, List<Employment> employments)
        {
            Console.Clear();
            Console.Write("Введите количество экземпляров отпечатанных в день: ");
            string count = Console.ReadLine();
            Console.Clear();
            AddBasics(name, post, employments, count);
            Menu("Вы успешно добавили основного");
        }
        
        public static void FillSecondaries(String name, string post, List<Employment> employments)
        {
            Console.Clear();
            List<Work> works = new List<Work>();
            Console.Write("Хотите добавить выполненную работу?\n" +
                          "1. Да\n" +
                          "2. Нет\n");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    do
                    {
                        Console.Clear();
                        List<Work> result = AddObjectWorks(works);
                        works = result;
                        Console.Clear();
                        Console.WriteLine("Хотите добавить еще одно выполненную работу?\n" +
                                          "1 - Да\n" +
                                          "2 - Нет");
                    } while (Console.ReadKey().Key != ConsoleKey.D2);
                    break;
                case ConsoleKey.D2:
                    break;
            }
            Console.Clear();
            AddSecondary(name, post, employments, works);
            Menu("Вы успешно добавили распоряженца");
            
        }
        
        public static List<Employment> AddObjectEmployment(List<Employment> employments)
        {
            Console.Clear();
            Console.WriteLine("\nВведите год поступления: ");
            var firstYear = Console.ReadLine();
            Console.WriteLine("Введите наименование организации: ");
            var nameObject = Console.ReadLine();
            Console.WriteLine("Введите год увольнения: ");
            var leaveYear = Console.ReadLine();
            employments.Add(new Employment(firstYear, nameObject, leaveYear));
            return employments;
        }

        public static List<string> AddObjectDirection(List<string> directions)
        {
            Console.Clear();
            Console.WriteLine("\nВведите указ: ");
            var direction = Console.ReadLine();
            directions.Add(direction);
            return directions;
        }
        
        public static List<Work> AddObjectWorks(List<Work> works)
        {
            Console.Clear();
            Console.WriteLine("\nВведите дату выполненной работы: ");
            var dateWork = Console.ReadLine();
            Console.WriteLine("\nВведите название выполненной работы: ");
            var nameWork = Console.ReadLine();
            works.Add(new Work(dateWork, nameWork));
            return works;
        }

        public static void AddManager(string name, string post, List<Employment> employments, List<string> direction)
        {
            Managers.Add(new Manager(name, post, employments, direction));
        }

        public static void AddBasics(string name, string post, List<Employment> employments, string count)
        {
            Basics.Add(new Basic(name, post, employments, count));
        }

        public static void AddSecondary(string name, string post, List<Employment> employments, List<Work> accessWork)
        {
            Secondaries.Add(new Secondary(name, post, employments, accessWork));
        }
    }
}