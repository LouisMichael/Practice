// I think this can be memoized well since every squre that will only be part of one longest setion from itself
// you could find the max or the min and try to spread out from this spot

// Runtime: 123 ms, faster than 88.70% of C# online submissions for Longest Increasing Path in a Matrix.
// Memory Usage: 39.6 MB, less than 68.84% of C# online submissions for Longest Increasing Path in a Matrix.
// this did not seem "hard"
public class Solution {
    public int[][] directions;
    public int totalMax;
    public int[][] memo;
    public int[][] matrix;
    public int LongestIncreasingPath(int[][] matrix) {
        this.matrix = matrix;
        this.directions = new int[4][];
        //         up
        this.directions[0] = new int[] {0, 1};
        //         right
        this.directions[1] = new int[] {1, 0};
        //         down
        this.directions[2] = new int[] {0, -1};
        //         left
        this.directions[3] = new int[] {-1, 0};
        this.memo = new int[matrix.Length][];
        for(int i = 0; i<matrix.Length;i++){
            this.memo[i] = new int[matrix[i].Length];
        }
        for(int i = 0; i<matrix.Length;i++){
            for(int j = 0; j<matrix[i].Length;j++){
                this.PopulateLongestIncreasingPath(i,j);
            }
        }
        return this.totalMax;
    }
    
    public int PopulateLongestIncreasingPath(int x, int y){
        if(this.memo[x][y] > 0){
            return this.memo[x][y];
        }
        int maxPathVal = 1;
        for(int i = 0; i<this.directions.Length;i++){
            
            int newX = x + this.directions[i][0];
            int newY = y + this.directions[i][1];

            if(newX >= this.matrix.Length || newX < 0 || newY >=this.matrix[0].Length || newY < 0){
                continue;
            }
            if(this.matrix[newX][newY] > this.matrix[x][y]){
                int directionValue = 1 + this.PopulateLongestIncreasingPath(newX,newY);
                if(directionValue > maxPathVal){
                    maxPathVal = directionValue; 
                }
            }
        }        
        this.memo[x][y] = maxPathVal;
        if(maxPathVal > this.totalMax){
            this.totalMax = maxPathVal;
        }
        return maxPathVal;
    }
}
