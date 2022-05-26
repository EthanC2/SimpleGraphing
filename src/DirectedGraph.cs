namespace Graphing;

public class DirectedGraph : Graph
{
    public DirectedGraph(string title): base(title)
    {
        //No new members
    }

    public override void AddVertex(string name, string[]? neighbors = null)
    {
        //If vertex does not exist, create it
        Vertex v = Vertices.ContainsKey(name) ? Vertices[name] : new Vertex(name);

        //Add all the neighbors to the adjacency list of the vertex (creating if they don't exist)
        if (neighbors is not null)
        {
            foreach(string neighbor in neighbors)
            {
                if(!Vertices.ContainsKey(neighbor))
                    Vertices.Add(neighbor, new Vertex(name: neighbor));

                //Add the neighbor to the adjacency list of the vertex
                v.AddNeighbor(Vertices[neighbor]);
            }
        }

        //Add the vertex to the graph
        if (!Vertices.ContainsKey(name))
            Vertices.Add(name, v);
    }

    public override void RemoveVertex(string vertexName)
    {
        //Edge case: vertex does not exist
        if (!Vertices.ContainsKey(vertexName)) return;

        //Remove the vertex from every vertex that points to it
        Vertex v = Vertices[vertexName];
        foreach(var (name, vertex) in Vertices)
        {
            if(vertex.IsConnected(v))
                vertex.RemoveNeighbor(v);
        }

        //Remove the vertex from the graph
        Vertices.Remove(vertexName);
    }

    public override void AddEdge(string from, string to)
    {
        //Edge case: if one or both of the vertices does not exist, add them
        Vertex fromVertex = Vertices.ContainsKey(from) ? Vertices[from] : new Vertex(name: from);
        Vertex toVertex = Vertices.ContainsKey(to) ? Vertices[to] : new Vertex(name: to);

        fromVertex.AddNeighbor(toVertex);
    }

    public override void RemoveEdge(string from, string to)
    {
        //Edge case: one or both of the vertices does not exist
        if (!Vertices.ContainsKey(from) || !Vertices.ContainsKey(to)) return;

        //Remove edge 'from' -> 'to'
        Vertices[from].RemoveNeighbor(Vertices[to]);
    }
}