using System;
using System.Collections.Generic;
using System.Linq;

namespace KattisProblemC
{
    class Program
    {
        static void Main(string[] args)
        {
            int loopAmount;
            do
            {
                loopAmount = int.Parse(Console.ReadLine());
                List<string> unitsList = new List<string>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None));
                Dictionary<string, Node> nodes = new Dictionary<string, Node>();
                foreach(string s in unitsList)
                {
                    Node n = new Node(s);
                    nodes.Add(s, n);
                }
                for (int i = 0; i < loopAmount - 1; i++)
                {

                    string[] inputSplit = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None);
                    Edge e1 = new Edge(false, int.Parse(inputSplit[2]), nodes.GetValueOrDefault(inputSplit[3]));
                    nodes.GetValueOrDefault(inputSplit[0]).edges.Add(e1);


                    Edge e2 = new Edge(true, int.Parse(inputSplit[2]), nodes.GetValueOrDefault(inputSplit[0]));
                    nodes.GetValueOrDefault(inputSplit[3]).edges.Add(e2);

   
                }

                WeightedBFS(nodes, GetOrigin(nodes));
                PrintUnits(nodes);
                
                
            } while (loopAmount != 0);
        }

        private static Node GetOrigin(Dictionary<string, Node> nodes)
        {
            Node n = null;

            foreach(KeyValuePair<string, Node> pair in nodes)
            {
                foreach(Edge e in pair.Value.edges)
                {
                    if (e.backwards)
                    {
                        break;
                    }
                    else
                    {
                        n = pair.Value;
                    }
                        
                }
            }

            Console.WriteLine(n.unit);
            return n;
        }

        private static void PrintUnits(Dictionary<string, Node> nodes)
        {
            var sortedDict = from entry in nodes orderby entry.Value.distance ascending select entry;
            KeyValuePair<string, Node> last = sortedDict.Last();
            string res = "";

            foreach(KeyValuePair<string, Node> n in sortedDict)
            {
                if(n.Value != last.Value)
                {
                    res += n.Value.distance + n.Value.unit + " = ";
                }
                else
                {
                    res += n.Value.distance + n.Value.unit;
                }
            }

            Console.WriteLine(res);
        }

        private static void WeightedBFS(Dictionary<string, Node> nodes, Node origin)
        {
            foreach(Node n in nodes.Values)
            {
                n.distance = int.MinValue;
            }

            Queue<Node> q = new Queue<Node>();
            origin.distance = 1;
            q.Enqueue(origin);
            while(q.Count != 0)
            {
                Node current = q.Dequeue();

                foreach(Edge e in current.edges)
                {
                    if(e.node.distance == int.MinValue)
                    {
                        if (e.backwards)
                        {
                            e.node.distance = current.distance / e.weight;
                        } else
                        {
                            e.node.distance = current.distance * e.weight;
                        }

                        q.Enqueue(e.node);
                    }
                }
            }
        }

        private class Node
        {

            public string unit;
            public List<Edge> edges;
            public int distance;
            public Node(string s)
            {
                unit = s;
                edges = new List<Edge>();
            }

            

            
        }



        private class Edge
        {
            public bool backwards;
            public int weight;
            public Node node;

            public Edge(bool t, int w, Node n)
            {
                backwards = t;
                weight = w;
                node = n;
            }
        }

    }
}
