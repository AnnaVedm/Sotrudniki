namespace Сотрудники
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            int age = 0;
            int DepartmentNumber = 0; //номер отдела
            int OvertimeWork = 0;     //переносим из класса
            int DayShiftsMin = 0;     //переносим из класса
            int NightShiftsMin = 0;   //число обязательных смен (переносим из класса)
            double LeaderSalary;      //итоговая зарплата начальника смены
            double Bonus = 0;         //сумма премии
            double BonusValue = 0;

            Random rnd = new Random();

            Employee employee = new Employee("", 0, 0, 0, 0, 0, 0);
            ShiftLeader leader = new ShiftLeader("", 0, 0, 0, 0, 0, 0);
            Employee[] people = new Employee[10];          //массив сотрудников
            ShiftLeader[] leaders = new ShiftLeader[2];   //массив начальников

            leader.ShiftsCount(DayShiftsMin, NightShiftsMin); //записали сюда значения из класса ShiftLeader

            //СОТРУДНИКИ
            for (int i = 0; i < people.Length; i++)
            {
                Console.WriteLine($"Сотрудник {i + 1}");
                people[i] = new Employee("", 0, 0, 0, 0, 0, 0);

                Console.Write("\tВведите имя: ");
                name = Console.ReadLine();

                Console.Write("\tВведите возраст: ");       //должен быть от 16 до 50
                age = Convert.ToInt32(Console.ReadLine());
                age = age_check(age); //проверка на введенный возраст

                people[i].Smena(people, i, age); //заполнение смен + отдела
                people[i].PersonInfo(name, age);   //записываем введенные значения в класс

                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine("Информация о сотрудниках: ");
            for (int j = 0; j < people.Length; j++)  //вывод информации о всех сотрудниках
            {
                Console.WriteLine($"Сотрудник {j + 1}");
                people[j].SotrudnikInfoOutput();   //метод на вывод информации

                Console.ReadKey();
                Console.WriteLine();
            }

            //НАЧАЛЬНИКИ
            for (int i = 0; i < leaders.Length; i++)
            {
                leaders[i] = new ShiftLeader("", 0, 0, 0, 0, 0, 0);
                leaders[i].ShiftLeaderInfoFilling(leaders, people, i); //заполнение информации о начальнике смены в классе
            }

            Console.Write("Нажмите любую клавишу, чтобы увидеть итоговую зарплату начальников каждой из смен: ");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Информация о начальниках смен: \n");
            for (int j = 0; j < leaders.Length; j++)  //вывод информации о всех сотрудниках
            {
                Console.WriteLine($"Начальник смены {j + 1}");
                leaders[j].LeadersInfoOutput();  //вывод информации о начальнике смены

                Console.WriteLine();
            }

            Console.ReadKey();
        }

        static int age_check(int age)
        {
            while (age < 16 || age > 50)
            {
                Console.Write("Возраст сотрудников должен быть от 16 до 50. Введите другое значение: ");
                age = Convert.ToInt32(Console.ReadLine());
            }
            return age;
        }
    }
}