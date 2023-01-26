public class Solution {
    // I think this will just be dystra with an extra constraint
    // we will want to explore the cheapest routes first but if we are at k stops we can not expand our
    // search from this node
    // we can do this with a custom sorted priority queue holding tuple or a second queue that has the stops count
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        Dictionary<int,Node> dict = new Dictionary<int,Node>();
        for(int i =0; i<n;i++){
            dict[i] = new Node(i);
        }
        for(int i =0; i<flights.Length;i++){
            dict[flights[i][0]].connections.Add((dict[flights[i][1]], flights[i][2]));
        }
        PriorityQueue<(Node, int), int> queue = new PriorityQueue<(Node, int), int>();
        queue.Enqueue((dict[src],0), 0);
        Dictionary<int, int> visited = new Dictionary<int, int>();
        while(queue.Count > 0){
            queue.TryDequeue(out (Node, int) cur, out int priority);
            Node curNode = cur.Item1;
            int curDistance = priority;
            int curHops = cur.Item2;
            // Console.WriteLine(curNode.name);
            if(dst == curNode.name){
                return curDistance;
            }
            if(curHops == k+1 || (visited.ContainsKey(curNode.name)&&visited[curNode.name]<curHops)){
                continue;
            }
            visited[curNode.name] = curHops;
            foreach((Node, int) connection in curNode.connections){
                queue.Enqueue((connection.Item1, curHops +1), connection.Item2 + curDistance);
            }
        }
        return -1;
    }
    public class Node{
        public List<(Node,int)> connections;
        public int name;
        public Node(int name){
            this.connections = new List<(Node,int)>();
            this.name = name;
        }
    }
}
