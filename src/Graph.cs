namespace SimpleGraphing;
using System.Collections.Generic;

public abstract class Graph<T, TVertex> where TVertex : Vertex<T>
{
    protected Dictionary<T, TVertex> Vertices {get; set;}

    public abstract void AddVertex(T name);
    public abstract void RemoveVertex(T name);
    public abstract void AddEdge(T from, T to);
    public abstract void RemoveEdge(T from, T to);
    
    public Graph()
    {
        Vertices = new Dictionary<T, TVertex>();
    }
}