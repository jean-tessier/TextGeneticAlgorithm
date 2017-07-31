using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGA
{
    class Program
    {
        const int TOURNEY_SIZE = 10;
        static IReadOnlyFitnessCalculator calc;
        static ConfigClass config;

        static void Main(string[] args)
        {
            calc = FitnessCalculator.getInstance();
            config = ConfigClass.getInstance();
            //1. Initialize
            Population p = new Population(true);
            
            //4. Repeat with new generation

            //Console.ReadKey();
        }

        static Population GenerationStep(Population p)
        {
            Population nextGeneration = new Population();

            //2. Evaluate
            calc.CalcFitness(p);
            //Now we should sort the population
            // TODO: DECIDE ON IMPLEMENTING SORT CODE
            // OPTIONALLY WE CAN JUST SEARCH FOR MOST FIT, NO SORTS

            //3. Reproduce (and create new 'generation' -- population); each generation will make a new generation of equivalent size (for now)
            for (int i = 0; i < config.PopSize; ++i)
            {
                //1. Select
                Population tournamentPop = p.SelectIndividualsAtRandom(TOURNEY_SIZE);
                Population partners = p.SelectIndividualsAtRandomWeighted(2);
                //2. Crossover;
                Individual child = partners.GetIndividual(0).crossover(partners.GetIndividual(1));
                //3. Mutate
                child.mutate();
                //4. Repeat
            }

            return nextGeneration;
        }
    }
}
