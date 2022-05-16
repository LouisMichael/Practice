public class Solution {
//     since we are exploring at the same time as solving I think memoized dfs is an okay approch
//     dijstra and a* would improve on this
    // Runtime: 215 ms, faster than 44.92% of C# online submissions for Shortest Path in Binary Matrix.
// Memory Usage: 46.8 MB, less than 21.81% of C# online submissions for Shortest Path in Binary Matrix.
    public Node[][] nodeGrid;
    private int[][] directions; 
    public int ShortestPathBinaryMatrix(int[][] grid) {
        this.nodeGrid = new Node[grid.Length][];
        this.directions = new int[8][];
        //         up
        this.directions[0] = new int[]{0,1}; 
        //         left
        this.directions[1] = new int[]{-1,0};
        //         up + right
        this.directions[2] = new int[]{1,1};
        //         up + left
        this.directions[3] = new int[]{-1,1};
        //         right
        this.directions[4] = new int[]{1,0};
        //         down
        this.directions[5] = new int[]{0,-1};
        //         down + right
        this.directions[6] = new int[]{1,-1};
        //         down + left
        this.directions[7] = new int[]{-1,-1};
        for(int i = 0; i< grid.Length;i++){
            this.nodeGrid[i] = new Node[grid[i].Length];
            for(int j = 0; j < grid[i].Length; j++){
                if(grid[i][j] == 0){
                    this.nodeGrid[i][j] = new Node();
                    for(int k = 0; k<this.directions.Length;k++){
                        int newX = i+this.directions[k][0];
                        int newY = j+this.directions[k][1];
                        if( newX >=0 && newX < grid.Length && newY >=0 && newY < grid[newX].Length){
                            if(this.nodeGrid[newX] != null && this.nodeGrid[newX][newY]!=null){
                                Node agaisntNode = this.nodeGrid[newX][newY];
                                Node cur = this.nodeGrid[i][j];
                                agaisntNode.connections.Add(cur);
                                cur.connections.Add(agaisntNode);
                            }
                        }
                    }
                }
            }
        }
//         now we have built our connection graph we can use a DFS to find our shortest path;
        Queue<Node> queue = new Queue<Node>();
        if(this.nodeGrid[0][0] == null){
            return -1;
        }
        queue.Enqueue(this.nodeGrid[0][0]);
        this.nodeGrid[0][0].min = 1;
        while(queue.Count > 0){
            Node cur = queue.Dequeue();
            if(cur.visited){
                continue;
            }
            else{
                for(int i =0; i<cur.connections.Count; i++){
                    Node curConnection = cur.connections[i];
                    if(curConnection.min > cur.min + 1){
                        curConnection.min = cur.min + 1;
                    }
                    queue.Enqueue(curConnection);
                }
                cur.visited = true;
            }
        }
        Node lastNode = this.nodeGrid[this.nodeGrid.Length-1][this.nodeGrid[0].Length-1];
        if(lastNode != null && lastNode.visited){
            return this.nodeGrid[this.nodeGrid.Length-1][this.nodeGrid[0].Length-1].min;
        }
        return -1;
    }
    
    public class Node{
        public List<Node> connections;
        public int min;
        public bool visited;
        public Node(){
            this.connections = new List<Node>();
            this.min = Int32.MaxValue;
            this.visited = false;
        }
    }
//     memoizing does not work because as we move through each position we are not acutally finding the shortest path to get to that position we are finding the shortest path to get to that position given the set of paths we have already visited.
//     public int ShortestPathBinaryMatrix(int[][] grid) {
//         this.memo = new int[grid.Length][];
//         this.directions = new int[8][];
//         //         up
//         this.directions[0] = new int[]{0,1}; 
//         //         left
//         this.directions[1] = new int[]{-1,0};
//         //         up + right
//         this.directions[2] = new int[]{1,1};
//         //         up + left
//         this.directions[3] = new int[]{-1,1};
//         //         right
//         this.directions[4] = new int[]{1,0};
//         //         down
//         this.directions[5] = new int[]{0,-1};
//         //         down + right
//         this.directions[6] = new int[]{1,-1};
//         //         down + left
//         this.directions[7] = new int[]{-1,-1};
//         for(int i = 0; i< grid.Length;i++){
//             this.memo[i] = new int[grid[i].Length];
//         }
//         int temp = this.ShortestPathBinaryMatrixRecur(grid, 0, 0);
//         if(temp >= this.max){
//             return -1;
//         }
//         else{
//             return temp;
//         }
//     }
//     public int ShortestPathBinaryMatrixRecur(int[][] grid, int x, int y) {
//         if(grid[x][y] != 0){
//             return this.max;
//         }
//         if(x == grid.Length-1 && y == grid[x].Length-1){
//             return 1;
//         }
        
//         this.memo[x][y] = -1;
//         int min = this.max;
//         for(int i = 0; i<this.directions.Length;i++){
//             int newX = x+this.directions[i][0];
//             int newY = y+this.directions[i][1];
//             if( newX >=0 && newX < grid.Length && newY >=0 && newY < grid[x].Length && this.memo[newX][newY] != -1){
//                 int temp = this.ShortestPathBinaryMatrixRecur(grid, newX, newY) + 1;
//                 if(temp < min){
//                     min = temp;
//                     // Console.WriteLine("min found for: " + x + "," + y + " at: " + newX + "," + newY);
//                 }
//             }
//             else{
//                 continue;
//             }
//         }
//         this.memo[x][y] = min;
//         return min;
//     }
}
