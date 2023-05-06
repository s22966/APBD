﻿using Exercise_04.Models;

namespace Exercise_04
{
    public static class LinqTasks
    {
        public static IEnumerable<Emp> Emps { get; set; }
        public static IEnumerable<Dept> Depts { get; set; }

        static LinqTasks()
        {
            var empsCol = new List<Emp>();
            var deptsCol = new List<Dept>();

            #region Load depts
            var d1 = new Dept { Deptno = 1, Dname = "Research", Loc = "Warsaw" };
            var d2 = new Dept { Deptno = 2, Dname = "Human Resources", Loc = "New York" };
            var d3 = new Dept { Deptno = 3, Dname = "IT", Loc = "Los Angeles" };
            deptsCol.Add(d1);
            deptsCol.Add(d2);
            deptsCol.Add(d3);
            Depts = deptsCol;
            #endregion

            #region Load emps
            var e1 = new Emp { Deptno = 1, Empno = 1, Ename = "Jan Kowalski", HireDate = DateTime.Now.AddMonths(-5), Job = "Backend programmer", Mgr = null, Salary = 2000 };
            var e2 = new Emp { Deptno = 1, Empno = 20, Ename = "Anna Malewska", HireDate = DateTime.Now.AddMonths(-7), Job = "Frontend programmer", Mgr = e1, Salary = 4000 };
            var e3 = new Emp { Deptno = 1, Empno = 2, Ename = "Marcin Korewski", HireDate = DateTime.Now.AddMonths(-3), Job = "Frontend programmer", Mgr = null, Salary = 5000 };
            var e4 = new Emp { Deptno = 2, Empno = 3, Ename = "Paweł Latowski", HireDate = DateTime.Now.AddMonths(-2), Job = "Frontend programmer", Mgr = e2, Salary = 5500 };
            var e5 = new Emp { Deptno = 2, Empno = 4, Ename = "Michał Kowalski", HireDate = DateTime.Now.AddMonths(-2), Job = "Backend programmer", Mgr = e2, Salary = 5500 };
            var e6 = new Emp { Deptno = 2, Empno = 5, Ename = "Katarzyna Malewska", HireDate = DateTime.Now.AddMonths(-3), Job = "Manager", Mgr = null, Salary = 8000 };
            var e7 = new Emp { Deptno = null, Empno = 6, Ename = "Andrzej Kwiatkowski", HireDate = DateTime.Now.AddMonths(-3), Job = "System administrator", Mgr = null, Salary = 7500 };
            var e8 = new Emp { Deptno = 2, Empno = 7, Ename = "Marcin Polewski", HireDate = DateTime.Now.AddMonths(-3), Job = "Mobile developer", Mgr = null, Salary = 4000 };
            var e9 = new Emp { Deptno = 2, Empno = 8, Ename = "Władysław Torzewski", HireDate = DateTime.Now.AddMonths(-9), Job = "CTO", Mgr = null, Salary = 12000 };
            var e10 = new Emp { Deptno = 2, Empno = 9, Ename = "Andrzej Dalewski", HireDate = DateTime.Now.AddMonths(-4), Job = "Database administrator", Mgr = null, Salary = 9000 };
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
        ///     SELECT 
        ///         * 
        ///     FROM
        ///         Emps
        ///     WHERE
        ///         Job = "Backend programmer";
        /// </summary>
        public static IEnumerable<Emp> Task_01()
        {
            return Emps.Where(emp => emp.Job == "Backend programmer");
        }

        /// <summary>
        ///     SELECT
        ///         *
        ///     FROM
        ///         Emps
        ///     WHERE
        ///         Job = "Frontend programmer" AND
        ///         Salary > 1000
        ///     ORDER BY
        ///         Ename DESC;
        /// </summary>
        public static IEnumerable<Emp> Task_02()
        {
            return Emps
                .Where(emp => emp.Job == "Frontend programmer")
                .Where(emp => emp.Salary > 1000)
                .OrderByDescending(emp => emp.Ename)
                .Select(emp => emp);
        }

        /// <summary>
        ///     SELECT
        ///         MAX(Salary)
        ///     FROM
        ///         Emps;
        /// </summary>
        public static int Task_03()
        {
            return Emps.Max(emp => emp.Salary);
        }

        /// <summary>
        ///     SELECT
        ///         *
        ///     FROM
        ///         Emps
        ///     WHERE
        ///         Salary = (
        ///             SELECT
        ///                 MAX(Salary)
        ///             FROM
        ///         Emps);
        /// </summary>
        public static IEnumerable<Emp> Task_04()
        {
            return Emps.Where(emp => emp.Salary == Emps.Max(e => e.Salary));
        }

        /// <summary>
        ///    SELECT
        ///         ename AS Nazwisko,
        ///         job AS Praca
        ///    FROM
        ///         Emps;
        /// </summary>
        public static IEnumerable<object> Task_05()
        {
            return Emps.Select(emp => new { Nazwisko = emp.Ename, Praca = emp.Job });
        }

        /// <summary>
        ///     SELECT
        ///         Emps.Ename,
        ///         Emps.Job,
        ///         Depts.Dname
        ///     FROM
        ///         Emps
        ///     INNER JOIN
        ///         Depts
        ///     ON
        ///         Emps.Deptno=Depts.Deptno
        ///     
        ///     Rezultat: Złączenie kolekcji Emps i Depts.
        /// </summary>
        public static IEnumerable<object> Task_06()
        {
            return Emps
                .Join(Depts, emp => emp.Deptno, dept => dept.Deptno, (emp, dept) => new { emp, dept })
                .Select(join => new { join.emp.Ename, join.emp.Job, join.dept.Dname });
        }

        /// <summary>
        ///     SELECT
        ///         Job AS Praca,
        ///         COUNT(1) AS LiczbaPracownikow
        ///     FROM
        ///         Emps
        ///     GROUP BY
        ///         Job;
        /// </summary>
        public static IEnumerable<object> Task_07()
        {
            return Emps
                .GroupBy(emp => emp.Job)
                .Select(group => new {Praca = group.Key, LiczbaPracownikow = group.Count()});
        }

        /// <summary>
        ///     Zwróć wartość "true" jeśli choć jeden
        ///     z elementów kolekcji pracuje jako "Backend programmer".
        /// </summary>
        public static bool Task_08()
        {
            return Emps.Any(emp => emp.Job == "Backend programmer");
        }

        /// <summary>
        ///     SELECT
        ///         TOP 1 *
        ///     FROM
        ///         Emp
        ///     WHERE
        ///         Job="Frontend programmer"
        ///     ORDER BY
        ///         HireDate DESC;
        /// </summary>
        public static Emp? Task_09()
        {
            return Emps
                .Where(emp => emp.Job == "Frontend programmer")
                .OrderByDescending(emp => emp.HireDate)
                .FirstOrDefault();
        }

        /// <summary>
        ///     SELECT
        ///         Ename,
        ///         Job,
        ///         Hiredate
        ///     FROM 
        ///         Emps
        ///     UNION
        ///         SELECT
        ///             "Brak wartości",
        ///             null,
        ///             null;
        /// </summary>
        public static IEnumerable<object> Task_10()
        {
            return Emps
                .Select(emp => new { emp.Ename, emp.Job, emp.HireDate })
                .Append(new { Ename = "Brak wartości", Job = (string)null, HireDate = (DateTime?)null });
        }

        /// <summary>
        /// Wykorzystując LINQ pobierz pracowników podzielony na departamenty pamiętając, że:
        /// 1. Interesują nas tylko departamenty z liczbą pracowników powyżej 1
        /// 2. Chcemy zwrócić listę obiektów o następującej srukturze:
        ///    [
        ///      {name: "RESEARCH", numOfEmployees: 3},
        ///      {name: "SALES", numOfEmployees: 5},
        ///      ...
        ///    ]
        /// 3. Wykorzystaj typy anonimowe
        /// </summary>
        public static IEnumerable<object> Task_11()
        {
            return Emps
                .Where(emp => emp.Deptno.HasValue)
                .GroupBy(emp => emp.Deptno)
                .Where(group => group.Count() > 1)
                .Select(group => new
                {
                    name = Depts.First(dept => dept.Deptno == group.Key).Dname.ToUpper(),
                    numOfEmployees = group.Count()
                });
        }

        /// <summary>
        /// Napisz własną metodę rozszerzeń, która pozwoli skompilować się poniższemu fragmentowi kodu.
        /// Metodę dodaj do klasy CustomExtensionMethods, która zdefiniowana jest poniżej.
        /// 
        /// Metoda powinna zwrócić tylko tych pracowników, którzy mają min. 1 bezpośredniego podwładnego.
        /// Pracownicy powinny w ramach kolekcji być posortowani po nazwisku (rosnąco) i pensji (malejąco).
        /// </summary>
        public static IEnumerable<Emp> Task_12()
        {
            return Emps.GetEmpsWithSubordinates();
        }

        /// <summary>
        /// Poniższa metoda powinna zwracać pojedyczną liczbę int.
        /// Na wejściu przyjmujemy listę liczb całkowitych.
        /// Spróbuj z pomocą LINQ'a odnaleźć tę liczbę, które występuja w tablicy int'ów nieparzystą liczbę razy.
        /// Zakładamy, że zawsze będzie jedna taka liczba.
        /// Np: {1,1,1,1,1,1,10,1,1,1,1} => 10
        /// </summary>
        public static int Task_13(int[] arr)
        {
            return arr
                .GroupBy(number => number)
                .Where(group => group.Count() % 2 != 0)
                .Select(group => group.Key)
                .FirstOrDefault();
        }

        /// <summary>
        /// Zwróć tylko te departamenty, które mają 5 pracowników lub nie mają pracowników w ogóle.
        /// Posortuj rezultat po nazwie departament rosnąco.
        /// </summary>
        public static IEnumerable<Dept> Task_14()
        {
            return Depts
                .Where(dept => !Emps.Any(emp => emp.Deptno == dept.Deptno) || Emps.Count(emp => emp.Deptno == dept.Deptno) == 5)
                .OrderBy(dept => dept.Dname)
                .Select(dept => dept);
        }
    }

    public static class CustomExtensionMethods
    {
        public static IEnumerable<Emp> GetEmpsWithSubordinates(this IEnumerable<Emp> emps)
        {
            return emps
                .Where(emp => emps.Any(emp_2 => emp_2.Mgr == emp.Mgr))
                .OrderBy(emp => emp.Ename)
                .ThenByDescending(emp => emp.Salary);
        }

    }
}
