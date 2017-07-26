using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGA
{
    class Program
    {
        static void Main(string[] args)
        {
            IReadOnlyFitnessCalculator calc = FitnessCalculator.getInstance();
            ConfigClass config = ConfigClass.getInstance();
            const int TOURNEY_SIZE = 10;
            //1. Initialize
            Population p = new Population(true);

            //2. Evaluate
            calc.CalcFitness(p);
            //Now we should sort the population
            // TODO: DECIDE ON IMPLEMENTING SORT CODE
                // OPTIONALLY WE CAN JUST SEARCH FOR MOST FIT, NO SORTS

            //3. Reproduce (and create new 'generation' -- population); each generation will make a new generation of equivalent size (for now)
            for(int i = 0; i < config.PopSize; ++i)
            {
                //1. Select
                // TODO: DECIDE ON SELECTION IMPLEMENTATION
                // CONSIDER: Pick a pair from ten competitors, using fitness as a scalar, to reproduce (can't be the same!)
                // CONSIDER: HOW WILL WE DO THIS?
                Population tournamentPop = p.SelectIndividualsAtRandom(TOURNEY_SIZE);
                //2. Crossover;
                // TODO: IMPLEMENT CROSSOVER
                //3. Mutate
                // TODO: IMPLEMENT MUTATE
                //4. Repeat
            }

            //4. Repeat with new generation

            //Console.ReadKey();
        }
    }
}
