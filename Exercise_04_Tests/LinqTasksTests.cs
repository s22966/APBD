using Exercise_04.Models;

namespace Exercise_04.Tests
{
    public class LinqTasksTests
    {
        #region Init
        public static IEnumerable<Emp> EmpsTest { get; set; } = new List<Emp>();
        public static IEnumerable<Dept> DeptsTest { get; set; } = new List<Dept>();

        public static int[] Array = { 1, 1, 1, 1, 1, 1, 10, 1, 1, 1, 1, 10, 2, 10, 10 };

        public LinqTasksTests()
        {
            var empsCol = new List<Emp>();
            var deptsCol = new List<Dept>();


            #region Load depts
            var d1 = new Dept { Deptno = 1, Dname = "Research", Loc = "Warsaw" };
            var d2 = new Dept { Deptno = 2, Dname = "Human Resources", Loc = "New York" };
            var d3 = new Dept { Deptno = 3, Dname = "IT", Loc = "Los Angeles" };
            var d4 = new Dept { Deptno = 5, Dname = "Accounting", Loc = "Radom" };
            var d5 = new Dept { Deptno = 2137, Dname = "Testing", Loc = "Wadowice" };
            deptsCol.Add(d1);
            deptsCol.Add(d2);
            deptsCol.Add(d3);
            deptsCol.Add(d4);
            deptsCol.Add(d5);
            DeptsTest = deptsCol;
            #endregion

            #region Load emps
            var e1 = new Emp { Deptno = 1, Empno = 1, Ename = "Jan Kowalski", HireDate = DateTime.Now.AddMonths(-1), Job = "Frontend programmer", Mgr = null, Salary = 2000 };
            var e2 = new Emp { Deptno = 1, Empno = 20, Ename = "Anna Malewska", HireDate = DateTime.Now.AddMonths(-7), Job = "Frontend programmer", Mgr = e1, Salary = 4000 };
            var e3 = new Emp { Deptno = 1, Empno = 2, Ename = "Marcin Korewski", HireDate = DateTime.Now.AddMonths(-3), Job = "Frontend programmer", Mgr = null, Salary = 5000 };
            var e4 = new Emp { Deptno = 2, Empno = 3, Ename = "Paweł Latowski", HireDate = DateTime.Now.AddMonths(-2), Job = "Backend programmer", Mgr = e2, Salary = 5500 };
            var e5 = new Emp { Deptno = 2, Empno = 4, Ename = "Michał Kowalski", HireDate = DateTime.Now.AddMonths(-2), Job = "Backend programmer", Mgr = e2, Salary = 5500 };
            var e6 = new Emp { Deptno = 2, Empno = 5, Ename = "Katarzyna Malewska", HireDate = DateTime.Now.AddMonths(-3), Job = "Manager", Mgr = null, Salary = 8000 };
            var e7 = new Emp { Deptno = null, Empno = 6, Ename = "Andrzej Kwiatkowski", HireDate = DateTime.Now.AddMonths(-3), Job = "System administrator", Mgr = null, Salary = 7500 };
            var e8 = new Emp { Deptno = 2, Empno = 7, Ename = "Marcin Polewski", HireDate = DateTime.Now.AddMonths(-3), Job = "Mobile developer", Mgr = null, Salary = 4000 };
            var e9 = new Emp { Deptno = 2, Empno = 8, Ename = "Władysław Torzewski", HireDate = DateTime.Now.AddMonths(-9), Job = "CTO", Mgr = null, Salary = 12000 };
            var e10 = new Emp { Deptno = 2, Empno = 9, Ename = "Andrzej Dalewski", HireDate = DateTime.Now.AddMonths(-4), Job = "Database administrator", Mgr = null, Salary = 9000 };
            var e12 = new Emp { Deptno = 5, Empno = 100, Ename = "Marcin Marcinowski", HireDate = DateTime.Now.AddMonths(-10), Job = "KING", Mgr = null, Salary = 50000 };
            var e11 = new Emp { Deptno = 5, Empno = 10, Ename = "Kunta Kinte", HireDate = DateTime.Now.AddMonths(-4), Job = "Backend programmer", Mgr = e12, Salary = 2000 };
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
            empsCol.Add(e11);
            empsCol.Add(e12);
            EmpsTest = empsCol;
            #endregion

            LinqTasks.Emps = EmpsTest;
            LinqTasks.Depts = DeptsTest;
        }
        #endregion

