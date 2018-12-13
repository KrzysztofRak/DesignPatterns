using System;

/// <summary>
/// Strategia – czynnościowy wzorzec projektowy, który definiuje rodzinę wymiennych algorytmów i kapsułkuje je w postaci klas. 
/// Umożliwia wymienne stosowanie każdego z nich w trakcie działania aplikacji niezależnie od korzystających z nich użytkowników.
/// Za ilustrację może posłużyć tutaj sklep internetowy posiadający swoje oddziały w kilku krajach różniących się obowiązującymi w nich przepisami podatkowymi. 
/// Klient implementuje podstawową, wspólną dla wszystkich funkcjonalność, zaś operację naliczenia podatku deleguje do strategii zaimplementowanej dla konkretnego kraju.
/// https://pl.wikipedia.org/wiki/Strategia_(wzorzec_projektowy)
/// </summary>
namespace Strategy
{
    class Program
    {
        enum Algorithms
        {
            Algorithm1,
            Algorithm2
        }

        static void Main(string[] args)
        {
            IStrategy strategy = GetStrategy(Algorithms.Algorithm1);
            strategy.ExecuteAlgorithm("value 1");

            strategy = GetStrategy(Algorithms.Algorithm2);
            strategy.ExecuteAlgorithm("value 2");

            Console.ReadKey();
        }

        static IStrategy GetStrategy(Algorithms algorithm)
        {
            switch(algorithm)
            {
                case Algorithms.Algorithm1:
                    return new Algorithm1();
                case Algorithms.Algorithm2:
                    return new Algorithm2();
                default:
                    return new Algorithm1();
            }
        }
    }

    interface IStrategy
    {
        void ExecuteAlgorithm(string someInput);
    }

    class Algorithm1 : IStrategy
    {
        public void ExecuteAlgorithm(string someInput) =>
            Console.WriteLine($"Executing Algorithm 1 for input: {someInput}");
    }

    class Algorithm2 : IStrategy
    {
        public void ExecuteAlgorithm(string someInput) =>
            Console.WriteLine($"Executing Algorithm 2 for input: {someInput}");
    }
}
