using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGA
{
    public interface IReadOnlyFitnessCalculator
    {
        double CalcFitness(IReadOnlyIndividual indiv);
        double CalcFitness(IReadOnlyIndividual indiv, IReadOnlyIndividual goal);
    }
    public class FitnessCalculator : IReadOnlyFitnessCalculator
    {
        private static FitnessCalculator _instance;
        private FitnessCalculator() { }
        private static IReadOnlyConfigClass _config = ConfigClass.getInstance();

        public static FitnessCalculator getInstance()
        {
            if(_instance == null)
            {
                _instance = new FitnessCalculator();
            }

            return _instance;
        }

        public double CalcFitness(IReadOnlyIndividual indiv)
        {
            double fitness = 0;
            int len = _config.Goal.Length;
            //if (indiv.Genes.Length != len) return -1;

            for(int i = 0; i < len; ++i)
            {
                if (i > indiv.Genes.Length - 1) break;

                if (indiv.Genes[i] == _config.Goal[i])
                {
                    ++fitness;
                }
            }

            fitness = fitness / (double)len;

            return fitness;
        }

        public double CalcFitness(IReadOnlyIndividual indiv, IReadOnlyIndividual goal)
        {
            double fitness = 0;
            int len = goal.Genes.Length;
            //if (indiv.Genes.Length != len) return -1;

            for (int i = 0; i < len; ++i)
            {
                if (i > indiv.Genes.Length - 1) break;

                if (indiv.Genes[i] == goal.Genes[i])
                {
                    ++fitness;
                }
            }

            fitness = fitness / (double)len;

            return fitness;
        }
    }
}
