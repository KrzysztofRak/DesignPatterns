using System;

/// <summary>
/// Fasada – wzorzec projektowy należący do grupy wzorców strukturalnych. Służy do ujednolicenia dostępu do złożonego systemu poprzez wystawienie uproszczonego, 
/// uporządkowanego interfejsu programistycznego, który ułatwia jego użycie.
/// Przykładem użycia wzorca fasady może być aplikacja bankomatowa, która musi wchodzić w interakcję z systemem bankowym. 
/// Skoro aplikacja bankomatowa wykorzystuje tylko niewielką część możliwości systemu bankowego (autoryzacja karty, sprawdzenie stanu konta, wypłata i ew. wpłata), 
/// to można zastosować obiekt fasady, który zasłoni przed zewnętrznymi aplikacjami skomplikowaną strukturę wewnętrzną systemu bankowego. 
/// Upraszcza to pisanie aplikacji na bankomaty, a jednocześnie zapewnia lepsze bezpieczeństwo systemu bankowego.
/// https://pl.wikipedia.org/wiki/Fasada_(wzorzec_projektowy)
/// </summary>
namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();
            facade.CallOperationsUnified();

            Console.ReadKey();
        }
    }

    class ClassOne
    {
        public void OperationFromOne() => Console.WriteLine("Operation from Class One");
    }

    class ClassTwo
    {
        public void OperationFromTwo() => Console.WriteLine("Operation from Class Two");
    }

    class ClassThree
    {
        public void OperationFromThree() => Console.WriteLine("Operation from Class Three");
    }

    class Facade
    {
        private ClassOne _one;
        private ClassTwo _two;
        private ClassThree _three;

        public Facade()
        {
            _one = new ClassOne();
            _two = new ClassTwo();
            _three = new ClassThree();
        }

        public void CallOperationsUnified()
        {
            _one.OperationFromOne();
            _two.OperationFromTwo();
            _three.OperationFromThree();
        }
    }
}
