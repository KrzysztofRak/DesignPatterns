using System;

/// <summary>
/// Pełnomocnik (ang. proxy) – strukturalny wzorzec projektowy, którego celem jest utworzenie obiektu zastępującego inny obiekt. 
/// Stosowany jest w celu kontrolowanego tworzenia na żądanie kosztownych obiektów oraz kontroli dostępu do nich.
/// https://pl.wikipedia.org/wiki/Pe%C5%82nomocnik_(wzorzec_projektowy)
/// </summary>
namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            ISubject subject = new ProxySubject();
            subject.Request();

            Console.ReadKey();
        }
    }

    interface ISubject
    {
        void Request();
    }

    class RealSubject : ISubject
    {
        public void Request() => Console.WriteLine("Request from RealSubject");
    }

    class ProxySubject : ISubject
    {
        private Lazy<RealSubject> _realSubject = new Lazy<RealSubject>();
        public void Request() => _realSubject.Value.Request();
    }
}
