using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphing;

//Class vertex represents a vertex in a graph.
public class Vertex
{
    //Data members
    public string Name {get; init;}
    private HashSet<Vertex> Neighbors {get; set;}

    //Special methods
    public Vertex(string name, params Vertex[] neighbors)
    {
        Name = name;
        Neighbors = new HashSet<Vertex>(neighbors);
    }

    public void AddNeighbor(params Vertex[] vertices)
    {
        foreach(Vertex v in vertices)
            Neighbors.Add(v);    //idempotent operation
    }

    public void RemoveNeighbor(params Vertex[] vertices)
    {
        foreach(Vertex v in vertices)
            Neighbors.Remove(v);  //does not throw if key is not found
    }

    public void RemoveConnections()
    {
        foreach(Vertex v in Neighbors)
            v.RemoveNeighbor(this);
    }

    //Methods
    public bool IsConnected(Vertex v)
    {
        return Neighbors.Contains(v);
    }

    public override string ToString()
    {
        return $"{Name}: {String.Join(", ", Neighbors.Select(n => n.Name).ToArray())}";
    }

    public string ToGephiCSV()
    {
        return $"{Name};{String.Join(";", Neighbors.Select(v => v.Name).ToArray())}";
    }
}