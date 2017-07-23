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
