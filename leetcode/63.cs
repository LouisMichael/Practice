public class Solution {
    public int[][] memo;
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
         this.memo = new int[obstacleGrid.Length][];
        for(int i = 0; i< memo.Length;i++){
            this.memo[i] = new int[obstacleGrid[i].Length];
            for(int j = 0; j<memo[i].Length;j++){
                this.memo[i][j] = -1;
            }
        }
        return this.dfs(0,0, obstacleGrid);
    }
    
    public int dfs (int x, int y,int[][] obstacleGrid){
        // Console.WriteLine("at x:" + x + " y:" + y);
        if(x < 0 || x >= obstacleGrid.Length || y < 0 || y >= obstacleGrid[x].Length || obstacleGrid[x][y]==1){
            // Console.WriteLine("out");
            return 0;
        }
        if(this.memo[x][y] >= 0){
            // Console.WriteLine("found solve");
            return this.memo[x][y];
        }
        if(x == obstacleGrid.Length-1 && y == obstacleGrid[x].Length-1){
            // Console.WriteLine("at end");
            return 1;
        }
        int right = this.dfs(x+1, y, obstacleGrid);
        int down = this.dfs(x, y+1, obstacleGrid);
        int ret = 0;
        if(right > 0 && down > 0){
            ret = right + down;
        }
        else{
            ret = Math.Max(right, down);
        }
        this.memo[x][y] = ret;
        return ret;
    }
}
