namespace SimpleGraphing;

using System.Collections.Generic;

public class Vertex<T>
{
    public T Name {get; init;} 
    protected HashSet<Vertex<T>> Neighbors {get; set;}

    public Vertex(T name)
    {
        Name = name;
        Neighbors = new HashSet<Vertex<T>>();        
    }
    
    public virtual void AddNeighbor(params Vertex<T>[] vertices)
    {
        foreach (var vertex in vertices)
        {
            Neighbors.Add(vertex);
        }
    }

    public virtual void RemoveNeighbor(params Vertex<T>[] vertices)
    {
        foreach (var vertex in vertices)
        {
            Neighbors.Remove(vertex);
        }
    }

    public virtual bool AreConnected(Vertex<T> from, Vertex<T> to)
    {
        return from.Neighbors.Contains(to) || to.Neighbors.Contains(from);
    }

    public override string ToString()
    {
        // "Name: vertex1, vertex2, vertex3"
        return $"{Name}: {String.Join(", ", Neighbors.Select(v => v.Name).ToArray())}";
    }
}