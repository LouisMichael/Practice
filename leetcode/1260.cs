// Runtime: 215 ms, faster than 57.69% of C# online submissions for Shift 2D Grid.
// Memory Usage: 46.6 MB, less than 15.38% of C# online submissions for Shift 2D Grid.
public class Solution {
    public IList<IList<int>> ShiftGrid(int[][] grid, int k) {
        int temp = 0;
        for(int times = 0; times<k;times++){
            int inPut = grid[grid.Length-1][grid[grid.Length-1].Length-1];
            for(int i = 0; i < grid.Length;i++){
                for(int j =0 ;j < grid[i].Length;j++){
                    temp = grid[i][j];
                    grid[i][j] = inPut;
                    inPut = temp;
                }
            }
        }
        return grid;
    }
}
