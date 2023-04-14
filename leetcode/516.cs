public class Solution {
    public int LongestPalindromeSubseq(string s) {
        // dp is standardly a good fit for problems like this
        // since every letter can either be kept or not
        // maybe there is a greeder way to work this as well, finding how many you need to add to get to a palondrome
        // we can try every pos as a pivot, and run another function for how most at that pivot
        int[][] dp = new int[s.Length][];
        for(int i = 0; i<s.Length;i++){
            dp[i] = new int[s.Length];
        }
        for(int left = s.Length-1;left >= 0; left--){
            for(int right = left; right < s.Length; right++){
                if(left == right){
                    dp[left][right] = 1;
                }
                else if(s[left] == s[right]){
                    dp[left][right] = 2 + dp[left+1][right-1];
                }
                else{
                    dp[left][right] = Math.Max(dp[left+1][right], dp[left][right-1]);
                }
            }
        }
        return dp[0][s.Length-1];
    }
           
}
