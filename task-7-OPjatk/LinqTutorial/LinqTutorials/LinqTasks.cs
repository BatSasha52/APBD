﻿using LinqTutorials.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTutorials
{
    public static class LinqTasks
    {
        public static IEnumerable<Emp> Emps { get; set; }
        public static IEnumerable<Dept> Depts { get; set; }

        static LinqTasks()
        {
            List<Emp> empsCol = new List<Emp>();
            List<Dept> deptsCol = new List<Dept>();

            #region Load depts

            Dept d1 = new Dept
            {
                Deptno = 1,
                Dname = "Research",
                Loc = "Warsaw"
            };

            Dept d2 = new Dept
            {
                Deptno = 2,
                Dname = "Human Resources",
                Loc = "New York"
            };

            Dept d3 = new Dept
            {
                Deptno = 3,
                Dname = "IT",
                Loc = "Los Angeles"
            };

            deptsCol.Add(d1);
            deptsCol.Add(d2);
            deptsCol.Add(d3);
            Depts = deptsCol;

            #endregion

            #region Load emps

            Emp e1 = new Emp
            {
                Deptno = 1,
                Empno = 1,
                Ename = "Jan Kowalski",
                HireDate = DateTime.Now.AddMonths(-5),
                Job = "Backend programmer",
                Mgr = null,
                Salary = 2000
            };

            Emp e2 = new Emp
            {
                Deptno = 1,
                Empno = 20,
                Ename = "Anna Malewska",
                HireDate = DateTime.Now.AddMonths(-7),
                Job = "Frontend programmer",
                Mgr = e1,
                Salary = 4000
            };

            Emp e3 = new Emp
            {
                Deptno = 1,
                Empno = 2,
                Ename = "Marcin Korewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Frontend programmer",
                Mgr = null,
                Salary = 5000
            };

            Emp e4 = new Emp
            {
                Deptno = 2,
                Empno = 3,
                Ename = "Paweł Latowski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Frontend programmer",
                Mgr = e2,
                Salary = 5500
            };

            Emp e5 = new Emp
            {
                Deptno = 2,
                Empno = 4,
                Ename = "Michał Kowalski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Backend programmer",
                Mgr = e2,
                Salary = 5500
            };

            Emp e6 = new Emp
            {
                Deptno = 2,
                Empno = 5,
                Ename = "Katarzyna Malewska",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Manager",
                Mgr = null,
                Salary = 8000
            };

            Emp e7 = new Emp
            {
                Deptno = null,
                Empno = 6,
                Ename = "Andrzej Kwiatkowski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "System administrator",
                Mgr = null,
                Salary = 7500
            };

            Emp e8 = new Emp
            {
                Deptno = 2,
                Empno = 7,
                Ename = "Marcin Polewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Mobile developer",
                Mgr = null,
                Salary = 4000
            };

            Emp e9 = new Emp
            {
                Deptno = 2,
                Empno = 8,
                Ename = "Władysław Torzewski",
                HireDate = DateTime.Now.AddMonths(-9),
                Job = "CTO",
                Mgr = null,
                Salary = 12000
            };

            Emp e10 = new Emp
            {
                Deptno = 2,
                Empno = 9,
                Ename = "Andrzej Dalewski",
                HireDate = DateTime.Now.AddMonths(-4),
                Job = "Database administrator",
                Mgr = null,
                Salary = 9000
            };

            empsCol.Add(e1);
            empsCol.Add(e2);
            empsCol.Add(e3);
            empsCol.Add(e4);
            empsCol.Add(e5);
            empsCol.Add(e6);
            empsCol.Add(e7);
            empsCol.Add(e8);
            empsCol.Add(e9);
            empsCol.Add(e10);
            Emps = empsCol;

            #endregion
        }

        /// <summary>
        ///     SELECT * FROM Emps WHERE Job = "Backend programmer";
        /// </summary>
        public static IEnumerable<Emp> Task1()
        {
            return Emps.Where(e => e.Job == "Backend programmer");
        }


        /// <summary>
        ///     SELECT * FROM Emps Job = "Frontend programmer" AND Salary>1000 ORDER BY Ename DESC;
        /// </summary>
        public static IEnumerable<Emp> Task2()
        {
            return Emps.Where(e => e.Job == "Frontend programmer" && e.Salary > 1000)
                .OrderByDescending(e => e.Ename);
        }



        /// <summary>
        ///     SELECT MAX(Salary) FROM Emps;
        /// </summary>
        public static int Task3()
        {
            return Emps.Max(e => e.Salary);
        }

        /// <summary>
        ///     SELECT * FROM Emps WHERE Salary=(SELECT MAX(Salary) FROM Emps);
        /// </summary>
        public static IEnumerable<Emp> Task4()
        {
            var maxSalary = Task3();
            return Emps.Where(e => e.Salary == maxSalary);
        }


        /// <summary>
        ///    SELECT ename AS Nazwisko, job AS Praca FROM Emps;
        /// </summary>
        public static IEnumerable<object> Task5()
        {
            return Emps.Select(e => new { Nazwisko = e.Ename, Praca = e.Job });
        }


        /// <summary>
        ///     SELECT Emps.Ename, Emps.Job, Depts.Dname FROM Emps
        ///     INNER JOIN Depts ON Emps.Deptno=Depts.Deptno
        ///     Result: Merging the Emps and Depts collections.
        /// </summary>
        public static IEnumerable<object> Task6()
        {
            return Emps.Join(Depts,
                e => e.Deptno,
                d => d.Deptno,
                (e, d) => new { e.Ename, e.Job, d.Dname });
        }


        /// <summary>
        ///     SELECT Job AS Praca, COUNT(1) LiczbaPracownikow FROM Emps GROUP BY Job;
        /// </summary>
        public static IEnumerable<object> Task7()
        {
            return Emps.GroupBy(e => e.Job)
                .Select(group => new 
                {
                    Praca = group.Key,
                    LiczbaPracownikow = group.Count()
                });
        }


        /// <summary>
        /// Return "true" if at least one
        /// from collection items works as "Backend programmer".
        /// </summary>
        public static bool Task8()
        {
            return Emps.Any(e => e.Job == "Backend programmer");
        }


        /// <summary>
        ///     SELECT TOP 1 * FROM Emp WHERE Job="Frontend programmer"
        ///     ORDER BY HireDate DESC;
        /// </summary>
        public static Emp Task9()
        {
            return Emps.Where(e => e.Job == "Frontend programmer")
                .OrderByDescending(e => e.HireDate)
                .FirstOrDefault();
        }


        /// <summary>
        ///     SELECT Ename, Job, Hiredate FROM Emps
        ///     UNION
        ///     SELECT "Brak wartości", null, null;
        /// </summary>
        public static IEnumerable<object> Task10()
        {
            var employees = Emps.Select(e => new { e.Ename, e.Job, e.HireDate });
            var defaultValues = new[] { new { Ename = "Brak wartości", Job = (string)null, HireDate = (DateTime?)null } };
            return employees.Union(defaultValues);
        }


        /// <summary>
        /// Using LINQ, get employees divided into departments, remembering that:
        /// 1. We are only interested in departments with more than 1 employees
        /// 2. We want to return a list of objects with the following structure:
        /// [
        /// {name: "RESEARCH", numOfEmployees: 3},
        /// {name: "SALES", numOfEmployees: 5},
        /// ...
        ///]
        /// 3. Use anonymous types
        /// </summary>
        public static IEnumerable<object> Task11()
        {
            return Depts.Join(Emps, 
                    d => d.Deptno, 
                    e => e.Deptno, 
                    (d, e) => new { d.Dname, e.Deptno })
                .GroupBy(de => de.Dname)
                .Select(group => new 
                {
                    name = group.Key,
                    numOfEmployees = group.Count()
                })
                .Where(dept => dept.numOfEmployees > 1);
        }


        /// <summary>
        /// Write your own extension method that will compile the following code snippet.
        /// Add the method to the CustomExtensionMethods class defined below.
        ///
        /// The method should return only those employees who have min. 1 direct subordinate.
        /// Within the collection, employees should be sorted by name (ascending) and salary (descending).
        /// </summary>
        public static IEnumerable<Emp> Task12()
        {
            return Emps.GetEmpsWithSubordinates();
        }

        /// <summary>
        /// The method below should return a single int.
        /// As input we accept a list of integers.
        /// Try LINQ to find the number that occurs an odd number of times in the int table.
        /// We assume that there will always be one such number.
        /// For example: {1,1,1,1,1,1,10,1,1,1,1} => 10
        /// </summary>
        public static int Task13(int[] arr)
        {
            return arr.GroupBy(x => x)
                .Where(g => g.Count() % 2 == 1)
                .Select(g => g.Key)
                .FirstOrDefault();
        }


        /// <summary>
        /// Only return departments that have 5 employees or no employees at all.
        /// Sort the result by department in ascending order.
        /// </summary>
        public static IEnumerable<Dept> Task14()
        {
            var empCounts = Emps
                .GroupBy(e => e.Deptno)
                .Select(group => new { Deptno = group.Key, Count = group.Count() })
                .ToList(); // ToList for materialization

            var result = Depts
                .Where(d => empCounts.Any(ec => ec.Deptno == d.Deptno && (ec.Count == 5 || ec.Count == 0))
                            || !empCounts.Any(ec => ec.Deptno == d.Deptno)) // Departments with no employees
                .OrderBy(d => d.Dname);

            return result;
        }
    }

    public static class CustomExtensionMethods
    {
        public static IEnumerable<Emp> GetEmpsWithSubordinates(this IEnumerable<Emp> emps)
        {
            return emps.Where(e => emps.Any(sub => sub.Mgr?.Empno == e.Empno))
                .OrderBy(e => e.Ename)
                .ThenByDescending(e => e.Salary);
        }
    }
}
