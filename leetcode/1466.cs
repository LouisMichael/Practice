public class Solution {
    public int MinReorder(int n, int[][] connections) {
        // since the structure is a tree  I think we just root it at 0 and walk it flipping any in the wrong direction
        List<int>[] connectionGrid = new List<int>[n];
        for(int i =0; i<n;i++){
            connectionGrid[i] = new List<int>();
        }
        for(int i =0; i<connections.Length;i++){
            connectionGrid[connections[i][0]].Add(-connections[i][1]);
            connectionGrid[connections[i][1]].Add(connections[i][0]);
        }
        Queue<int> dfsQueue =  new Queue<int>();
        dfsQueue.Enqueue(0);
        HashSet<int> visited = new HashSet<int>();
        int ret = 0;
        while(dfsQueue.Count > 0){
            int cur = dfsQueue.Dequeue();
            if(visited.Contains(cur)){
                continue;
            }
            visited.Add(cur);
            for(int i = 0; i<connectionGrid[cur].Count;i++){
                if(!visited.Contains(connectionGrid[cur][i]) && !visited.Contains(-connectionGrid[cur][i])){
                    if(connectionGrid[cur][i] < 0){
                        dfsQueue.Enqueue(-connectionGrid[cur][i]);
                        ret++;
                    }
                    else{
                        dfsQueue.Enqueue(connectionGrid[cur][i]);
                    }
                }
            }
        }
        return ret;
    }
    
    
}
