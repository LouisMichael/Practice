public class Solution {
    public int n;
    public Node[] nodes;
    public int visitedCount;
    public int[] costs;
    public int NetworkDelayTime(int[][] times, int n, int k) {
        this.costs = new int[n];
        this.nodes = new Node[n];
        this.visitedCount = 0;
        // Console.WriteLine("test");
        for(int i = 0; i < n; i++){
            Node newNode = new Node(i, n);
            this.nodes[i] = newNode;
            this.costs[i] = Int32.MaxValue;
        }
        // Console.WriteLine("test2");
        for(int i = 0; i<times.Length;i++){
            // Console.WriteLine(times[i][0] + "," + times[i][1] + "," + times[i][2]);
            this.nodes[times[i][0]-1].contectionWeights[times[i][1]-1] = times[i][2];
        }
        // Console.WriteLine("test3");
        PriorityQueue<Node, int> queue = new PriorityQueue<Node, int>();
        queue.Enqueue(nodes[k-1], 0);
        this.costs[k-1] = 0;
        while(queue.Count > 0){
            Node temp = queue.Dequeue();
            // Console.WriteLine(temp.name);
            if(temp.visited){
                continue;
            }
            else{
                temp.visited = true;
                this.visitedCount ++;
                for(int i = 0; i < temp.contectionWeights.Length; i++){
                    if(temp.contectionWeights[i] >= 0){
                        int costToIFromCur = costs[temp.name] + temp.contectionWeights[i];
                        if(costToIFromCur < costs[i]){
                            costs[i] = costToIFromCur;
                        }
                        queue.Enqueue(nodes[i], costs[i]);
                    }
                }
            }
        }
        if(visitedCount < n){
            return -1;
        }
        int max = 0;
        for(int i = 0; i<n; i++){
            if(this.costs[i] > max){
                max = this.costs[i];
            }
        }
        return max;
    }
    public class Node {
        public int[] contectionWeights;
        public int name;
        public bool visited;
        public Node(int name, int n){
            this.name = name;
            this.contectionWeights = new int[n];
            for(int i = 0; i < n; i++){
                this.contectionWeights[i] = -1;
            }
        }
    }
}
