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
}