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
            //1. Initialize
            Population p = new Population(true);

            //2. Evaluate
            calc.CalcFitness(p);
            //Now we should sort the population
            // TODO: DECIDE ON IMPLEMENTING SORT CODE
                // OPTIONALLY WE CAN JUST SEARCH FOR MOST FIT, NO SORTS

            //3. Reproduce (and create new 'generation' -- population)
                //1. Select
                // TODO: DECIDE ON SELECTION IMPLEMENTATION
                // CONSIDER: Pick a pair from ten competitors, using fitness as a scalar, to reproduce (can't be the same!)
                //2. Crossover
                // TODO: IMPLEMENT CROSSOVER
                //3. Mutate
                // TODO: IMPLEMENT MUTATE
                //4. Repeat

            //4. Repeat with new generation
            foreach(Individual i in p)
            {
                Console.WriteLine("{0} | {1}", i, i.Fitness);
            }

            Console.ReadKey();
        }
    }
}
