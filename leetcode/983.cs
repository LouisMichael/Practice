public class Solution {
    public int MincostTickets(int[] days, int[] costs) {
        // this problem makes me think dp will fit well
        // at every day we can buy one of the three passes and then jump to the next day we need to buy a pass
        // there may be some added bounuses on speed up like if costs does not actually repersent a good discount we could check for this
        // lets start with a pretty simple recursive strat, then maybe we can look at greedy or huristic
        int[] dp = new int[days.Length];
        return this.minAtTime(days, 0, -1, costs, dp);

    }
    public int minAtTime(int[] days, int pos, int purchasThrough, int[] costs, int[] dp){
        while(pos >= days.Length || purchasThrough >= days[pos]){
            pos++;
            if(pos >= days.Length){
                return 0;
            }
        }
        if(dp[pos] > 0){
            return dp[pos];
        }
        int min = this.minAtTime(days, pos + 1, days[pos], costs, dp) + costs[0];
        int minBuyingForSevenDay = this.minAtTime(days, pos + 1, days[pos]+6, costs, dp) + costs[1];
        min = Math.Min(min, minBuyingForSevenDay);
        int minBuyingForThirtyDay = this.minAtTime(days, pos + 1, days[pos]+29, costs, dp) + costs[2];
        min = Math.Min(min, minBuyingForThirtyDay);
        dp[pos] = min;
        return min;
    }
}
