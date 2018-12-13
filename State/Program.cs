using System;

/// <summary>
/// Stan – czynnościowy wzorzec projektowy, który umożliwia zmianę zachowania obiektu poprzez zmianę jego stanu wewnętrznego. 
/// Innymi słowy – uzależnia sposób działania obiektu od stanu w jakim się aktualnie znajduje.
/// Do plusów korzystania z tego wzorca należy możliwość łatwego dodawania kolejnych narzędzi.
/// https://pl.wikipedia.org/wiki/Stan_(wzorzec_projektowy)
/// </summary>
namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            CommState1 comm1 = new CommState1();
            Context context = new Context(comm1);
            context.Request();
            context.Request();
            comm1.SimulateConnectionLoss();
            context.Request();
            context.Request();

            Console.ReadKey();
        }
    }

    abstract class State
    {
        protected bool isConnected = true;
        public virtual void SimulateConnectionLoss() => isConnected = false;
        public abstract void Handle(Context context);
    }

    class CommState1 : State
    {
        public override void Handle(Context context)
        {
            if (!this.isConnected)
                context.State = new CommState2();
        }
    }

    class CommState2 : State
    {
        public override void Handle(Context context)
        {
            if (!this.isConnected)
                context.State = new CommState1();
        }
    }

    class Context
    {
        public State State { get; set; }

        public Context(State state)
        {
            this.State = state;
        }

        public void Request()
        {
            State.Handle(this);
            Console.WriteLine($"Using communication object: {State.GetType().Name}");
        }
    }
}
