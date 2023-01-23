public class Solution {
    public int FindJudge(int n, int[][] trust) {
        int[] trustIn = new int[n];
        int[] trustOut = new int[n];
        for(int i = 0; i<trust.Length;i++){
            trustOut[trust[i][0]-1]++;
            trustIn[trust[i][1]-1]++;
        }
        for(int i = 0; i<n;i++){
            if(trustIn[i] == n-1 && trustOut[i] == 0){
                return i+1;
            }
        }
        return -1;
    }
}
