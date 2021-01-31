using Microsoft.VisualStudio.TestTools.UnitTesting;
using KMeansPP;
using System;

namespace KMeansPPTests
{
    [TestClass]
    public class MetricsTest
    {
        private const int precision = 9;

        private double[] oneDimVectorCoordinates1 = { 0.000000001, };
        private double[] oneDimVectorCoordinates2 = { 1.618033988, };
        private double[] oneDimVectorCoordinates3 = { 1.618033989, };

        private double expectedOneDimDistance1To2 = 1.618033987;
        private double expectedOneDimDistance2To3 = 0.000000001;
        private double expectedOneDimDistance1To3 = 1.618033988;

        private double[] threeDimVectorCoordinates1 = { 0.000000001, -1024.102410240, 3.141592653 };
        private double[] threeDimVectorCoordinates2 = { 1.618033988, 2.718281828, -2001.091100000 };
        private double[] threeDimVectorCoordinates3 = { 1.618033989, -1021.384128410, -1997.949507346 };

        private double expectedThreeDimEuclidian1To2 = 2251.957379257;
        private double expectedThreeDimEuclidian2To3 = 1024.107228888;
        private double expectedThreeDimEuclidian1To3 = 2001.093600406;

        private double expectedThreeDimManhattan1To2 = 3032.671418708;
        private double expectedThreeDimManhattan2To3 = 1027.244002893;
        private double expectedThreeDimManhattan1To3 = 2005.427415817;

        private double expectedThreeDimChebyshev1To2 = 2004.232692653;
        private double expectedThreeDimChebyshev2To3 = 1024.102410238;
        private double expectedThreeDimChebyshev1To3 = 2001.091099999;

