using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сотрудники;

namespace Сотрудники
{
    class Employee : Person
    {
        protected int otdel_number;
        public int night_work;    //Количество ночных смен за мес
        public int day_work;      //Количество дневных смен за мес
        protected int DayShiftsMin = 25;   //Число обязательных смен, после которых уже начисляется процент начальнику смены
        protected int NightShiftsMin = 15; //Число обязательных ночныз смен для начисления премии начальнику смены
        protected double zarplata;

        private double Night_smena_dengi = 2200;
        private double Day_smena_dengi = 1600;

        public Employee(string name, int age, int DepartmentNumber, int night_work, int day_work, int DayShiftsMin, int NightShiftsMin) : base(name, age) //наследуем значения от класса Person
        {
            this.day_work = day_work;
            this.night_work = night_work;
        }
        public void ShiftsCount(int DayShiftsMin, int NightShiftsMin)  //Перекидываем минимальные значения отсюда в Main
        {
            DayShiftsMin = this.DayShiftsMin;
            NightShiftsMin = this.NightShiftsMin;
        }
        public void Dayshiftscount(int Day_smena_dengi, int Night_smena_dengi)
        {
            Day_smena_dengi = this.day_work;
            Night_smena_dengi = this.night_work;
        }
        public void Smena(Employee[] people, int i, int age) //Заполнение смен
        {
            Random rnd = new Random();
            if (age < 18)  //Если младше 18, то только дневные смены
            {
                day_work = rnd.Next(20, 60); //Может как отработать меньше, так и переработать
            }
            else if (age >= 18) //Если старше - и дневные, и ночные
            {
                night_work = rnd.Next(20, 40);
                day_work = rnd.Next(20, 40);
            }

            Otdel_info(people, i); //Отдел
        }
        private void Otdel_info(Employee[] people, int i)
        {
            if (i < 5) //Если индекс меньше 5, то закидываем сотрудников в первый отдел
            {
                people[i].otdel_number = 1;  //Указали номер отдела                                                       
            }
            else
            {
                people[i].otdel_number = 2;
            }
        }

        private double ZarplataSotrudnika(double zarplata) //Расчет заработной платы каждого сотрудника
        {
            zarplata = Day_smena_dengi * day_work + Night_smena_dengi * night_work; //стоимость ночных и дневных смен
            return zarplata;
        }

        public void SotrudnikInfoOutput() //Выводим информацию о сотрудниках
        {
            base.InfoOutput(); //имя и возраст

            Console.WriteLine($"\tНомер отдела: {otdel_number}");
            Console.WriteLine($"\tВсего отработано смен за месяц: {day_work + night_work}, из них:");
            Console.WriteLine($"\tДневных: {day_work}");
            Console.WriteLine($"\tНочных: {night_work}");

            zarplata = ZarplataSotrudnika(zarplata);  //Рассчитали зарплату
            Console.WriteLine($"\tЗарплата: {zarplata} руб");
        }
    }
}
