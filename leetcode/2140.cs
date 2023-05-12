public class Solution {
    public long MostPoints(int[][] questions) {
        // this is just pick or skip, we can do memo for this pretty simply
        // I think we can also do iterative 
        long[] dp = new long[questions.Length];
        dp[dp.Length -1] = questions[questions.Length-1][0];
        for(int i = dp.Length -2; i >= 0; i--){
            if(questions[i][1] + i+1 >= dp.Length){
                dp[i] = Math.Max(dp[i+1],questions[i][0]);
            }
            else{
                dp[i] = Math.Max(dp[i+1],questions[i][0] + dp[questions[i][1]+i+1]);
            }
            // Console.WriteLine(dp[i]);
        }
        return dp[0];
    }
}
