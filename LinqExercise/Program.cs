﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
 
             /* Complete every task using Method OR Query syntax
             * Print the Sum and Average of numbers---DONE
             * Order numbers in ascending order and decsending order. Print each to console.
             */

            var sum = numbers.Sum();
            var avg = numbers.Average();
            Console.WriteLine($"Sum:{sum}");
            Console.WriteLine($"Avearge:{avg}");

            var asc = numbers.OrderBy(num => num);
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Asc");
            foreach (var num in asc)
            {
                Console.WriteLine(num);
            }

            var desc = numbers.OrderByDescending(x => x);
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Desc");
            foreach (var num in desc)
            {
                Console.WriteLine(num);
            }

            /*Print to the console only the numbers greater than 6
             *Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
             *Change the value at index 4 to your age, then print the numbers in decsending order
             */

            var gts = numbers.Where(num => num > 6);
            foreach (var item in gts)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("The First 4");
            foreach (var num in asc.Take(4))
            {
                Console.WriteLine(num);
            }

            numbers[4] = 32;
            Console.WriteLine("With my age");
            foreach (var item in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(item);
            }

            // List of employees *** Do not remove this***
            var employees = CreateEmployees();

            
            /*Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
             *Order this in acesnding order by FirstName.
             *Print all the employees' FullName and Age who are over the age 26 to the console.
             *Order this by Age first and then by FirstName in the same result.
             */

            var filtered = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S')).OrderBy(person => person.FirstName);
            Console.WriteLine("C or S Employee");
            foreach (var employee in filtered)
            {
                Console.WriteLine(employee.FirstName);
            }

            var ots = employees.Where(emp => emp.Age > 26).OrderBy(emp => emp.Age).ThenBy(emp => emp.FirstName).ThenBy(emp => emp.YearsOfExperience);
            Console.WriteLine("Over 26");
            foreach (var person in ots)
            {
                Console.WriteLine($"Age: {person.Age} Fullname: {person.FullName} YOE: {person.YearsOfExperience}");
            }

            /*Print the Sum and then the Average of the employees' YearsOfExperience
             *if their YOE is less than or equal to 10 AND Age is greater than 35
             *Add an employee to the end of the list without using employees.Add()
             */

            var yoeEmployees = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            var sumOfYoe = yoeEmployees.Sum(emp => emp.YearsOfExperience);
            var avgOfYoe = yoeEmployees.Average(emp => emp.YearsOfExperience);

            Console.WriteLine($"Sum: {sumOfYoe} avg:{avgOfYoe}");

            employees = employees.Append(new Employee("firstname", "lastName", 98, 1)).ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.Age}");
            }

            Console.WriteLine();
            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
