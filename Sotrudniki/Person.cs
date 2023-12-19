using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сотрудники
{
    class Person
    {
        protected string name;
        protected int age;

        public Person(string name, int age) //Для наследования
        {
            this.name = name;
            this.age = age;
        }
        public void PersonInfo(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public void InfoOutput()
        {
            Console.WriteLine($"\tИмя: {name}");
            Console.WriteLine($"\tВозраст: {age}");
        }
    }
}
