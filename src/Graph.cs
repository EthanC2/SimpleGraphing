using System.Text;
using System.Collections.Generic;

namespace Graphing;

//Class graph represents an undirected graph as a collection of vertices
public class Graph
{
    //Data members
    public string Title {get; init;}
    protected Dictionary<string, Vertex> Vertices {get; set;}

    public Graph(string title)
    {
        Title = title;
        Vertices = new Dictionary<string, Vertex>();
    }

    public virtual void AddVertex(string name, string[] neighbors)
    {
        Vertex v = Vertices.ContainsKey(name) ? Vertices[name] : new Vertex(name);
        
        foreach(string neighbor in neighbors)
        {
            if(!Vertices.ContainsKey(neighbor))
                Vertices.Add(neighbor, new Vertex(name: neighbor));
            
            //Add both vertices
            Vertices[neighbor].AddNeighbor(v);
            v.AddNeighbor(Vertices[neighbor]);
        }

        if (!Vertices.ContainsKey(name))
            Vertices.Add(name, v);
    } 

    public virtual void RemoveVertex(string vertexName)
    {
        var vertex = Vertices[vertexName];
        vertex.RemoveConnections();
        Vertices.Remove(vertexName);
    }

    public virtual void AddEdge(string v1, string v2)
    {
        Vertex vertex1 = Vertices[v1];
        Vertex vertex2 = Vertices[v2];

        vertex1.AddNeighbor(vertex2);
        vertex2.AddNeighbor(vertex1);
    }

    public virtual void RemoveEdge(string v1, string v2)
    {
        Vertex vertex1 = Vertices[v1];
        Vertex vertex2 = Vertices[v2];

        vertex1.RemoveNeighbor(vertex2);
        vertex2.RemoveNeighbor(vertex1);
    }

    public bool AreConnected(string v1, string v2)
    {
        return Vertices[v1].IsConnected(Vertices[v2]);
    }

    public override string ToString()
    {
       StringBuilder sb = new();
    
       sb.AppendLine($"Graph: {Title}");
       foreach(var (name, vertex) in Vertices)
       {
           sb.AppendLine(vertex.ToString());
       }

       return sb.ToString(); 
    }

    //Operator overloads
    public Vertex this[string vertexName]
    {
        get => Vertices[vertexName]; 
    }

    public async Task ToGephiCSVAsync(string filename)
    {
        using (var file = new StreamWriter(filename))
        {
            foreach(Vertex v in Vertices.Values)
                await file.WriteLineAsync(v.ToGephiCSV());
        }
    } 
}