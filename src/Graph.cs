namespace SimpleGraphing;

using System.Text;
using System.Collections.Generic;

public abstract class Graph<T, TVertex> where TVertex : Vertex<T> 
                                        where T : notnull
{
    protected Dictionary<T, TVertex> Vertices {get; set;}

    public Graph()
    {
        Vertices = new Dictionary<T, TVertex>();
    }

    /*
        public virtual void AddVertex(T name);
        public virtual void RemoveVertex(T name);
        public virtual void AddEdge(T v1, T v2);
        public virtual void RemoveEdge(T v1, T v2);
        public virtual bool AreConnected();
    */

    public TVertex this[T name]
    {
        get => Vertices[name];
    }

    public override string ToString()
    {
        StringBuilder sb = new();

        foreach (var (name, vertex) in Vertices)
        {
            sb.AppendLine(vertex.ToString());
        }

        return sb.ToString();
    }
}