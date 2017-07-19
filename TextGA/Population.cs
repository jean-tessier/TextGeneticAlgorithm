using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGA
{
    public class Population
    {
        private List<IReadOnlyIndividual> _pop;
        private static IReadOnlyConfigClass _config = ConfigClass.getInstance();

        public Population(bool init = false)
        {
            _pop = new List<IReadOnlyIndividual>();

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

        public void AddIndividual(IReadOnlyIndividual i)
        {
            _pop.Add(i);
        }

        public IReadOnlyIndividual GetIndividual(int idx)
        {
            return _pop.ElementAt(idx);
        }

        public List<IReadOnlyIndividual> ToList()
        {
            return _pop;
        }
    }
}
