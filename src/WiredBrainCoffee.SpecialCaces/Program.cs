using System;

namespace WiredBrainCoffee.SpecialCaces
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = new Container<string>();
            _ = new Container<string>();
            var container = new Container<int>();

            Console.WriteLine($"Container<string>: {Container<string>.InstanceCount}");
            Console.WriteLine($"Container<int>: {Container<int>.InstanceCount}");
            Console.WriteLine($"Container<bool>: {Container<bool>.InstanceCount}");
            Console.WriteLine($"ContainerBase: {ContainerBase.InstanceCountBase}");

            container.PrintItem<string>("Hello from generic method in generic class!");

            var results = Add(2, 3);
            Console.WriteLine($"2+3={results}");

            var result = Add(2.6, 3.8);
            Console.WriteLine($"2.7+3.8={result}");

            Console.ReadLine();
        }

        private static T Add<T>(T x, T y) where T : notnull
        {
            dynamic a = x;
            dynamic b = y;
            return a + b;
        }
    }

    class ContainerBase{

        public ContainerBase() => InstanceCountBase++;
        public static int InstanceCountBase {get; private set;}
    }

    class Container<T> : ContainerBase{

        public Container() => InstanceCount++;
        public static int InstanceCount {get; private set;}
        public void PrintItem<TItem>(TItem item){
            Console.WriteLine($"Item: {item}");
        }
    }
}