        [TestMethod]
        public void EuclidianTest()
        {
            var oneDimVector1 = new ClusterableVector(oneDimVectorCoordinates1);
            var oneDimVector2 = new ClusterableVector(oneDimVectorCoordinates2);
            var oneDimVector3 = new ClusterableVector(oneDimVectorCoordinates3);

            var oneDimDistance1To1 = Metrics.Euclidian(oneDimVector1, oneDimVector1);
            var oneDimDistance2To2 = Metrics.Euclidian(oneDimVector2, oneDimVector2);
            var oneDimDistance3To3 = Metrics.Euclidian(oneDimVector3, oneDimVector3);
            
            var oneDimDistance1To2 = Metrics.Euclidian(oneDimVector1, oneDimVector2);
            var oneDimDistance2To3 = Metrics.Euclidian(oneDimVector2, oneDimVector3);
            var oneDimDistance1To3 = Metrics.Euclidian(oneDimVector1, oneDimVector3);

            var oneDimDistance2To1 = Metrics.Euclidian(oneDimVector1, oneDimVector2);
            var oneDimDistance3To2 = Metrics.Euclidian(oneDimVector2, oneDimVector3);
            var oneDimDistance3To1 = Metrics.Euclidian(oneDimVector1, oneDimVector3);

            //axiom of identity
            Assert.AreEqual(oneDimDistance1To1, 0.0);
            Assert.AreEqual(oneDimDistance2To2, 0.0);
            Assert.AreEqual(oneDimDistance3To3, 0.0);

            //axiom of symmetry
            Assert.AreEqual(oneDimDistance1To2, oneDimDistance2To1);
            Assert.AreEqual(oneDimDistance2To3, oneDimDistance3To2);
            Assert.AreEqual(oneDimDistance1To3, oneDimDistance3To1);

            //axiom of triangle
            Assert.IsTrue(oneDimDistance1To3 <= oneDimDistance1To2 + oneDimDistance2To3);

            //expectation
            Assert.AreEqual(Math.Round(oneDimDistance1To2, 9), expectedOneDimDistance1To2);
            Assert.AreEqual(Math.Round(oneDimDistance2To3, 9), expectedOneDimDistance2To3);
            Assert.AreEqual(Math.Round(oneDimDistance1To3, 9), expectedOneDimDistance1To3);


            var threeDimVector1 = new ClusterableVector(threeDimVectorCoordinates1);
            var threeDimVector2 = new ClusterableVector(threeDimVectorCoordinates2);
            var threeDimVector3 = new ClusterableVector(threeDimVectorCoordinates3); 
            
            var threeDimDistance1To1 = Metrics.Euclidian(threeDimVector1, threeDimVector1);
            var threeDimDistance2To2 = Metrics.Euclidian(threeDimVector2, threeDimVector2);
            var threeDimDistance3To3 = Metrics.Euclidian(threeDimVector3, threeDimVector3);

            var threeDimDistance1To2 = Metrics.Euclidian(threeDimVector1, threeDimVector2);
            var threeDimDistance2To3 = Metrics.Euclidian(threeDimVector2, threeDimVector3);
            var threeDimDistance1To3 = Metrics.Euclidian(threeDimVector1, threeDimVector3);

            var threeDimDistance2To1 = Metrics.Euclidian(threeDimVector1, threeDimVector2);
            var threeDimDistance3To2 = Metrics.Euclidian(threeDimVector2, threeDimVector3);
            var threeDimDistance3To1 = Metrics.Euclidian(threeDimVector1, threeDimVector3);

            //axiom of identity
            Assert.AreEqual(threeDimDistance1To1, 0.0);
            Assert.AreEqual(threeDimDistance2To2, 0.0);
            Assert.AreEqual(threeDimDistance3To3, 0.0);

            //axiom of symmetry
            Assert.AreEqual(threeDimDistance1To2, threeDimDistance2To1);
            Assert.AreEqual(threeDimDistance2To3, threeDimDistance3To2);
            Assert.AreEqual(threeDimDistance1To3, threeDimDistance3To1);

            //axiom of triangle
            Assert.IsTrue(threeDimDistance1To3 <= threeDimDistance1To2 + threeDimDistance2To3);

            //expectation
            Assert.AreEqual(Math.Round(threeDimDistance1To2, precision), expectedThreeDimEuclidian1To2);
            Assert.AreEqual(Math.Round(threeDimDistance2To3, precision), expectedThreeDimEuclidian2To3);
            Assert.AreEqual(Math.Round(threeDimDistance1To3, precision), expectedThreeDimEuclidian1To3);
        }

