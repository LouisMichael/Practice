public class Solution {
    public int CutOffTree(IList<IList<int>> forest) {
//         I think this is just a complex way to say find the distance between the spaces in order, maybe we can get a little fancy and store the connections in a way to not need to spend time re finding connections
//         there may be a meet in the middle step that is good but I want to maybe start with a pretty slow, dystras approch
        Dictionary<int, (int,int)> treeHeightToTreePos = new Dictionary<int, (int,int)>();
        List<int> treeHeights = new List<int>();
        for(int i =0; i<forest.Count; i++){
            for(int j = 0; j<forest[i].Count;j++){
                int curHeight = forest[i][j];
                if(curHeight > 1){
                    treeHeights.Add(curHeight);
                    treeHeightToTreePos[curHeight] = (i, j);
                }
            }
        }
        treeHeights.Sort();
        (int,int) start = (0,0);
        int ret = 0;
        foreach(int height in treeHeights){
            // Console.WriteLine(height);
            int distance = dfs(start.Item1, start.Item2, treeHeightToTreePos[height].Item1, treeHeightToTreePos[height].Item2, forest);
            if(distance >= 0){
                ret += distance;
            }
            else{
                return -1;
            }
            start = treeHeightToTreePos[height];
        }
        return ret;
    }
    public int dfs (int startX, int startY, int goalX, int goalY, IList<IList<int>> forest){
        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((startX, startY));
        (int,int)[] offsets = {(1,0),(-1,0),(0,1),(0,-1)};
        int distance = 0;
        HashSet<(int,int)> visited = new HashSet<(int,int)>();
        while(queue.Count > 0){
            int curSize = queue.Count;
            for(int i = 0; i<curSize; i++){
                (int, int) cur = queue.Dequeue();
                // Console.WriteLine(cur);
                if(cur.Item1 == goalX && cur.Item2 == goalY){
                    return distance;
                }
                foreach((int,int)direction in offsets){
                    int newX = cur.Item1 + direction.Item1;
                    int newY = cur.Item2 + direction.Item2;
                    if(newX >= 0 && newX < forest.Count && newY >= 0 && newY < forest[newX].Count && !visited.Contains((newX,newY))){
                        if(forest[newX][newY] > 0){
                            queue.Enqueue((newX,newY));
                            visited.Add((newX,newY));
                        }
                    }
                }
            }
            distance++;
        }
        return -1;
    }
}
