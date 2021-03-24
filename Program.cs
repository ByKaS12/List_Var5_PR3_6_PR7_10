using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Var5_PR3_6
{
   public class Family
    {
        public Human husband;
        public Human wife;
        public List<Children> children;
        public Family(Human M,Human ZH,List<Children> ch)
        {
            husband = M;
            wife = ZH;
            children = ch;
        }
    }
    public class Human
    {
        public string Name;
        public string Surname;
        public string Patronymic;
        public DateTime BirthDay;
        public string Gender;
        public double Salary;
        public Human(Human human)
        {
            Name = human.Name;
            Surname = human.Surname;
            Patronymic = human.Patronymic;
            BirthDay = human.BirthDay;
            Gender = human.Gender;
            Salary = human.Salary;
        }
        public Human(string name, string surname, string patronymic, DateTime birthDay, string gender, double salary)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            BirthDay = birthDay;
            Gender = gender;
            Salary = salary;
        }
    }
    public class Children : Human
    {
        public bool twin;
        public Children(bool t,Human human): base(human)
        {
            twin = t;
        }
    }
    class FIO
    {
        public string Name;
        public string Surname;
        public string Patronymic;
        public FIO(string name, string surname, string patronymic)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
        }
    }
    class Program
    {
        public static void FishClass(ref List<Family> families)
        {
            Human husband = new Human("Иван", "Быков", "Михайлович", new DateTime(1996, 06, 07), "Man", 100000);
            Human wife = new Human("Анастасия", "Быкова", "Михайловна", new DateTime(2000, 02, 05), "Woman", 50000);
            Children one = new Children(false,new Human("Ульяна", "Быкова", "Ивановна", new DateTime(2020, 06,11 ), "Woman", 0));
            List<Children> ch = new List<Children>();
            ch.Add(one);
            families.Add(new Family(husband, wife, ch));
            Human husband2 = new Human("Алексей", "Серебренников", "Витальевич", new DateTime(1993, 06,07), "Man", 70000);
            Human wife2 = new Human("Юлия", "Серебренникова", "Михайловна", new DateTime(1991, 05, 19), "Woman", 80000);
            List<Children> ch2 = new List<Children>();
            ch2.Add(new Children(true, new Human("Егор", "Серебренников", "Алексеевич", new DateTime(2003, 06, 11), "Man", 3000)));
            ch2.Add(new Children(true, new Human("Антон", "Серебренников", "Алексеевич", new DateTime(2003, 06, 11), "Man", 5000)));
            families.Add(new Family(husband2, wife2, ch2));
        }
        public static bool CheckHuman(string Name,string Surname,string Patronymic,List<Family> families)
        {
            bool IsCheck = false;
            foreach (var item in families)
            {
                if (item.husband.Name == Name && item.husband.Surname == Surname && item.husband.Patronymic == Patronymic)
                {
                    IsCheck = true;
                    break;
                }  
                if (item.wife.Name == Name && item.wife.Surname == Surname && item.wife.Patronymic == Patronymic)
                {
                    IsCheck = true;
                    break;
                }
                foreach (var ch in item.children)
                {
                    if (ch.Name == Name && ch.Surname == Surname && ch.Patronymic == Patronymic)
                    {
                        IsCheck = true;
                        break;
                    }
                }
            }

            return IsCheck;
        }
        static void TaskOne()
        {
            List<double> list = new List<double>();
            for (int i = 0; i <= 90; i++)
            {
                list.Add(Math.Sin(i * Math.PI / 180));
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Введите количество элементов, которые требуется удалить!");
            int M = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите индекс начала удаления!");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("После выполнения функции");
            DelListToM(ref list, N, M);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        static public List<FIO> WorkChild(List<Family> families)
        {
            List<FIO> WorkCh = new List<FIO>();
            foreach (var item in families)
            {
                foreach (var ch in item.children)
                {
                    if (ch.Salary != 0)
                        WorkCh.Add(new FIO(ch.Name,ch.Surname,ch.Patronymic));
                }

            }
            return WorkCh;
        }
        static public List<FIO> WorkHus(List<Family> families)
        {
            List<FIO> WorkCh = new List<FIO>();
            foreach (var item in families)
            {
              if(item.husband.Salary!=0 && item.husband.Salary>item.wife.Salary)
                    WorkCh.Add(new FIO(item.husband.Name, item.husband.Surname, item.husband.Patronymic));

            }
            return WorkCh;
        }
        public static List<FIO> FindHuman(int date, List<Family> families)
        {
            List<FIO> fIOs = new List<FIO>();
            foreach (var item in families)
            {
                if (item.husband.Salary==0 && item.husband.BirthDay.Year<date)
                {
                    fIOs.Add(new FIO(item.husband.Name, item.husband.Surname, item.husband.Patronymic));
                    
                }
                if (item.wife.Salary == 0 && item.wife.BirthDay.Year < date)
                {
                    fIOs.Add(new FIO(item.wife.Name, item.wife.Surname, item.wife.Patronymic));
                }
                foreach (var ch in item.children)
                {
                    if (ch.Salary == 0 && ch.BirthDay.Year < date)
                    {
                        fIOs.Add(new FIO(ch.Name, ch.Surname, ch.Patronymic));
                    }
                }
            }
           
            return fIOs;
        }
        static public int CountFamilyTwin(List<Family> families)
        {
            int i = 0;
            foreach (var item in families)
            {
                foreach (var ch in item.children)
                {
                    if (ch.twin == true)
                    {
                        i++;
                        break;
                    }
                        

                }

            }
            return i;
        }
        static void menu2(List<Family> families)
        {
            Console.WriteLine();
            Console.WriteLine("Выберите запрос");
            Console.WriteLine("Запрос №1: Существует ли в БД заданный человек (по ФИО)");
            Console.WriteLine("Запрос №2: Найти всех работающих детей");
            Console.WriteLine("Запрос №3: Найти всех работающих мужей, чей доход больше, чем у жены");
            Console.WriteLine("Запрос №4: Найти всех людей, которые не работают и родились до указанного года");
            Console.WriteLine("Запрос №5: Найти число семей, у которых есть близнецы");
            int Select = Convert.ToInt32(Console.ReadLine());
            switch (Select)
            {
                case 1:
                    {
                        Console.WriteLine("Напишите ФИО человека");
                        Console.WriteLine("Напишите Имя человека");
                        string Name = Console.ReadLine();
                        Console.WriteLine("Напишите Фамилию человека");
                        string Surname = Console.ReadLine();
                        Console.WriteLine("Напишите Отчество человека");
                        string P = Console.ReadLine();
                        if (CheckHuman(Name, Surname, P, families) == true)
                            Console.WriteLine("Человек найден");
                        else
                            Console.WriteLine("Человек НЕ найден");
                        
                        menu2(families);
                        break;
                    }
                case 2:
                    {
                        var WorkCh = WorkChild( families);
                        if (WorkCh.Count == 0)
                        {
                            Console.WriteLine("Ничего не найдено!");
                            menu2(families);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Найденные дети:");
                            foreach (var item in WorkCh)
                            {
                                Console.Write(item.Name + " " + item.Surname + " " + item.Patronymic + " ");
                                Console.WriteLine();
                            }
                            menu2(families);
                            break;
                        }
                    }
                case 3:
                    {
                        var WorkCh = WorkHus( families);
                        if (WorkCh.Count == 0)
                        {
                            Console.WriteLine("Ничего не найдено!");
                            menu2(families);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Найденные мужья:");
                            foreach (var item in WorkCh)
                            {
                                Console.Write(item.Name + " " + item.Surname + " " + item.Patronymic + " ");
                                Console.WriteLine();
                            }
                            menu2(families);
                            break;
                        }
                    }
                case 4:
                    {
                        Console.WriteLine("Введите год рождения!");
                        int date = Convert.ToInt32(Console.ReadLine());
                        var WorkCh = FindHuman(date,families);
                        if (WorkCh.Count == 0)
                        {
                            Console.WriteLine("Ничего не найдено!");
                            menu2(families);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Найденные люди:");
                            foreach (var item in WorkCh)
                            {
                                Console.Write(item.Name + " " + item.Surname + " " + item.Patronymic + " ");
                                Console.WriteLine();
                            }
                            menu2(families);
                            break;
                        }
                    }
                case 5:
                    {
                        var i = CountFamilyTwin(families);
                        if (i == 0)
                        {
                            Console.WriteLine("Ничего не найдено!");
                            menu2(families);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Количество семей =" + " " + i);
                            menu2(families);
                            break;
                        }
                    }
                default:
                    break;
            }
        }
        static void TaskTwo()
        {
            List<Family> families = new List<Family>();
            FishClass(ref families);
            menu2(families);
            
        }
        static public void menu()
        {
            Console.WriteLine("Выберите задание");
            Console.WriteLine("Задание №1 (Работа со списком)");
            Console.WriteLine("Задание №2 (Работа со БД)");
            Console.WriteLine("Выход №3");
            int Select = Convert.ToInt32(Console.ReadLine());
            switch (Select)
            {
                case 1:
                    {
                        TaskOne();
                        break;
                    }
                case 2:
                    {
                       TaskTwo();
                        break;
                    }
                case 3:
                        break;
                default:
                    break;
            }
        }

      static public void DelListToM<T>(ref List<T> list,int N,int M) 
        {
            int count = list.Count();
            if (list.Count() >= N + 1 + M)
                list.RemoveRange(N + 1, M);
            else
                list.RemoveRange(N + 1, count - N-1);
        }

        static void Main(string[] args)
        {
            menu();
        }
    }
}
