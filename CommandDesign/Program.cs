using System;

/// <summary>
/// Polecenie (ang. Command, komenda) – czynnościowy wzorzec projektowy, traktujący żądanie wykonania określonej czynności jako obiekt, 
/// dzięki czemu mogą być one parametryzowane w zależności od rodzaju odbiorcy, a także umieszczane w kolejkach i dziennikach.
/// Wzorzec znajduje zastosowanie wszędzie tam, gdzie musimy zapamiętywać wykonywane operacje lub je wycofywać. 
/// https://pl.wikipedia.org/wiki/Polecenie_(wzorzec_projektowy)
/// </summary>
namespace CommandDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            Receiver r = new Receiver();
            Command c = new ConcreteCommand(r);
            Invoker invoker = new Invoker(c);
            invoker.ExecuteCommand();

            Console.ReadKey();
        }
    }

    class Receiver
    {
        public void Action() => Console.WriteLine("Called Receiver.Action()");
    }

    abstract class Command
    {
        protected Receiver Receiver;
        public Command(Receiver receiver)
        {
            this.Receiver = receiver;
        }

        public abstract void Execute();
    }

    class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) : base(receiver) { }

        public override void Execute() => Receiver.Action();
    }

    class Invoker
    {
        private Command _command;

        public Invoker(Command command)
        {
            this._command = command;
        }

        public void ExecuteCommand() => _command.Execute();
    }



}
