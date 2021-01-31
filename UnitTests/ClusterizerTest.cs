using Microsoft.VisualStudio.TestTools.UnitTesting;
using KMeansPP;
using System.Collections.Generic;
using System.IO;
using System;

namespace KMeansPPTests
{
    [TestClass]
    public class ClusterizerTest
    {
        private const int defaultCentroidCount = 5;
        private const double acceptableNegSilhouetteCoeffPercent = 5.0;

        private string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        private IEnumerable<ClusterableVector> GetVectorsFromFile(string relativePath)
        {
            string[] fileLines = File.ReadAllLines(relativePath);
            ClusterableVector[] vectorArray = new ClusterableVector[fileLines.Length];
            for(int i = 0; i < fileLines.Length; i++)
            {
                var strVector = fileLines[i].Split(new char[] { ' ', }, StringSplitOptions.RemoveEmptyEntries);
                vectorArray[i] = new ClusterableVector(strVector);
            }
            return vectorArray;
        }

        [TestMethod]
        public void IrrelevantArgsTest()
        {
            ClusterableVector[] defaultVectorCollection = new ClusterableVector[defaultCentroidCount];
            for (int i = 0; i < defaultVectorCollection.Length; i++)
            {
                defaultVectorCollection[i] = new ClusterableVector(new double[] { 1.0 });
            }
            Assert.ThrowsException<ArgumentException>(() => {
                new KMeansPPClusterizer<ClusterableVector>(0, defaultVectorCollection, Metrics.Euclidian);
            });
            Assert.ThrowsException<ArgumentException>(() => {
                new KMeansPPClusterizer<ClusterableVector>(defaultCentroidCount, defaultVectorCollection, Metrics.Euclidian, 0);
            });
            Assert.ThrowsException<ArgumentException>(() => {
                new KMeansPPClusterizer<ClusterableVector>(defaultCentroidCount + 1, defaultVectorCollection, Metrics.Euclidian);
            });
        }

        [TestMethod]
        public void MarginalArgsTest()
        {
            ClusterableVector[] defaultVectorCollection = new ClusterableVector[defaultCentroidCount];
            for (int i = 0; i < defaultVectorCollection.Length; i++)
            {
                defaultVectorCollection[i] = new ClusterableVector(new double[] { (double)i });
            }
            var clusterizer1 = new KMeansPPClusterizer<ClusterableVector>(1, defaultVectorCollection, Metrics.Euclidian);
            Assert.IsNotNull(clusterizer1.GetClusters());

            ClusterableVector[] trivialVectorCollection = new ClusterableVector[defaultCentroidCount];
            for (int i = 0; i < trivialVectorCollection.Length; i++)
            {
                trivialVectorCollection[i] = new ClusterableVector(new double[] { 1.0 });
            }
            var clusterizer2 = new KMeansPPClusterizer<ClusterableVector>(defaultCentroidCount, trivialVectorCollection, Metrics.Euclidian);
            Assert.IsNotNull(clusterizer2.GetClusters());
        }

        [TestMethod]
        public void Sample1KTest()
        {
            var clusterizer = new KMeansPPClusterizer<ClusterableVector>(defaultCentroidCount,
                GetVectorsFromFile(projectDirectory + "\\samples\\sample1.txt"),
                Metrics.Euclidian);
            Assert.IsNotNull(clusterizer.GetClusters());
            double negSilhouetteCoeffPercent;
            Assert.IsTrue(clusterizer.PerformSilhouetteAnalysis(out negSilhouetteCoeffPercent));
            Assert.IsTrue(negSilhouetteCoeffPercent < acceptableNegSilhouetteCoeffPercent);
        }
        [TestMethod]
        public void Sample10KTest()
        {
            var clusterizer = new KMeansPPClusterizer<ClusterableVector>(defaultCentroidCount,
                GetVectorsFromFile(projectDirectory + "\\samples\\sample2.txt"),
                Metrics.Euclidian);
            Assert.IsNotNull(clusterizer.GetClusters());
            double negSilhouetteCoeffPercent;
            Assert.IsTrue(clusterizer.PerformSilhouetteAnalysis(out negSilhouetteCoeffPercent));
            Assert.IsTrue(negSilhouetteCoeffPercent < acceptableNegSilhouetteCoeffPercent);
        }
    }
}
