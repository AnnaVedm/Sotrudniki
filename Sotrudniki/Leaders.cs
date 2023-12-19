using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сотрудники;

namespace Сотрудники
{
    class ShiftLeader : Employee
    {
        //Создать в Main массив начальников
        public double ShiftLeaderSalary = 108390;  //Зарплата начальника дневной смены //изначально оклад
        private int OvertimeWork = 0;
        public double Bonus = 0;       //Итоговая сумма премии
        private double BonusValue = 0; //Сумма за каждого сотрудника (в %)

        public ShiftLeader(string name, int age, int DepartmentNumber, int NightShiftsCount, int DayShiftsCount, int DayShiftsMin, int NightShiftsMin) : base(name, age, DepartmentNumber, NightShiftsCount, DayShiftsCount, DayShiftsMin, DayShiftsMin)
        { }
        public void TimeWork(int OvertimeWork) //Закидываем отсюда туда
        {
            this.OvertimeWork = OvertimeWork;
        }
        public void Bonusvalue(double BonusValue) //Закидываем в Main
        {
            BonusValue = this.BonusValue;
        }
        public void SalaryBonus(double Bonus) //Закидываем отсюда туда
        {
            Bonus = this.Bonus;
        }
        private double LeaderSalary(int OvertimeWork, out double BonusValue) //Расчет заработной платы начальника смены
        {
            BonusValue = 0;
            BonusValue = BonusCheck(OvertimeWork, BonusValue);

            ShiftLeaderSalary += ShiftLeaderSalary * BonusValue; //Условие того, каким будет BonusValue, находится в Main
            return ShiftLeaderSalary;
        }
        private double BonusCheck(int OvertimeWork, double BonusValue)  //Считаем размер бонуса за каждого сотрудника
        {
            if (OvertimeWork >= 1 && OvertimeWork <= 10) //Бонус 3% от оклада
            {
                BonusValue = 0.03;
            }
            else if (OvertimeWork >= 11 && OvertimeWork <= 15) //Бонус 5% от оклада
            {
                BonusValue = 0.05;
            }
            else if (OvertimeWork >= 16) //Бонус 7%
            {
                BonusValue = 0.07;
            }
            return BonusValue;
        }
        private double BonusCount(double BonusValue) //Считаем бонус
        {
            Bonus += ShiftLeaderSalary * BonusValue;
            return Bonus;
        }
        private int DayOvertimeCount(int DayShiftsCount) //Считаем сколько переработано ДНЕВНЫХ СМЕН
        {
            OvertimeWork += DayShiftsCount - DayShiftsMin;
            return OvertimeWork;
        }
        private int NightOvertimeCount(int NightShiftsCount) //Переработка НОЧНЫХ СМЕН
        {
            OvertimeWork += NightShiftsCount - NightShiftsMin;
            return OvertimeWork;
        }
        public void ShiftLeaderInfoFilling(ShiftLeader[] leaders, Employee[] people, int i) //Заполняем информацию о начальниках смены
        {
            for (int j = 0; j < people.Length; j++)
            {
                if (people[j].day_work > DayShiftsMin && i == 0) //Если дневных смен больше обязательного минимума и рассматриваем начальника дневной смены
                {
                    OvertimeWork = leaders[i].DayOvertimeCount(people[j].day_work);
                }
                else if (people[j].night_work > DayShiftsMin && i == 1)
                {
                    OvertimeWork = leaders[i].NightOvertimeCount(people[j].night_work);
                }

                leaders[i].TimeWork(OvertimeWork);
                ShiftLeaderSalary = leaders[i].LeaderSalary(OvertimeWork, out BonusValue); //Посчитали зарплату и сохранили

                Bonus = leaders[i].BonusCount(BonusValue);  //Посчитали размер бонуса за одного сотрудника
                leaders[i].SalaryBonus(Bonus); //Связали переменные разных класов (закинули)
            }
        }
        public void LeadersInfoOutput() //Выводим информацию о начальниках смены
        {
            Console.WriteLine($"Зарплата: {Math.Round(ShiftLeaderSalary, 3)}");
            Console.WriteLine($"Всего переработок на {OvertimeWork} смены");
            Console.WriteLine($"Итоговый бонус: {Math.Round(Bonus, 3)} руб");
        }
    }
}
