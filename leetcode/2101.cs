public class Solution {
    public int MaximumDetonation(int[][] bombs) {
        // this is a combination graph and geometry problem, I think union find is a okay datastructure for the graph style problem
        // so then geometry half is to find all bombs that in the raduis of a given bomb, maybe a good search would be 
        // sorted points to find all values in a range where the raduis is treated as a square, and then check that those points are in the circle vs pair wise distance comparison
        // pairwise distance is faster to implement so I will try that first also the list is only 100 long
        bool[][] connected = new bool[100][];
        for(int i = 0; i<100;i++){
            connected[i] = new bool[100];
        }
        for(int i = 0; i<bombs.Length;i++){
            for(int j = i+1; j<bombs.Length; j++){
                long xDist = Math.Abs((long)bombs[i][0]-(long)bombs[j][0]);
                long yDist = Math.Abs((long)bombs[i][1]-(long)bombs[j][1]);
                double dist = Math.Sqrt((double)(xDist * xDist) + (double)(yDist * yDist));
                if(dist <= (double)(bombs[i][2])){
                    connected[i][j] = true;
                }
                if(dist <= (double)(bombs[j][2])){
                    connected[j][i] = true;
                }
            }
        }
        int max = 0;
        for(int i = 0; i<100;i++){
            int count = 1;
            bool[] visited = new bool[100];
            visited[i] = true;
            Stack<int> stack = new Stack<int>();
            stack.Push(i);
            while(stack.Count > 0){
                int cur = stack.Pop();
                for(int j = 0; j<100; j++){
                    if(!visited[j] && connected[cur][j]){
                        visited[j] = true;
                        stack.Push(j);
                        count++;
                    }
                }
            }
            max = Math.Max(count, max);
        }
        return max;
    }

    // public class UnionFindGraph<T>{
    //     public Dictionary<T, UnionFindNode> dict;
    //     public void Add(T val){
    //         if(!this.dict.ContainsKey(val)){
    //             this.dict[val] = new UnionFindNode();
    //         }
    //     }
    //     public Join(T val1, T val2){
    //         if(!this.dict.ContainsKey(val1)){
    //             this.dict[val1] = new UnionFindNode();
    //         }
    //         if(!this.dict.ContainsKey(val2)){
    //             this.dict[val2] = new UnionFindNode();
    //         }

    //     }
    //     public class UnionFindNode{
    //         public int depth;
    //         public UnionFindNode parent;
    //         public UnionFindNode{
    //             this.parent = this;
    //         }
    //     }
    // }
}
