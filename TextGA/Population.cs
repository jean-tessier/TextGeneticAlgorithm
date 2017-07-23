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
        List<Individual> ToList();
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

        public List<Individual> ToList()
        {
            return _pop;
        }

        public IEnumerator<Individual> GetEnumerator()
        {
            return (IEnumerator<Individual>)_pop;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)_pop;
        }
    }
}
