
namespace Generics
{
    class MyFirstGenericClass<T>
    {
        public T First { get; set; }
        public T Second { get; set; }
        public T Third { get; set; }

        public MyFirstGenericClass(T first, T second, T third)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
        }

        public string MyFirstGenericMethod()
        {
            return "This is myfirst generic method.";
        }
    }







    class Person
    {
        public string Name { get; set; }
        public Person(string name)
        {
            this.Name = name;
        }
    }

    class Employee : Person
    {
        public string JobTitle { get; set; }

        public Employee(string name, string jobTitle) : base(name)
        {
            this.JobTitle = jobTitle;
        }
    }



    interface IGroup<out T>
    {
        IEnumerable<T> GetAll();
    }

    class Group<T> : IGroup<T>
    {
        List<T> list = new List<T>();  //Define list.
        public Group(List<T> list)
        {
            this.list = list;
        }
        public IEnumerable<T> GetAll() => list;
    }

    class Program
    {
        public static void Display(IGroup<Person> objs)
        {
            foreach (var obj in objs.GetAll())
            {
                Console.WriteLine(obj.Name);
                //Console.WriteLine(obj.JobTitle);
                Console.WriteLine(" ");
            }

            Console.WriteLine("=================================================");
            Console.WriteLine(" ");
        }

        public static void Main(string[] args)
        {
            var employees = new List<Employee>()
            {
                new Employee("John Doe","C# Developer"),
                new Employee("Jane Doe","UI/UX Developer")
            };

            Group<Employee> employeeGroup = new Group<Employee>(employees);

            Display(employeeGroup);
        }
    }


    //class Output
    //{
    //    public static void Main(string[] args)
    //    {
    //        MyFirstGenericClass<string> clsStr = new MyFirstGenericClass<string>("Mango", "Banana", "Orange");
    //        MyFirstGenericClass<int> clsInt = new MyFirstGenericClass<int>(5,7,12);
    //        Console.WriteLine(clsStr.MyFirstGenericMethod());
    //        Console.WriteLine("==========Property finding(string)==========");
    //        Console.WriteLine("The first property:- " + clsStr.First);
    //        Console.WriteLine("The second property:- " + clsStr.Second);
    //        Console.WriteLine("The third property:- " + clsStr.Third);
    //        Console.WriteLine("==========Property finding(integer)==========");
    //        Console.WriteLine("The sum of number is:- " + (clsInt.First+clsInt.Second+clsInt.Third));
    //    }
    //}
}