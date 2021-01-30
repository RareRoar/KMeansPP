using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeansPP
{
    public interface IVector
    {
        void UpdateCoordinates(IEnumerable<double> valueCollection);
        int Dimension { get;  }
        double this[int dimention] { get; }
        double[] CoordinatesArray { get; }
    }
}
