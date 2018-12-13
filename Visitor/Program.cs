using System;
using System.Collections.Generic;

/// <summary>
/// Odwiedzający (wizytator) – wzorzec projektowy, którego zadaniem jest odseparowanie algorytmu od struktury obiektowej na której operuje. 
/// Praktycznym rezultatem tego odseparowania jest możliwość dodawania nowych operacji do aktualnych struktur obiektów bez konieczności ich modyfikacji.
/// We wzorcu projektowym wprowadzony zostaje nowy typ obiektu Wizytator, którego zadaniem jest "odwiedzenie" każdego elementu w danej strukturze obiektów 
/// i wykonanie na nim konkretnych działań. Różne implementacje wizytatorów mogą wykonywać różne zadania, rozszerzając funkcjonalność struktury elementów bez ich wewnętrznej modyfikacji.
/// https://pl.wikipedia.org/wiki/Odwiedzaj%C4%85cy
/// </summary>
namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectStructure o = new ObjectStructure();
            o.Attach(new Element1());
            o.Attach(new Element2());

            var v1 = new Visitor1();
            var v2 = new Visitor2();

            o.Accept(v1);
            o.Accept(v2);

            Console.ReadKey();
        }
    }

    abstract class AbstractVisitor
    {
        public virtual void VisitElement<T>(T element) where T : Element
        {
            Console.WriteLine($"{element.GetType().Name} visited by {this.GetType().Name}");
        }
    }

    class Visitor1 : AbstractVisitor { }

    class Visitor2 : AbstractVisitor
    {
        public override void VisitElement<T>(T element)
        {
            Console.WriteLine($"{element.GetType().Name} visited by {this.GetType().Name} with override behaviour");
        }
    }

    abstract class Element
    {
        public abstract void Accept(AbstractVisitor visitor);
    }

    class Element1 : Element
    {
        public override void Accept(AbstractVisitor visitor)
        {
            visitor.VisitElement(this);
        }

        public void OperationA() { }
    }

    class Element2 : Element
    {
        public override void Accept(AbstractVisitor visitor)
        {
            visitor.VisitElement(this);
        }

        public void OperationB() { }
    }

    class ObjectStructure
    {
        private List<Element> _elements = new List<Element>();

        public void Attach(Element element)
        {
            _elements.Add(element);
        }

        public void Detach(Element element)
        {
            _elements.Remove(element);
        }

        public void Accept(AbstractVisitor visitor)
        {
            foreach(Element element in _elements)
            {
                element.Accept(visitor);
            }
        }
    }
}
