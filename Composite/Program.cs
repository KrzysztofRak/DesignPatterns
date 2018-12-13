using System;
using System.Collections.Generic;

/// <summary>
/// Kompozyt – strukturalny wzorzec projektowy, którego celem jest składanie obiektów w taki sposób, aby klient widział wiele z nich jako pojedynczy obiekt.
/// Wzorzec ten stosuje się, gdy wygodniej jest korzystać z pewnych operacji dla danego obiektu w ten sam sposób jak dla grupy obiektów, 
/// np. rysując na ekranie prymitywy lub obiekty złożone z prymitywów; zmieniając rozmiar zarówno pojedynczych prymitywów jak i obiektów złożonych z prymitywów (z zachowaniem proporcji).
/// https://pl.wikipedia.org/wiki/Kompozyt_(wzorzec_projektowy)
/// </summary>
namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Composite composite = new Composite("First");
            composite.Add(new Composite("Second"));
            composite.Add(new Composite("Third"));

            Composite composite1 = new Composite("Forth");
            composite1.Add(new Composite("Fifth"));
            composite1.Add(new Composite("Sixth"));

            composite.Add(composite1);

            composite.DisplayAll();

            Console.ReadKey();
        }
    }

    abstract class Component
    {
        public string Name { get; set; }
        public Component(string name)
        {
            Name = name;
        }

        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract void DisplayAll(int index);
    }

    class Composite : Component
    {
        private List<Component> _children = new List<Component>();

        public Composite(string name) : base(name) { }
        public override void Add(Component component) => _children.Add(component);
        public override void Remove(Component component) => _children.Remove(component);

        public override void DisplayAll(int index = 1)
        {
            Console.WriteLine($"{new String('>', index)} - {this.Name}");
            foreach (var comp in _children)
                comp.DisplayAll(index + 1);
        }
    }
}
