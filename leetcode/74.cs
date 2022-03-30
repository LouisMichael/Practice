// Runtime: 120 ms, faster than 65.28% of C# online submissions for Search a 2D Matrix.
// Memory Usage: 39.5 MB, less than 38.44% of C# online submissions for Search a 2D Matrix.

// You can work to 'flatten' your shape instead of just doing two steps to get this to go faster
public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        // intuition run binary search in one direction then the other
        int row = this.binarySearchStep1(matrix, target);
        // Console.WriteLine(row);
        return this.binarySearchStep2(row, matrix,target);
    }
//     method needs to find the closest lower option
    public int binarySearchStep1(int[][] matrix, int target){
        int left = 0;
        int right = matrix.Length-1;
        while(left <= right){
            int mid = (left + right)/2;
            if(matrix[mid][0] == target){
                return mid;
            }
            if(matrix[mid][0] < target){
                left = mid+1;
            }
            else{
                right = mid-1;
            }
        }
        return left-1 >= 0? left-1 : 0;
    }
//     regular binary search over the input row
    public bool binarySearchStep2(int row, int[][] matrix, int target){
        int left = 0;
        int right = matrix[row].Length-1;
        while(left <= right){
            int mid = (left + right)/2;
            if(matrix[row][mid] == target){
                return true;
            }
            if(matrix[row][mid] < target){
                left = mid+1;
            }
            else{
                right = mid-1;
            }
        }
        return false;
    }
}
