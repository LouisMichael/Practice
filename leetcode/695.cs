public class Solution {
//     top level loop to make sure you visit all locations
//     inner loop to get the size on an island that uses flood fill
    public bool[][] gridVisited;
    public int MaxAreaOfIsland(int[][] grid) {
        int max = 0;
        this.gridVisited = new bool[grid.Length][];
        for(int i = 0; i<grid.Length;i++){
            this.gridVisited[i] = new bool[grid[i].Length];
        }
        for(int i = 0; i<grid.Length;i++){
            this.gridVisited[i] = new bool[grid[i].Length];
            for(int j = 0; j<grid[i].Length;j++){
                if(!this.gridVisited[i][j] && grid[i][j] == 1){
                    int floodFillResult = this.floodFillCount(grid, i, j);
                    if(floodFillResult > max){
                        max = floodFillResult;
                    }
                }
            }
        }
        return max;
    }
    public int floodFillCount(int[][] grid,int i,int j){
        if(i >= grid.Length || i < 0){
            return 0;
        }
        if(j >= grid[i].Length || j < 0){
            return 0;
        }
        if(this.gridVisited[i][j] || grid[i][j] == 0){
            return 0;
        }
        this.gridVisited[i][j] = true;
        return 1 + this.floodFillCount(grid, i +1, j) +this.floodFillCount(grid, i-1, j) +this.floodFillCount(grid, i, j+1) + this.floodFillCount(grid, i, j-1);
    }
}