        [Fact]
        public void Task_01()
        {
            var res = LinqTasks.Task_01().ToList();

            Assert.NotNull(res);
            Assert.NotEmpty(res);
            Assert.Equal(3, res.Count);
        }

        [Fact]
        public void Task_02()
        {
            var res = LinqTasks.Task_02().ToList();

            Assert.NotNull(res);
            Assert.NotEmpty(res);
            Assert.Equal(3, res.Count);
            Assert.Equal("Anna Malewska", res.Last().Ename);
        }

        [Fact]
        public void Task_03()
        {
            var res = LinqTasks.Task_03();

            Assert.True(res > 0);
            Assert.Equal(50000, res);
        }

        [Fact]
        public void Task_04()
        {
            var res = LinqTasks.Task_04().ToList();

            Assert.NotNull(res);
            Assert.Single(res);
            Assert.Equal("KING", res.First().Job);
        }

        [Fact]
        public void Task_05()
        {
            var res = LinqTasks.Task_05().ToList();

            Assert.NotNull(res);
            Assert.NotEmpty(res);
            Assert.Equal(12, res.Count);
            Assert.Equal(res.First().ToString(), new { Nazwisko = "Jan Kowalski", Praca = "Frontend programmer" }.ToString());
        }

        [Fact]
        public void Task_06()
        {
            var res = LinqTasks.Task_06().ToList();

            Assert.NotNull(res);
            Assert.NotEmpty(res);
            Assert.Equal(res.Last().ToString(), new { Ename = "Marcin Marcinowski", Job = "KING", Dname = "Accounting" }.ToString());
        }

        [Fact]
        public void Task_07()
        {
            var res = LinqTasks.Task_07().ToList();

            Assert.NotNull(res);
            Assert.NotEmpty(res);
            Assert.Equal(8, res.Count);
            Assert.Equal(res.First().ToString(), new { Praca = "Frontend programmer", LiczbaPracownikow = 3 }.ToString());
            Assert.Equal(res.Last().ToString(), new { Praca = "KING", LiczbaPracownikow = 1 }.ToString());
        }

        [Fact]
        public void Task_08()
        {
            var res = LinqTasks.Task_08();

            Assert.True(res);
        }

        [Fact]
        public void Task_09()
        {
            var res = LinqTasks.Task_09();

            Assert.NotNull(res);
            Assert.Equal("Jan Kowalski", res.Ename);
            Assert.Equal(1, res.Empno);
        }

        [Fact]
        public void Task_10()
        {
            var res = LinqTasks.Task_10().ToList();

            Assert.NotNull(res);
            Assert.NotEmpty(res);
            Assert.Equal(13, res.Count());
            Assert.Equal(res.ElementAt(11).ToString(), new { Ename = "Marcin Marcinowski", Job = "KING", HireDate = EmpsTest.First(x => x.Job == "KING").HireDate }.ToString());
            Assert.Equal(res.Last().ToString(), new { Ename = "Brak wartości", Job = string.Empty, HireDate = (DateTime?)null }.ToString());
        }

        [Fact]
        public void Task_11()
        {
            var res = LinqTasks.Task_11().ToList();

            Assert.NotNull(res);
            Assert.NotEmpty(res);
            Assert.Equal(res.Last().ToString()?.ToLower(), new { Name = "Accounting", NumOfEmployees = 2 }.ToString()?.ToLower());
        }

        [Fact]
        public void Task_12()
        {
            var res = LinqTasks.Task_12().ToList();

            Assert.NotNull(res);
            Assert.NotEmpty(res);
            Assert.Contains(res, x => x.Ename == "Marcin Marcinowski" && x.Empno == 100);
            Assert.Equal("Anna Malewska", res.First().Ename);
            Assert.Equal("Marcin Marcinowski", res.Last().Ename);
        }

        [Fact]
        public void Task_13()
        {
            var res = LinqTasks.Task_13(Array);

            Assert.Equal(2, res);
        }

        [Fact]
        public void Task_14()
        {
            var res = LinqTasks.Task_14().ToList();

            Assert.NotNull(res);
            Assert.NotEmpty(res);
            Assert.Equal(2, res.Count());
            Assert.Contains(res, x => x.Dname == "Testing" && x.Deptno == 2137);
            Assert.Equal("Testing", res.Last().Dname);
        }
    }
}