using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGA
{
    public interface IReadOnlyIndividual
    {
        string Genes { get; }
    }

    public class Individual : IReadOnlyIndividual
    {
        private string _genes;
        private static IReadOnlyConfigClass _config = ConfigClass.getInstance();
        private static Random _rnd = new Random();

        public Individual()
        {
            generateGenes(_config.Goal.Length);
        }
        public Individual(string genes)
        {
            _genes = genes;
        }
        public Individual(int size)
        {
            generateGenes(size);
        }

        private void generateGenes(int size)
        {
            _genes = "";
            for (int i = 0; i < size; ++i)
            {
                _genes = _genes.Insert(i, Char.ToString((char)_rnd.Next(32, 127)));
            }
        }

        public string Genes
        {
            get { return _genes; }
        }

        public override string ToString()
        {
            return _genes;
        }
    }
}
