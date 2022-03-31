// dp strucutre would be 2d
// one directoin is how many items are used and the other is how many splits have been used

// turns out you can do this as a binary search problem, that is pretty cool
public class Solution {
    public int[][] dp;
    public int[] nums;
    public int SplitArray(int[] nums, int m) {
        this.dp = new int[nums.Length][];
        this.nums = nums;
        for(int i = 0; i< nums.Length;i++){
            this.dp[i] = new int[m];
        }
        return this.SplitArrayRecur(0,m);
    }
    
    public int SplitArrayRecur(int index, int m) {
        // Console.WriteLine("index: "+index+"m: "+m );
        if(this.dp[index][m-1] > 0){
            return this.dp[index][m-1];
        }
        if(m <=1){
            int max = 0;
            for(int i = index; i < this.nums.Length; i++){
                max+=nums[i];
            }
            this.dp[index][m-1] = max;
            return max;
        }
        else{
            int min = Int32.MaxValue;
            int localTotal = 0;
            for(int i = index; i < this.nums.Length-1; i++){
                localTotal+=this.nums[i];
                int temp = Math.Max(this.SplitArrayRecur(i+1,m-1),localTotal);
                // Console.WriteLine(localTotal);
                // Console.WriteLine(temp);
                if(temp < min){
                    min = temp;
                }
                if(localTotal==temp){
                    break;
                }
            }
            this.dp[index][m-1] = min;
            return min;
        }
    }
}
