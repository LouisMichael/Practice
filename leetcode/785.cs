// I am still learning more about diffrent graph traversals, I ended up doing this with a stack, which I guess would make this depth first, but I sam a more popular options to do queues with depth first
// I did the stack since I liked getting to set up all the nodes at the start which fixed a dead ending problem I had at first
public class Solution {
//     I think you can show this by trying it but I also think there is a math way to do this that has to do with edge count
    public bool IsBipartite(int[][] graph) {
        int[] graphColor = new int[graph.Length];
        Stack<int> queue = new Stack<int>();
        bool[] visited = new bool[graph.Length];
//         arbatraly start at v 0
        for(int i = 0; i<graph.Length; i++){
            queue.Push(i);
        }
        
        while(queue.Count > 0){
            int cur = queue.Pop();
            if(visited[cur]){
                continue;
            }
            visited[cur] = true;
            if(graphColor[cur] == 0){
                graphColor[cur] = 1;
            }
            for(int i = 0; i<graph[cur].Length;i++){
                if(!visited[graph[cur][i]]){
                    queue.Push(graph[cur][i]);
                }
                if(graphColor[graph[cur][i]] == 0){
                    graphColor[graph[cur][i]] = graphColor[cur]*-1;
                }
                if(graphColor[graph[cur][i]] != graphColor[cur]*-1){
                    return false;
                }
            }
        }
        return true;
    }
}