        [TestMethod]
        public void ManhattanTest()
        {
            var oneDimVector1 = new ClusterableVector(oneDimVectorCoordinates1);
            var oneDimVector2 = new ClusterableVector(oneDimVectorCoordinates2);
            var oneDimVector3 = new ClusterableVector(oneDimVectorCoordinates3);

            var oneDimDistance1To1 = Metrics.Manhattan(oneDimVector1, oneDimVector1);
            var oneDimDistance2To2 = Metrics.Manhattan(oneDimVector2, oneDimVector2);
            var oneDimDistance3To3 = Metrics.Manhattan(oneDimVector3, oneDimVector3);

            var oneDimDistance1To2 = Metrics.Manhattan(oneDimVector1, oneDimVector2);
            var oneDimDistance2To3 = Metrics.Manhattan(oneDimVector2, oneDimVector3);
            var oneDimDistance1To3 = Metrics.Manhattan(oneDimVector1, oneDimVector3);

            var oneDimDistance2To1 = Metrics.Manhattan(oneDimVector1, oneDimVector2);
            var oneDimDistance3To2 = Metrics.Manhattan(oneDimVector2, oneDimVector3);
            var oneDimDistance3To1 = Metrics.Manhattan(oneDimVector1, oneDimVector3);

            //axiom of identity
            Assert.AreEqual(oneDimDistance1To1, 0.0);
            Assert.AreEqual(oneDimDistance2To2, 0.0);
            Assert.AreEqual(oneDimDistance3To3, 0.0);

            //axiom of symmetry
            Assert.AreEqual(oneDimDistance1To2, oneDimDistance2To1);
            Assert.AreEqual(oneDimDistance2To3, oneDimDistance3To2);
            Assert.AreEqual(oneDimDistance1To3, oneDimDistance3To1);

            //axiom of triangle
            Assert.IsTrue(oneDimDistance1To3 <= oneDimDistance1To2 + oneDimDistance2To3);

            //expectation
            Assert.AreEqual(Math.Round(oneDimDistance1To2, precision), expectedOneDimDistance1To2);
            Assert.AreEqual(Math.Round(oneDimDistance2To3, precision), expectedOneDimDistance2To3);
            Assert.AreEqual(Math.Round(oneDimDistance1To3, precision), expectedOneDimDistance1To3);

            var threeDimVector1 = new ClusterableVector(threeDimVectorCoordinates1);
            var threeDimVector2 = new ClusterableVector(threeDimVectorCoordinates2);
            var threeDimVector3 = new ClusterableVector(threeDimVectorCoordinates3);

            var threeDimDistance1To1 = Metrics.Manhattan(threeDimVector1, threeDimVector1);
            var threeDimDistance2To2 = Metrics.Manhattan(threeDimVector2, threeDimVector2);
            var threeDimDistance3To3 = Metrics.Manhattan(threeDimVector3, threeDimVector3);

            var threeDimDistance1To2 = Metrics.Manhattan(threeDimVector1, threeDimVector2);
            var threeDimDistance2To3 = Metrics.Manhattan(threeDimVector2, threeDimVector3);
            var threeDimDistance1To3 = Metrics.Manhattan(threeDimVector1, threeDimVector3);

            var threeDimDistance2To1 = Metrics.Manhattan(threeDimVector1, threeDimVector2);
            var threeDimDistance3To2 = Metrics.Manhattan(threeDimVector2, threeDimVector3);
            var threeDimDistance3To1 = Metrics.Manhattan(threeDimVector1, threeDimVector3);

            //axiom of identity
            Assert.AreEqual(threeDimDistance1To1, 0.0);
            Assert.AreEqual(threeDimDistance2To2, 0.0);
            Assert.AreEqual(threeDimDistance3To3, 0.0);

            //axiom of symmetry
            Assert.AreEqual(threeDimDistance1To2, threeDimDistance2To1);
            Assert.AreEqual(threeDimDistance2To3, threeDimDistance3To2);
            Assert.AreEqual(threeDimDistance1To3, threeDimDistance3To1);

            //axiom of triangle
            Assert.IsTrue(threeDimDistance1To3 <= threeDimDistance1To2 + threeDimDistance2To3);

            //expectation
            Assert.AreEqual(Math.Round(threeDimDistance1To2, precision), expectedThreeDimManhattan1To2);
            Assert.AreEqual(Math.Round(threeDimDistance2To3, precision), expectedThreeDimManhattan2To3);
            Assert.AreEqual(Math.Round(threeDimDistance1To3, precision), expectedThreeDimManhattan1To3);
        }
        [TestMethod]
        public void ChebyshevTest()
        {
            var oneDimVector1 = new ClusterableVector(oneDimVectorCoordinates1);
            var oneDimVector2 = new ClusterableVector(oneDimVectorCoordinates2);
            var oneDimVector3 = new ClusterableVector(oneDimVectorCoordinates3);

            var oneDimDistance1To1 = Metrics.Chebyshev(oneDimVector1, oneDimVector1);
            var oneDimDistance2To2 = Metrics.Chebyshev(oneDimVector2, oneDimVector2);
            var oneDimDistance3To3 = Metrics.Chebyshev(oneDimVector3, oneDimVector3);

            var oneDimDistance1To2 = Metrics.Chebyshev(oneDimVector1, oneDimVector2);
            var oneDimDistance2To3 = Metrics.Chebyshev(oneDimVector2, oneDimVector3);
            var oneDimDistance1To3 = Metrics.Chebyshev(oneDimVector1, oneDimVector3);

            var oneDimDistance2To1 = Metrics.Chebyshev(oneDimVector1, oneDimVector2);
            var oneDimDistance3To2 = Metrics.Chebyshev(oneDimVector2, oneDimVector3);
            var oneDimDistance3To1 = Metrics.Chebyshev(oneDimVector1, oneDimVector3);

            //axiom of identity
            Assert.AreEqual(oneDimDistance1To1, 0.0);
            Assert.AreEqual(oneDimDistance2To2, 0.0);
            Assert.AreEqual(oneDimDistance3To3, 0.0);

            //axiom of symmetry
            Assert.AreEqual(oneDimDistance1To2, oneDimDistance2To1);
            Assert.AreEqual(oneDimDistance2To3, oneDimDistance3To2);
            Assert.AreEqual(oneDimDistance1To3, oneDimDistance3To1);

            //axiom of triangle
            Assert.IsTrue(oneDimDistance1To3 <= oneDimDistance1To2 + oneDimDistance2To3);

            //expectation
            Assert.AreEqual(Math.Round(oneDimDistance1To2, precision), expectedOneDimDistance1To2);
            Assert.AreEqual(Math.Round(oneDimDistance2To3, precision), expectedOneDimDistance2To3);
            Assert.AreEqual(Math.Round(oneDimDistance1To3, precision), expectedOneDimDistance1To3);


            var threeDimVector1 = new ClusterableVector(threeDimVectorCoordinates1);
            var threeDimVector2 = new ClusterableVector(threeDimVectorCoordinates2);
            var threeDimVector3 = new ClusterableVector(threeDimVectorCoordinates3);

            var threeDimDistance1To1 = Metrics.Chebyshev(threeDimVector1, threeDimVector1);
            var threeDimDistance2To2 = Metrics.Chebyshev(threeDimVector2, threeDimVector2);
            var threeDimDistance3To3 = Metrics.Chebyshev(threeDimVector3, threeDimVector3);

            var threeDimDistance1To2 = Metrics.Chebyshev(threeDimVector1, threeDimVector2);
            var threeDimDistance2To3 = Metrics.Chebyshev(threeDimVector2, threeDimVector3);
            var threeDimDistance1To3 = Metrics.Chebyshev(threeDimVector1, threeDimVector3);

            var threeDimDistance2To1 = Metrics.Chebyshev(threeDimVector1, threeDimVector2);
            var threeDimDistance3To2 = Metrics.Chebyshev(threeDimVector2, threeDimVector3);
            var threeDimDistance3To1 = Metrics.Chebyshev(threeDimVector1, threeDimVector3);

            //axiom of identity
            Assert.AreEqual(threeDimDistance1To1, 0.0);
            Assert.AreEqual(threeDimDistance2To2, 0.0);
            Assert.AreEqual(threeDimDistance3To3, 0.0);

            //axiom of symmetry
            Assert.AreEqual(threeDimDistance1To2, threeDimDistance2To1);
            Assert.AreEqual(threeDimDistance2To3, threeDimDistance3To2);
            Assert.AreEqual(threeDimDistance1To3, threeDimDistance3To1);

            //axiom of triangle
            Assert.IsTrue(threeDimDistance1To3 <= threeDimDistance1To2 + threeDimDistance2To3);

            //expectation
            Assert.AreEqual(Math.Round(threeDimDistance1To2, precision), expectedThreeDimChebyshev1To2);
            Assert.AreEqual(Math.Round(threeDimDistance2To3, precision), expectedThreeDimChebyshev2To3);
            Assert.AreEqual(Math.Round(threeDimDistance1To3, precision), expectedThreeDimChebyshev1To3);
        }

    }
}
