using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGA
{
    public interface IReadOnlyPopulation : IEnumerable<Individual>
    {
        Individual GetIndividual(int idx);
        int Count { get; }
    }
    public class Population : IReadOnlyPopulation
    {
        private List<Individual> _pop;
        private static IReadOnlyConfigClass _config = ConfigClass.getInstance();

        public Population(bool init = false)
        {
            _pop = new List<Individual>();

            if (init)
            {
                Populate(_config.PopSize);
            }
        }

        public void Populate(int size)
        {
            for(int i = 0; i < size; ++i)
            {
                _pop.Add(new Individual());
            }
        }

        public void AddIndividual(Individual i)
        {
            _pop.Add(i);
        }

        public Individual GetIndividual(int idx)
        {
            return _pop.ElementAt(idx);
        }

        // PreConditions: numToSelect <= Count
        // Postconditions: A new Population that is a subset of this Population containing <numToSelect> elements is returned
        public Population SelectIndividualsAtRandom(int numToSelect)
        {
            if (numToSelect > _pop.Count) throw new IndexOutOfRangeException();

            Population subset = new Population();
            int selector = -1;
            for(int i = 0; i < numToSelect; ++i)
            {
                selector = _config.RNG.Next(0, _pop.Count);
                subset.AddIndividual( GetIndividual(selector) );
            }

            return subset;
        }

        // Select, weighted by fitness
        // Preconditions: numToSelect <= Count
        // Postconditions: A new Population that is a subset of this Population is created containing <numToSelect> elements
        public Population SelectIndividualsAtRandomWeighted(int numToSelect)
        {
            // We will use this to weight the random selection by adding index numbers multiple times to select from this list
            // These index numbers will select the Individual
            // This way we don't modify the Population
            List<int> weightedSelectionPool = new List<int>();
            // We track how fit each individual is relative to the others
            double totalFitness = 0d;
            int iter = 0;
            // Get total fitness
            foreach(IReadOnlyIndividual i in this)
            {
                totalFitness += i.Fitness;

                // We'll need this for later; happens to be a convenient location
                weightedSelectionPool.Add(iter);
                ++iter;
            }

            // Get percentage of total fitness for each Individual (minimum 0.1% to 1% area)
            iter = 0;
            foreach(IReadOnlyIndividual i in this)
            {
                double relativeFitness = i.Fitness / totalFitness;
                int instances = (int) ( Math.Ceiling(this.Count * relativeFitness) ) - 1;

                // this will weight the selections appropriately using the Individuals' indices
                for (int j = 0; j < instances; ++j)
                {
                    weightedSelectionPool.Add(iter);
                }
                ++iter;
            }

            // "Roll" for selection based on aforementioned percentages and select accordingly
            Population subset = new Population();
            IReadOnlyConfigClass config = ConfigClass.getInstance();
            for(int i = 0; i < numToSelect; ++i)
            {
                // roll
                int randIndex = config.RNG.Next(0, weightedSelectionPool.Count);
                // select
                subset.AddIndividual( this.GetIndividual(randIndex) );
            }

            return subset;
        }

        public List<Individual> ToList()
        {
            return _pop;
        }


        //Implementations from interfaces
        public int Count
        {
            get { return _pop.Count; }
        }
        // So we may iterate through Population with foreach
        public IEnumerator<Individual> GetEnumerator()
        {
            return (IEnumerator<Individual>)_pop.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
