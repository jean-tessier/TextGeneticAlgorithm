using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextGA;

namespace TextGATest
{
    [TestClass]
    public class PopulationObjectTests
    {
        [TestMethod]
        public void PopulationPopulateTest()
        {
            Population test = new Population();
            int size = 10;
            test.Populate(size);
            Assert.AreEqual(size, test.ToList().Count);
            foreach ( IReadOnlyIndividual i in test.ToList() )
            {
                Assert.AreNotEqual(null, i);
                Assert.AreEqual(-1.0d, i.Fitness);
            }
        }

        [TestMethod]
        public void PopulationAddGetTest()
        {
            Population test = new Population();
            Individual i = new Individual("Hello World!");
            test.AddIndividual(i);
            Assert.AreEqual(i, test.GetIndividual(0));
        }
    }

    [TestClass]
    public class IndividualObjectTests
    {
        [TestMethod]
        public void NewIndividualTest()
        {
            //arrange
            int len = 10;
            Individual test = new Individual(len);
            //act
            //assert
            Assert.AreEqual(len, test.Genes.Length);
            Assert.AreEqual(-1.0d, test.Fitness);
        }
    }

    [TestClass]
    public class ConfigClassTests
    {
        [TestMethod]
        public void ConfigClassGetGoalTest()
        {
            IReadOnlyConfigClass test = ConfigClass.getInstance();
            string goal = test.Goal;
            Assert.AreEqual("Hello World!", goal);
        }

        [TestMethod]
        public void ConfigClassGetPopSizeTest()
        {
            IReadOnlyConfigClass test = ConfigClass.getInstance();
            int size = test.PopSize;
            Assert.AreEqual(500, size);
        }
    }
    
    [TestClass]
    public class FitnessCalcTests
    {
        [TestMethod]
        public void FitnessCalculationTest()
        {
            IReadOnlyFitnessCalculator test = FitnessCalculator.getInstance();
            IReadOnlyIndividual indiv = new Individual("Hello World!");
            IReadOnlyIndividual halfIndiv = new Individual("Hello ");
            IReadOnlyIndividual goal = new Individual("Hello World!");

            double fitness = test.CalcFitness(indiv, goal);
            double halfFitness = test.CalcFitness(halfIndiv, goal);
            Assert.AreEqual(1.0d, fitness);
            Assert.AreEqual(0.5d, halfFitness);
        }
    }
}
