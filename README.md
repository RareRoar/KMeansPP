# KMeansPP
The project represents an implementation of kmeans++ clustering method.
In order to achieve highest performance I have used *Parallel* class for parallel cycle iterations execution and *Vector<T>* class for SIMD-like processing.
***
IVector -- interface that defines properties and behavior for vector of double-precision floating point values.
IClusterable<T> -- interface that defines property which means T object can be assigned to a cluster of T objects (T implements IVector).
