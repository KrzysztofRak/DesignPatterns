using System;

/// <summary>
/// Wzorzec mostu (ang. Bridge pattern) – strukturalny wzorzec projektowy, który pozwala oddzielić abstrakcję obiektu od jego implementacji. 
/// Zaleca się stosowanie tego wzorca aby: 
/// - odseparować implementację od interfejsu, 
/// - poprawić możliwości rozbudowy klas, zarówno implementacji, jak i interfejsu (m.in. przez dziedziczenie), 
/// - ukryć implementację przed klientem, co umożliwia zmianę implementacji bez zmian interfejsu.
/// https://pl.wikipedia.org/wiki/Most_(wzorzec_projektowy)
/// </summary>
namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            Abstraction abstraction = new DerivedAbstraction();
            abstraction.Implementor = new ConcreteImplementorA();
            abstraction.Operation();

            abstraction.Implementor = new ConcreteImplementorB();
            abstraction.Operation();

            Console.ReadKey();
        }
    }

    class Abstraction
    {
        public IImplementor Implementor { get; set; }

        public virtual void Operation() => Implementor.Method();
    }

    class DerivedAbstraction : Abstraction
    {
        public override void Operation() => Implementor.Method();
    }

    interface IImplementor
    {
        void Method();
    }

    class ConcreteImplementorA : IImplementor
    {
        public void Method() => Console.WriteLine("Method called from ConcreteImplementorA");
    }

    class ConcreteImplementorB : IImplementor
    {
        public void Method() => Console.WriteLine("Method called from ConcreteImplementorB");
    }
}
