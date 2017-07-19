using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGA
{
    public interface IReadOnlyConfigClass
    {
        string Goal { get; }
        int PopSize { get; }
    }

    public class ConfigClass : IReadOnlyConfigClass
    {
        private static string _defaultGoal = "Hello World!";
        private static int _popSize = 500;
        private static ConfigClass _instance = null;
        private ConfigClass() { }

        public static ConfigClass getInstance()
        {
            if (_instance == null)
            {
                _instance = new ConfigClass();
            }

            return _instance;
        }

        public string Goal
        {
            get { return _defaultGoal; }
        }
        public int PopSize
        {
            get { return _popSize; }
        }
    }
}
