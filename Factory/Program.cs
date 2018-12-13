using System;

/// <summary>
/// Fabryka abstrakcyjna (ang. Abstract Factory) – kreacyjny wzorzec projektowy, którego celem jest dostarczenie interfejsu do tworzenia różnych obiektów jednego typu (tej samej rodziny) 
/// bez specyfikowania ich konkretnych klas[1]. Umożliwia jednemu obiektowi tworzenie różnych, powiązanych ze sobą, reprezentacji podobiektów określając ich typy podczas działania programu[2]. 
/// Fabryka abstrakcyjna różni się od Budowniczego tym, że kładzie nacisk na tworzenie produktów z konkretnej rodziny, a Budowniczy kładzie nacisk na sposób tworzenia obiektów[3].
/// Rozpatrzmy aplikację kliencką, która łączy się ze zdalnym serwerem. Celem projektanta takiej aplikacji jest to, aby była ona przenośna. 
/// Jednym z rozwiązań takiego problemu jest stworzenie fabryki, która będzie tworzyła odpowiednie obiekty w zależności od tego na jakiej platformie się znajduje[4][5][6].
/// https://pl.wikipedia.org/wiki/Fabryka_abstrakcyjna_(wzorzec_projektowy)
/// </summary>
namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            MiddlewareFactory middlewareFactory = new MiddlewareFactory();
            IMiddleware middleware = middlewareFactory.GetMiddleware(1);
            middleware.DoAction();

            middleware = middlewareFactory.GetMiddleware(2);
            middleware.DoAction();

            Console.ReadKey();
        }
    }

    public interface IMiddleware
    {
        void DoAction();
    }

    public class Middleware1 : IMiddleware
    {
        public void DoAction()
        {
            Console.WriteLine("Executing action from Middleware1");
        }
    }

    public class Middleware2 : IMiddleware
    {
        public void DoAction()
        {
            Console.WriteLine("An action from Middleware2");
        }
    }

    public class MiddlewareFactory
    {
        public IMiddleware GetMiddleware(int which)
        {
            switch(which)
            {
                case 1: return new Middleware1();
                case 2: return new Middleware2();
                default: return new Middleware1();
            }
        }
    }
}
