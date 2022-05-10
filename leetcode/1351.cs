// 1351
// Runtime: 105 ms, faster than 77.29% of C# online submissions for Count Negative Numbers in a Sorted Matrix.
// Memory Usage: 42.7 MB, less than 12.35% of C# online submissions for Count Negative Numbers in a Sorted Matrix.
public class Solution {
    public int CountNegatives(int[][] grid) {
//       go through the list backwards and count up would work but we can gen more granualr thanks to the two directions and only index through the first row with a non negative start
        int ret = 0;
        for(int i = grid.Length-1; i>=0; i--){
            for(int j = grid[i].Length-1; j>=0; j--){
                if(grid[i][j]<0){
                    ret+=1;
                }
                else{
                    break;
                }
            }
        }
        return ret;
    }
}
