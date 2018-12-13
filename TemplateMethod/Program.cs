using System;

/// <summary>
/// Metoda szablonowa – czynnościowy wzorzec projektowy. Jego zadaniem jest zdefiniowanie metody, będącej szkieletem algorytmu. 
/// Algorytm ten może być następnie dokładnie definiowany w klasach pochodnych. Niezmienna część algorytmu zostaje opisana w metodzie szablonowej, 
/// której klient nie może nadpisać. W metodzie szablonowej wywoływane są inne metody, reprezentujące zmienne kroki algorytmu.
/// Przykładem zastosowania tego wzorca są biblioteki, wspomagające automatyzację testów jednostkowych. 
/// Biblioteka jUnit definiuje ogólny algorytm wykonywania testów. Składa się on z trzech podstawowych kroków: 
/// przygotowania środowiska do wykonania testów, wykonania testów, a następnie posprzątania po wykonanych testach. 
/// Kroki te reprezentowane są przez metody setUp, runTest oraz tearDown. Wymienione metody wykonywane są w niezmiennej kolejności przez metodę run, której klient nie może zmienić. 
/// Dzięki temu, użytkownik nie może zmieniać kolejności podstawowych bloków algorytmu, może jednak nadpisać metody setUp, runTest oraz tearDown, 
/// co pozwala mu dostosować testy do swoich potrzeb.
/// https://pl.wikipedia.org/wiki/Metoda_szablonowa_(wzorzec_projektowy)
/// </summary>
namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractClass classA = new ClassA();
            classA.TemplateMethod();

            Console.WriteLine();

            AbstractClass classB = new ClassB();
            classB.TemplateMethod();

            Console.ReadKey();
        }

        abstract class AbstractClass
        {
            protected void Operation1() => Console.WriteLine("Operation 1");

            protected abstract void Operation2();

            protected void Operation3() => Console.WriteLine("Operation 3");

            protected abstract void Operation4();

            public void TemplateMethod()
            {
                Operation1();
                Operation2(); 
                Operation3();
                Operation4();
            }
        }

        class ClassA : AbstractClass
        {
            protected override void Operation2()
            {
                Console.WriteLine("Operation 2 defined by ClassA");
            }

            protected override void Operation4()
            {
                Console.WriteLine("Operation 4 defined by ClassA");
            }
        }

        class ClassB : AbstractClass
        {
            protected override void Operation2()
            {
                Console.WriteLine("Operation 2 defined by ClassB");
            }

            protected override void Operation4()
            {
                Console.WriteLine("Operation 4 defined by ClassB");
            }
        }
    }
}
