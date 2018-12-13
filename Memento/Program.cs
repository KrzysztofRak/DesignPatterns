using System;
using System.Collections.Generic;

/// <summary>
/// Pamiątka (ang. Memento) – czynnościowy wzorzec projektowy. Jego zadaniem jest zapamiętanie i udostępnienie 
/// na zewnątrz wewnętrznego stanu obiektu bez naruszania hermetyzacji. Umożliwia to przywracanie zapamiętanego stanu obiektu.
/// Pamiątka może zostać wykorzystana w procesorze tekstu do zaimplementowania operacji "Cofnij" oraz "Ponów". 
/// Za każdym razem kiedy użytkownik wykonuje jakąś akcję – wprowadza tekst, zmienia wielkość czcionki czy jej kolor
/// – tworzony jest obiekt pamiątki zapamiętujący bieżący stan dokumentu. 
/// Gdy użytkownik zleci wycofanie ostatniej operacji, stan dokumentu zostanie odtworzony za pomocą wcześniej zapisanej pamiątki.
/// https://pl.wikipedia.org/wiki/Pami%C4%85tka_(wzorzec_projektowy)
/// </summary>
namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Originator<StateObject> current = new Originator<StateObject>();
            current.SetState(new StateObject { Id = 1, Name = "Object 1" });
            CareTaker<StateObject>.SaveState(current);
            current.ShowState();

            current.SetState(new StateObject { Id = 2, Name = "Object 2" });
            CareTaker<StateObject>.SaveState(current);
            current.ShowState();

            current.SetState(new StateObject { Id = 3, Name = "Object 3" });
            CareTaker<StateObject>.SaveState(current);
            current.ShowState();

            CareTaker<StateObject>.RestoreState(current, 0);
            current.ShowState();

            Console.ReadKey();
        }
    }

    public class StateObject : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public object Clone()
        {
            return new StateObject
            {
                Id = this.Id,
                Name = this.Name
            };
        }

        public override string ToString()
        {
            return $"Id: {this.Id}, Name: {this.Name}";
        }
    }

    public class Memento<T> where T : ICloneable
    {
        private T StateObj { get; set; }

        public T GetState()
        {
            return StateObj;
        }

        public void SetState(T stateObj)
        {
            StateObj = (T)stateObj.Clone();
        }
    }

    public class Originator<T> where T : ICloneable
    {
        private T StateObj { get; set; }

        public Memento<T> CreateMemento()
        {
            Memento<T> m = new Memento<T>();
            m.SetState(this.StateObj);
            return m;
        }

        public void RestoreMemento(Memento<T> m)
        {
            this.StateObj = m.GetState();
        }

        public void SetState(T state)
        {
            this.StateObj = state;
        }

        public void ShowState()
        {
            Console.WriteLine(this.StateObj.ToString());
        }
    }

    public static class CareTaker<T> where T : ICloneable
    {
        private static List<Memento<T>> mementoList = new List<Memento<T>>();

        public static void SaveState(Originator<T> orig)
        {
            mementoList.Add(orig.CreateMemento());
        }

        public static void RestoreState(Originator<T> orig, int checkpoint)
        {
            orig.RestoreMemento(mementoList[checkpoint]);
        }
    }
}
