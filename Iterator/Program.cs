using System;
using System.Collections;

/// <summary>
/// Iterator – czynnościowy wzorzec projektowy (obiektowy), którego celem jest zapewnienie sekwencyjnego dostępu do podobiektów zgrupowanych w większym obiekcie.
/// https://pl.wikipedia.org/wiki/Iterator_(wzorzec_projektowy)
/// </summary>
namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Aggregate<Iterator> ag = new Aggregate<Iterator>();
            ag[0] = "A";
            ag[1] = "B";
            ag[2] = "C";

            Iterator it = ag.CreateIterator() as Iterator;

            object item = it.First();
            while(item != null)
            {
                Console.WriteLine(item);
                item = it.Next();
            }


            Console.ReadKey();
        }
    }

    interface IIterator
    {
        object First();
        object Next();
        bool IsDone();
        object CurrentItem();
        void SetAggregate(IAggregate ag);
    }

    interface IAggregate
    {
        IIterator CreateIterator();
        int Count();
        object this[int index] { get;set; }
    }

    class Iterator : IIterator
    {
        private IAggregate _aggregate;
        private int _current = 0;

        public Iterator() { }
        public void SetAggregate(IAggregate ag) => this._aggregate = ag;
        public object First() => _aggregate[0];
        public object Next() => (_current < _aggregate.Count() - 1) ? _aggregate[++_current] : null;
        public object CurrentItem() => _aggregate[_current];
        public bool IsDone() => _current >= _aggregate.Count();
    }

    class Aggregate<T> : IAggregate where T : IIterator, new()
    {
        private ArrayList _items = new ArrayList();

        public IIterator CreateIterator()
        {
            IIterator a = new T();
            a.SetAggregate(this);
            return a;
        }

        public int Count() => _items.Count;

        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value);  }
        }
    }
}
