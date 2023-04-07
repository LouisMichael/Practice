public class Solution {
    public int NumEnclaves(int[][] grid) {
        bool[][] visited = new bool[grid.Length][];
        int ret = 0;
        for(int i = 0; i<grid.Length;i++){
            visited[i] = new bool[grid[i].Length];
        }
        for(int i = 0; i<grid.Length;i++){
            for(int j = 0; j<grid[i].Length;j++){
                if(grid[i][j] == 1){
                    ret+=this.islandCheck(i, j, visited, grid);
                }
            }
        }
        return ret;
    }
    private int islandCheck(int i, int j, bool[][] visited, int[][] grid){
        // Console.WriteLine("Island check running at i: " + i + " j: " + j);
        if(visited[i][j]){
            return 0;
        }
        int fill = this.floodFill(i,j,visited,grid);
        return fill > 0 ? fill : 0;
    }
    private int floodFill(int i, int j, bool[][] visited, int[][] grid){
        
        if(i<0 || i>grid.Length-1 || j <0 || j>grid[i].Length-1){
            // Console.WriteLine("Side found at i: " + i + " j: " + j);
            return -1;
        }
        if(visited[i][j]){
            return 0;
        }
        visited[i][j] = true;
        if(grid[i][j] == 0){
            return 0;
        }
        else{
            int down= this.floodFill(i+1,j,visited,grid);
            int up = this.floodFill(i-1,j,visited,grid);
            int right = this.floodFill(i,j+1,visited,grid);
            int left = this.floodFill(i,j-1,visited,grid);
            if(down == -1 || up == -1 || right == -1 || left == -1){
                return -1;
            }
            return 1+down+up+right+left;
        }
        
    }
}
