using System;

/// <summary>
/// Singleton – kreacyjny wzorzec projektowy, którego celem jest ograniczenie możliwości tworzenia obiektów danej klasy 
/// do jednej instancji oraz zapewnienie globalnego dostępu do stworzonego obiektu. 
/// Niekiedy wzorzec uogólnia się do przypadku wprowadzenia pewnej maksymalnej liczby obiektów, jakie mogą istnieć w systemie.
/// Niektórzy programiści uznają go za antywzorzec, ponieważ łamie zasady projektowania obiektowego, często bywa nadużywany 
/// lub sprowadza się do stworzenia obiektowego zamiennika dla zmiennej globalnej.
/// https://pl.wikipedia.org/wiki/Singleton_(wzorzec_projektowy)
/// </summary>
namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.SingleInstance;
            Singleton s2 = Singleton.SingleInstance;
            Singleton s3 = Singleton.SingleInstance;

            ThreadSafeSingleton tss1 = ThreadSafeSingleton.SingleInstance;
            ThreadSafeSingleton tss2 = ThreadSafeSingleton.SingleInstance;
            ThreadSafeSingleton tss3 = ThreadSafeSingleton.SingleInstance;

            Console.ReadKey();
        }
    }

    public sealed class Singleton
    {
        private static Singleton _instance = null;
        private int randomNumber;

        private Singleton() {
            randomNumber = new Random().Next(int.MinValue, int.MaxValue);
        }

        public static Singleton SingleInstance
        {
            get
            {
                if (_instance == null)
                    _instance = new Singleton();

                Console.WriteLine(_instance.randomNumber);
                return _instance;
            }
        }

        public void PrintCreationTimestamp()
        {
            
        }
    }

    public sealed class ThreadSafeSingleton
    {
        private static ThreadSafeSingleton _instance = null;
        private long randomNumber;
        private static readonly object _lock = new object();

        ThreadSafeSingleton()
        {
            randomNumber = new Random().Next(int.MinValue, int.MaxValue);
        }

        public static ThreadSafeSingleton SingleInstance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new ThreadSafeSingleton();

                    Console.WriteLine(_instance.randomNumber);
                    return _instance;
                }
            }
        }
    }
}

