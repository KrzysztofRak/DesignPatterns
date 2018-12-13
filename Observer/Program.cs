using System;
using System.Collections.Generic;

/// <summary>
/// Obserwator (ang. observer) – wzorzec projektowy należący do grupy wzorców czynnościowych. 
/// Używany jest do powiadamiania zainteresowanych obiektów o zmianie stanu pewnego innego obiektu.
/// https://pl.wikipedia.org/wiki/Obserwator_(wzorzec_projektowy)
/// </summary>
namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new ConcreteSubject("ABC");
            subject.AttachRange(new List<Observer>
            {
                new ConcreteObserver("o1"),
                new ConcreteObserver("o2"),
                new ConcreteObserver("o3")
            });

            subject.SetState("XYZ");
            Console.ReadKey();
        }

    }

    abstract class Observer
    {
        public abstract void Update(string state);
    }

    abstract class Subject
    {
        protected string SubjectState;
        protected List<Observer> Observers = new List<Observer>();
        public virtual void Attach(Observer o) => Observers.Add(o);
        public virtual void AttachRange(List<Observer> o) => Observers.AddRange(o);
        public virtual void Dettach(Observer o) => Observers.Remove(o);
        public abstract void SetState(string state);
        protected virtual void Notify() => Observers.ForEach(o => o.Update(this.SubjectState));
    }

    class ConcreteSubject: Subject
    {
        public ConcreteSubject(string state)
        {
            SetState(state);
        }

        public override void SetState(string state)
        {
            if(this.SubjectState != state)
            {
                this.SubjectState = state;
                Notify();
            }
        }
    }

    class ConcreteObserver: Observer
    {
        private string Name;

        public ConcreteObserver(string name)
        {
            this.Name = name;
        }

        public override void Update(string state) =>
                Console.WriteLine($"Observer {Name} notified. New subject state: {state}");
    }
}
