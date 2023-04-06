public class Solution {
    public int ClosedIsland(int[][] grid) {
        // run floodfill on 0s
        bool[][] visited = new bool[grid.Length][];
        int ret = 0;
        for(int i = 0; i<grid.Length;i++){
            visited[i] = new bool[grid[i].Length];
        }
        for(int i = 0; i<grid.Length;i++){
            for(int j = 0; j<grid[i].Length;j++){
                if(grid[i][j] == 0){
                    if(this.islandCheck(i, j, visited, grid)){
                        ret++;
                        // Console.WriteLine("Island at i: " + i + " j: " + j);
                    }
                }
            }
        }
        return ret;
    }
    private bool islandCheck(int i, int j, bool[][] visited, int[][] grid){
        // Console.WriteLine("Island check running at i: " + i + " j: " + j);
        if(visited[i][j]){
            return false;
        }
        return this.floodFill(i,j,visited,grid);
    }
    private bool floodFill(int i, int j, bool[][] visited, int[][] grid){
        
        if(i<0 || i>grid.Length-1 || j <0 || j>grid[i].Length-1){
            // Console.WriteLine("Side found at i: " + i + " j: " + j);
            return false;
        }
        if(visited[i][j]){
            return true;
        }
        visited[i][j] = true;
        if(grid[i][j] == 1){
            return true;
        }
        else{
            // we can't and these together right away since they need to finish running to make visited accurate
            // doing the and on the same line as the call will result in some directions not being run
            bool down= this.floodFill(i+1,j,visited,grid);
            bool up = this.floodFill(i-1,j,visited,grid);
            bool right = this.floodFill(i,j+1,visited,grid);
            bool left = this.floodFill(i,j-1,visited,grid);
            return down && up && right && left;
        }
        
    }
}
