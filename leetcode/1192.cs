public class Solution {
//     maybe when BFS is conducted if we count how many times a node would attempt to be visited we can see if a node is only attempted once? I don't think this will work
//     There are too many connections to try removing each one?
//     you can try to find a route to each side of a connection that is not that connection and if it is not possible that is a critical connection
//     if a node is only mentioned once it is going to be a critical connection
//     is there a way to build up the network so as we expand we can test?
//     the absolute min is a line, then every extra connection will make 1 or 2 connections redundent?
    // when we add a dup we make one redundent and when we make a triange we make two non critical? This is not true
// any time you make a cycle you make everything in the cycle non criticle
//     Should I just try to add connections and if I make a cycle I can cross all of those connections off the list?
//     when I do a bfs I can keep track of every time I try to visit when I have already been visited, in these cases if they are not directly connected the set of nodes that were used in this search are in a cycle and I can give them a color/merge them into a set
    public Node[] nodeList;
    public HashSet<(int,int)> possibleCrit;
    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections) {
//         connect all the nodes
//         DFS, if you are at a node that has already been visited go through all the connections until you got to the last time you were at this node, none of those connections are criticle unless they were the last visited node
//         This idea ended up being too slow
        
        this.nodeList = new Node[n];
        this.possibleCrit = new HashSet<(int,int)>();
        for(int i = 0; i<n; i++){
            this.nodeList[i] = new Node(i);
        }
        
        for(int i = 0; i < connections.Count; i++){
            this.nodeList[connections[i][0]].connections.Add(connections[i][1]);
            this.nodeList[connections[i][1]].connections.Add(connections[i][0]);
            this.possibleCrit.Add((connections[i][0],connections[i][1]));
        }
        this.DfsWithHistory(this.nodeList[0], new Stack(), -1);
        IList<IList<int>> ret = new List<IList<int>>();
        foreach((int,int) crit in this.possibleCrit){
            IList<int> critConnection = new List<int>();
            critConnection.Add(crit.Item1);
            critConnection.Add(crit.Item2);
            ret.Add(critConnection);
        }
        return ret;
    }
    
    public void DfsWithHistory(Node cur, Stack history, int lastVisited){
        if(cur.visited){
            int last = cur.name;  
            Stack historyClone = (Stack)history.Clone();
            while((int)historyClone.Peek() != cur.name){
                  int historyTop = (int)historyClone.Pop();
                // Console.WriteLine("removing:" + historyTop + "-" + last);
                this.possibleCrit.Remove((last,historyTop));
                this.possibleCrit.Remove((historyTop,last));
                last = historyTop;
              }
            return;
        }
        history.Push(cur.name);
        cur.visited = true;
        foreach(int connection in cur.connections){
            if(connection != lastVisited){
                this.DfsWithHistory(this.nodeList[connection], history, cur.name);
            }
        }
        history.Pop();
        cur.visited = false;
        return;
    }
    
    public class Node{
        public HashSet<int> connections;
        public int name;
        public bool visited;
        public Node(int name){
            this.name = name;
            this.connections = new HashSet<int>();
            this.visited = false;
        }
    }
}
