using System;

/// <summary>
/// Dekorator – wzorzec projektowy należący do grupy wzorców strukturalnych. Pozwala na dodanie nowej funkcji do istniejących klas dynamicznie podczas działania programu.
/// Wzorzec dekoratora polega na opakowaniu oryginalnej klasy w nową klasę "dekorującą". Zwykle przekazuje się oryginalny obiekt jako parametr konstruktora dekoratora, 
/// metody dekoratora wywołują metody oryginalnego obiektu i dodatkowo implementują nową funkcję. Dekoratory są alternatywą dla dziedziczenia.
/// Dziedziczenie rozszerza zachowanie klasy w trakcie kompilacji, w przeciwieństwie do dekoratorów, które rozszerzają klasy w czasie działania programu.
/// https://pl.wikipedia.org/wiki/Dekorator_(wzorzec_projektowy)
/// </summary>
namespace Dekorator
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteComponent comp = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA(comp);
            ConcreteDecoratorB d2 = new ConcreteDecoratorB(d1);

            comp.Operation();
            d1.Operation();
            d2.Operation();

            Console.ReadKey();
        }
    }

    interface IComponent
    {
        void Operation();
    }

    class ConcreteComponent : IComponent
    {
        public void Operation() => Console.WriteLine("Operation from ConcreteComponent");

    }

    abstract class Decorator : IComponent
    {
        protected IComponent component;

        public Decorator(IComponent comp)
        {
            component = comp;
        }

        public virtual void Operation() => component?.Operation();
    }

    class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(IComponent comp) : base(comp) { }
        public override void Operation()
        {
            base.Operation();
            AddedBehaviour();
            Console.WriteLine("Operation from ConcreteDecoratorA");
        }

        void AddedBehaviour() => Console.Write("(AddedBehaviour A) + ");
    }

    class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(IComponent comp) : base(comp) { }
        public override void Operation()
        {
            base.Operation();
            AddedBehaviour();
            Console.WriteLine("Operation from ConcreteDecoratorB");
        }

        void AddedBehaviour() => Console.Write("(AddedBehaviour B) + ");
    }
}
