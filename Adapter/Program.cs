using System;

/// <summary>
/// Adapter (także: opakowanie, ang. wrapper) – strukturalny wzorzec projektowy, którego celem jest umożliwienie współpracy dwóm klasom o niekompatybilnych interfejsach. 
/// Adapter przekształca interfejs jednej z klas na interfejs drugiej klasy. Innym zadaniem omawianego wzorca jest opakowanie istniejącego interfejsu w nowy.
/// Wzorzec adaptera stosowany jest najczęściej w przypadku, gdy wykorzystanie istniejącej klasy jest niemożliwe ze względu na jej niekompatybilny interfejs. 
/// Drugim powodem użycia może być chęć stworzenia klasy, która będzie współpracowała z klasami o nieokreślonych interfejsach.
/// https://pl.wikipedia.org/wiki/Adapter_(wzorzec_projektowy)
/// </summary>
namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ITarget t = new SomeTarget();
            t.Request();

            ITarget t2 = new Adapter();
            t2.Request();

            Console.ReadKey();
        }
    }

    public interface ITarget
    {
        void Request();
    }

    public class SomeTarget : ITarget
    {
        public void Request()
        {
            Console.WriteLine("Request from SomeTarget");
        }
    }

    public interface ISomeOtherInterface
    {

    }

    public class Adaptee : ISomeOtherInterface
    {
        public void MethodFromAdaptee()
        {
            Console.WriteLine("Request from Adaptee");
        }
    }

    public class Adapter : Adaptee, ITarget
    {
        public void Request()
        {
            MethodFromAdaptee();
        }
    }
}
