using System;

/// <summary>
/// Prototyp – kreacyjny wzorzec projektowy, którego celem jest umożliwienie tworzenia obiektów danej klasy bądź klas 
/// z wykorzystaniem już istniejącego obiektu, zwanego prototypem. Głównym celem tego wzorca jest uniezależnienie systemu od sposobu w jaki tworzone są w nim produkty.
/// Omawiany wzorzec stosujemy między innymi wtedy, gdy nie chcemy tworzyć w budowanej aplikacji podklas obiektu budującego (jak to jest w przypadku wzorca fabryki abstrakcyjnej). 
/// Wzorzec ten stosujemy podczas stosowania klas specyfikowanych podczas działania aplikacji.
/// https://pl.wikipedia.org/wiki/Prototyp_(wzorzec_projektowy)
/// </summary>
namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var prototype = new ConcretePrototype1
            {
                Property1 = "A",
                Property2 = "B",
                PrototypeDetails = new PrototypeDetails { Details = "prototype details" }
            };

            var NewObject = prototype.Clone() as ConcretePrototype1;
            NewObject.PrototypeDetails.Details = "New details for 'NewObject'";

            Console.WriteLine(prototype);
            Console.WriteLine(NewObject);


            var prototype2 = new ConcretePrototype2
            {
                Property1 = "X",
                Property2 = "Y",
                OtherProperty = "Z",
                PrototypeDetails = new PrototypeDetails { Details = "prototype2 details" }
            };

            var NewObject2 = prototype2.Clone() as ConcretePrototype2;
            NewObject2.PrototypeDetails.Details = "New details for 'NewObject2'";

            Console.WriteLine(prototype2);
            Console.WriteLine(NewObject2);

            Console.ReadKey();
        }
    }

    public abstract class Prototype : ICloneable
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }

        public PrototypeDetails PrototypeDetails { get; set; }

        public abstract object Clone();

        public override string ToString() => $"Property1:{Property1} Property2:{Property2} PrototypeDetails:{PrototypeDetails }";
    }

    public class PrototypeDetails
    {
        public string Details { get; set; }

        public override string ToString() => this.Details;
    }

    public class ConcretePrototype1 : Prototype
    {
        public override object Clone()
        {
            return new ConcretePrototype1
            {
                Property1 = this.Property1,
                Property2 = this.Property2,
                PrototypeDetails = new PrototypeDetails { Details = this.PrototypeDetails.Details }
            };
        }
    }

    public class ConcretePrototype2 : Prototype
    {
        public string OtherProperty { get; set; }

        public override object Clone()
        {
            return new ConcretePrototype2
            {
                Property1 = this.Property1,
                Property2 = this.Property2,
                PrototypeDetails = new PrototypeDetails { Details = this.PrototypeDetails.Details },
                OtherProperty = this.OtherProperty
            };
        }

        public override string ToString() => $"{base.ToString()} OtherProperty:{this.OtherProperty}";
    }
}
