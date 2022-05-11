// 1641
public class Solution {
//     we don't need to actually do the work to find the answer since we just return the int
//     I can't see the combo way but I can draw a grid for the math
//     the combo is [(n+4)*(n+3)*(n+2)*(n+1)]/24, I don't get why though
    public int CountVowelStrings(int n) {
        int[][] solve = new int[50][];
        solve[0] = new int[] {5,4,3,2,1};
        for(int i = 1; i < n; i++){
            solve[i] = new int[5];
            int sum = 0;
            for(int j = 0; j<5;j++){
                 sum += solve[i-1][j];
            }
            solve[i][0] = sum;
            for(int j = 1; j<5;j++){
                solve[i][j] = solve[i][j-1] - solve[i-1][j-1];
            }
        }
        return solve[n-1][0];
    }
}
