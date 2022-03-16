namespace SimpleGraphing;

using System.Collections.Generic;

public class Vertex<T>
{
    public T Name {get; init;} 
    public HashSet<Vertex<T>> Neighbors {get; protected set;}

    public Vertex(T name)
    {
        Name = name;
        Neighbors = new HashSet<Vertex<T>>();        
    }

    public override string ToString()
    {
        // "Name: vertex1, vertex2, vertex3"
        return $"{Name}: {String.Join(", ", Neighbors.Select(v => v.Name).ToArray())}";
    }
}