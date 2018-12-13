using System;

/// <summary>
/// Łańcuch zobowiązań (ang. Chain of responsibility) – czynnościowy wzorzec projektowy, w którym żądanie może być przetwarzane przez różne obiekty, w zależności od jego typu.
/// Wzorzec znajduje zastosowanie wszędzie tam, gdzie mamy do czynienia z różnymi mechanizmami podobnych żądań, które można zaklasyfikować do różnych kategorii. 
/// Dodatkową motywacją do jego użycia są często zmieniające się wymagania.
/// https://pl.wikipedia.org/wiki/%C5%81a%C5%84cuch_zobowi%C4%85za%C5%84_(wzorzec_projektowy)
/// </summary>
namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Handler h = InitializeHandler();

            foreach (var i in new int[] { 3, 4, 6, 11, 12 })
                h.HandleRequest(i);

            Console.ReadKey();
        }

        static Handler InitializeHandler()
        {
            Handler h1 = new ConcreteHandler("Handler 1");
            h1.Condition = value => value >= 0 && value < 5;

            Handler h2 = new ConcreteHandler("Handler 2");
            h2.Condition = value => value >= 5 && value < 10;

            Handler h3 = new ConcreteHandler("Handler 3");
            h3.Condition = value => value >= 10 && value < 15;

            h1.Successor = h2;
            h2.Successor = h3;

            return h1;
        }
    }

    abstract class Handler
    {
        protected string Name;
        public Func<int, bool> Condition;
        public Handler Successor { get; set; }

        public Handler(string name)
        {
            this.Name = name;
        }
        public abstract void HandleRequest(int value);
    }

    class ConcreteHandler : Handler
    {
        public ConcreteHandler(string name) : base(name) { }

        public override void HandleRequest(int value)
        {
            if (Condition(value))
                Console.WriteLine($"{this.Name} handled the value {value}");
            else
                this.Successor.HandleRequest(value);

        }
    }
}
