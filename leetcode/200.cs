public class Solution {
    public int NumIslands(char[][] grid) {
        int ret = 0;
        bool[][] visited = new bool[grid.Length][];
        for(int i = 0; i < grid.Length; i++){
            visited[i] = new bool[grid[i].Length];
        }
        for(int i = 0; i < grid.Length; i++){
            for(int j = 0; j<grid[i].Length;j++){
                if(grid[i][j]=='1'&&!visited[i][j]){
                    this.FloodFill(i, j, grid, visited);
                    ret++;
                }
            }
        }
        return ret;
    }
    public void FloodFill(int x, int y, char[][] grid, bool[][] visited){
        // Console.WriteLine("Flood fill at least"+ x +", "+ y);
        if(x >= grid.Length || x < 0  || y >= grid[x].Length || y < 0){
            return;
        }
        if(visited[x][y] || grid[x][y] == '0'){
            return;
        }
        else{
            visited[x][y] = true;
            this.FloodFill(x+1, y, grid, visited);
            this.FloodFill(x-1, y, grid, visited);
            this.FloodFill(x, y+1, grid, visited);
            this.FloodFill(x, y-1, grid, visited);
        }
    }
}
