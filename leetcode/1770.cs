public class Solution {
//     there may be a greedy or linar time solution I am missing but
//     I think dp is easy to understand applaction here
//     we can make a 2d array and x can be left postion and y can be right pos
//     then we can store the max outcome for this situation and since we can't 
//     skip x+y will equal i
//     we have to be a little carful about starting value since 0 in some case will be the best answer since multipliers can be negative
//     you have to cheese a little here by using an object to wrap int since the value int starts set to is not valid to see if it has been used
    public int MaximumScore(int[] nums, int[] multipliers) {
        Integer[][] dp = new Integer[multipliers.Length][];
        for(int i = 0; i<multipliers.Length;i++){
            dp[i] = new Integer[multipliers.Length];
        }
        return this.MaximumScoreDPSolve(nums, multipliers,dp, 0, 0);
    }
    public int MaximumScoreDPSolve(int[] nums, int[] multipliers, Integer[][] dp, int leftOffset, int rightOffset) {
        if(leftOffset + rightOffset >= multipliers.Length){
            return 0;
        }
        if(dp[leftOffset][rightOffset] != null){
            return dp[leftOffset][rightOffset].val;
        }
        int useLeft = this.MaximumScoreDPSolve(nums, multipliers,dp, leftOffset+1, rightOffset) + (multipliers[leftOffset+rightOffset]*nums[leftOffset]);
        int userRight = this.MaximumScoreDPSolve(nums, multipliers,dp, leftOffset, rightOffset+1) + (multipliers[leftOffset+rightOffset]*nums[nums.Length-rightOffset-1]);
        int max = Math.Max(useLeft, userRight);
        // Console.WriteLine("max at " + leftOffset + ", " + rightOffset + " was: " + max);
        dp[leftOffset][rightOffset] = new Integer();
        dp[leftOffset][rightOffset].val = max;
        return max;
    }
    
    public class Integer{
        public int val;
    }
}
