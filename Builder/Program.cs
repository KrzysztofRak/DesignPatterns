using System;
using System.Collections.Generic;

/// <summary>
/// Budowniczy (ang. Builder) – kreacyjny wzorzec projektowy, którego celem jest rozdzielenie sposobu tworzenia obiektów od ich reprezentacji. 
/// Innymi słowy proces tworzenia obiektu podzielony jest na kilka mniejszych etapów a każdy z tych etapów może być implementowany na wiele sposobów. 
/// Dzięki takiemu rozwiązaniu możliwe jest tworzenie różnych reprezentacji obiektów w tym samym procesie konstrukcyjnym: 
/// sposób tworzenia obiektów zamknięty jest w oddzielnych obiektach zwanych Konkretnymi Budowniczymi. 
/// Zazwyczaj stosowany jest do konstrukcji obiektów złożonych, których konfiguracja i inicjalizacja jest procesem wieloetapowym.
/// Wzorzec budowniczego stosowany jest do oddzielenia sposobu tworzenia obiektów od tego jak te obiekty mają wyglądać
/// https://pl.wikipedia.org/wiki/Budowniczy_(wzorzec_projektowy)
/// </summary>
namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();

            IBuilder b1 = new ConcreteBuilder1();
            IBuilder b2 = new ConcreteBuilder2();

            director.Construct(b1);
            Console.WriteLine(b1.GetProduct());

            director.Construct(b2);
            Console.WriteLine(b2.GetProduct());

            Console.ReadKey();
        }
    }

    public class Director
    {
        public void Construct(IBuilder builder) => builder.BuildParts();
    }

    public interface IBuilder
    {
        void BuildParts();
        Product GetProduct();
    }

    public class ConcreteBuilder1 : IBuilder
    {
        private Product _product = new Product();
        public void BuildParts()
        {
            _product.AddComponents(new List<IComponent> { new ConcreteComponent1("Comp1"), new ConcreteComponent2("Comp2") });
        }

        public Product GetProduct() => _product;
    }

    public class ConcreteBuilder2 : IBuilder
    {
        private Product _product = new Product();
        public void BuildParts()
        {
            _product.AddComponents(new List<IComponent> { new ConcreteComponent1("A"), new ConcreteComponent2("B"), new ConcreteComponent2("C") });
        }

        public Product GetProduct() => _product;
    }

    public class Product
    {
        private List<IComponent> _components = new List<IComponent>();

        public void AddComponents(List<IComponent> comps) => _components.AddRange(comps);
        public override string ToString() => "Product components:" + string.Join("", _components);
    }

    public interface IComponent { }

    public class ConcreteComponent1 : IComponent
    {
        private string _name;

        public ConcreteComponent1(string name)
        {
            _name = name;
        }

        public override string ToString() => this.GetType().Name + "[" + _name + "]";
    }

    public class ConcreteComponent2 : IComponent
    {
        private string _name;

        public ConcreteComponent2(string name)
        {
            _name = name;
        }

        public override string ToString() => this.GetType().Name + "[" + _name + "]";
    }
}
