public class Solution {
//     I think the no extra space solve will be to draw ciricles that go around the box and narrow in
    public void Rotate(int[][] matrix) {
        int top = 0;
        int left = 0;
        int right = matrix.Length -  1;
        int bottom = matrix[left].Length - 1;
        while(top < bottom){
            for(int i = 0; i< right-left; i++){
                int temp = matrix[top+i][right];
                matrix[top+i][right] = matrix[top][left+i];
                matrix[top][left+i] = matrix[bottom-i][left];
                matrix[bottom-i][left] = matrix[bottom][right-i];
                matrix[bottom][right-i] = temp;
            }
            left++;
            right--;
            top++;
            bottom--;
        }
    }
}
