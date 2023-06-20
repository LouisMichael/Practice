public class Solution {
    public int[] GetAverages(int[] nums, int k) {
        long runningTotal = 0;
        int[] ret = new int[nums.Length];
        for(int i = 0; i<k &&  i < nums.Length;i++){
            runningTotal += nums[i];
            ret[i] = -1;
        }
        // Console.WriteLine("a");
        for(int i = k; i<= k*2 && i<nums.Length; i++){
            runningTotal += nums[i];
        }
        if(nums.Length > k*2){
            ret[k] = (int)(runningTotal / ((k*2)+1));
        }
        for(int i = k+1; i<=nums.Length-k-1;i++){
            runningTotal -= nums[i-k-1];
            runningTotal += nums[i+k];
            // Console.WriteLine(runningTotal);
            ret[i] = (int)(runningTotal / ((k*2)+1));
        }
        // Console.WriteLine("c");
        for(int i = nums.Length-1;i>=nums.Length-k && i >=  0;i--){
            ret[i] = -1;
        }
        // Console.WriteLine("d");
        return ret;
    }
}
