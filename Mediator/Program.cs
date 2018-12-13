using System;
using System.Collections.Generic;

/// <summary>
/// Wzorzec mediatora – wzorzec projektowy należący do grupy wzorców czynnościowych. Mediator zapewnia jednolity interfejs do różnych elementów danego podsystemu.
/// Wzorzec mediatora umożliwia zmniejszenie liczby powiązań między różnymi klasami, poprzez utworzenie mediatora będącego jedyną klasą, 
/// która dokładnie zna metody wszystkich innych klas, którymi zarządza.
/// Nie muszą one nic o sobie wiedzieć, jedynie przekazują polecenia mediatorowi, a ten rozsyła je do odpowiednich obiektów.
/// https://pl.wikipedia.org/wiki/Mediator_(wzorzec_projektowy)
/// </summary>
namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Participant<string> p1 = new ConcreteParticipant<string>("p1");
            Participant<string> p2 = new ConcreteParticipant<string>("p2");
            Participant<string> p3 = new ConcreteParticipant<string>("p3");

            Mediator<string> m = new ConcreteMediator<string>();
            m.Register(p1);
            m.Register(p2);
            m.Register(p3);

            p1.SendMessage(m, "Message from p1");

            Console.ReadKey();
        }
    }

    abstract class Mediator<T>
    {
        protected List<Participant<T>> Participants = new List<Participant<T>>();
        public abstract void Register(Participant<T> p);
        public abstract void SendMessage(Participant<T> sender, T message);
    }

    abstract class Participant<T>
    {
        protected string Name;
        public Participant(string name)
        {
            this.Name = name;
        }

        public abstract void SendMessage(Mediator<T> m, T message);
        public abstract void ReceiveMessage(T message);
    }

    class ConcreteMediator<T> : Mediator<T>
    {
        public override void Register(Participant<T> p) => this.Participants.Add(p);

        public override void SendMessage(Participant<T> sender, T message) =>
            this.Participants.ForEach(p => { if (p != sender) p.ReceiveMessage(message); });
    }

    class ConcreteParticipant<T>: Participant<T>
    {
        public ConcreteParticipant(string name) : base(name) { }
        public override void ReceiveMessage(T message) => Console.WriteLine($"{Name} received: {message}");
        public override void SendMessage(Mediator<T> m, T message) => m.SendMessage(this, message);
    }
}
