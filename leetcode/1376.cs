public class Solution {
    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime) {
        // bfs fits the idea of this problem well so lets use that, it is a little acward because we want to know children not parents 
        // but we can just flip this with one pass to another strucutre
        List<int>[] children = new List<int>[n];
        for(int i = 0; i<n;i++){
            int man = manager[i];
            if(man == -1){
                continue;
            }
            if(children[man] == null){
                children[man] = new List<int>();
            }
            children[man].Add(i);
        }
        int max = 0;
        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((headID, 0));
        while(queue.Count > 0){
            (int, int) cur = queue.Dequeue();
            int newTime = cur.Item2 + informTime[cur.Item1];
            max  = Math.Max(max, newTime);
            if(children[cur.Item1] != null){
                foreach(int child in children[cur.Item1]){
                    queue.Enqueue((child, newTime));
                }
            }
        }
        return max;
    }
}
