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
        double Fitness { get; }
        Individual crossover(IReadOnlyIndividual i);
    }

    public class Individual : IReadOnlyIndividual
    {
        private string _genes;
        private double _fitness;
        private static IReadOnlyConfigClass _config = ConfigClass.getInstance();
        private static Random _rnd = _config.RNG;

        public Individual()
        {
            generateGenes(_config.Goal.Length);
            _fitness = -1.0d;
        }
        public Individual(string genes)
        {
            _genes = genes;
            _fitness = -1.0d;
        }
        public Individual(int size)
        {
            generateGenes(size);
            _fitness = -1.0d;
        }

        private void generateGenes(int size)
        {
            _genes = "";
            for (int i = 0; i < size; ++i)
            {
                _genes = _genes.Insert(i, Char.ToString((char)_rnd.Next(32, 127)));
            }
        }

        public Individual crossover(IReadOnlyIndividual i)
        {
            int randInt = _rnd.Next(0,this.Genes.Length);
            string lhs = this.Genes.Substring(0, randInt);
            string rhs = i.Genes.Substring(randInt);

            Individual child = new Individual(lhs+rhs);

            return child;
        }

        public void mutate()
        {
            double randDbl;
            char[] strArray = this.Genes.ToCharArray();

            for(int i = 0; i < this.Genes.Length; ++i)
            {
                randDbl = _config.RNG.NextDouble();
                if(randDbl <= _config.MutationRate)
                {
                    strArray[i] = (char)_config.RNG.Next(32, 127);
                }
            }

            this._genes = new string(strArray);
        }

        public string Genes
        {
            get { return _genes; }
        }

        public double Fitness
        {
            get { return _fitness; }
            set { _fitness = value; }
        }

        public override string ToString()
        {
            return _genes;
        }
    }
}
