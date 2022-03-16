namespace SimpleGraphing;
using System.Collections.Generic;

public abstract class Graph<T, TVertex> where TVertex : Vertex<T>
{
    protected Dictionary<T, TVertex> Vertices {get; set;}

    public Graph()
    {
        Vertices = new Dictionary<T, TVertex>();
    }
}