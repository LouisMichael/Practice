public class Solution {
    public int MaxDistance(int[][] grid) {
        // since this is manhatten I think we can do this in multiple steps
        // in step one we will find the closest peice of land in one direction, up in the next we can go down
        int [][] distance = new int[grid.Length][];
        // left to right
        for(int i = 0; i<grid.Length;i++){
            distance[i] = new int[grid[i].Length];
            int lastSeenLand = Int32.MaxValue;
            for(int j = 0; j<grid.Length;j++){
                if(lastSeenLand != Int32.MaxValue){
                    lastSeenLand++;
                }
                if(grid[i][j] == 1){
                    lastSeenLand = 0;
                }
                distance[i][j] = lastSeenLand;
            }
        }

        for(int i = 0; i<grid.Length;i++){
            int lastSeenLand = Int32.MaxValue;
            for(int j = grid.Length-1; j>=0;j--){
                if(lastSeenLand != Int32.MaxValue){
                    lastSeenLand++;
                }
                if(grid[i][j] == 1){
                    lastSeenLand = 0;
                }
                distance[i][j] = Math.Min(distance[i][j],lastSeenLand);
            }
        }
        for(int j = 0; j<grid[0].Length;j++){
            int lastSeenLand = Int32.MaxValue-1;
            for(int i = 0; i<grid.Length;i++){
                lastSeenLand = Math.Min(lastSeenLand + 1, distance[i][j]);
                distance[i][j] = lastSeenLand;
            }
        }
        int ret = -1;
        for(int j = 0; j<grid[0].Length;j++){
            int lastSeenLand = Int32.MaxValue-1;
            for(int i = grid.Length-1; i>=0;i--){
                lastSeenLand = Math.Min(lastSeenLand + 1, distance[i][j]);
                distance[i][j] = lastSeenLand;
                if(distance[i][j] > ret){
                    ret = distance[i][j];
                    Console.WriteLine(i + " : " + j);
                }
            }
        }
        return ret == Int32.MaxValue || ret  == 0 ? -1 : ret;
    }
    // you can use "mulit source" which I did not see right away becasue I wanted to like flood fill but we can start with all land in the queue and then expand from all of them one cell at a time so we are expanding that edge together
    // I can also look back in two directoins at a time I don't need the extra loops for the extra directsions, it adds some overhead.  
}
