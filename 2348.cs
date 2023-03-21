public class Solution {
    public long ZeroFilledSubarray(int[] nums) {
        // sum of an arathmetic sequance is (n/2)[a_1 + a_n] where n is the number of values in the sequance
        long ret = 0;
        long zeroCount = 0;
        for(int i =0; i<nums.Length;i++){
            if(nums[i] == 0){
                zeroCount++;
            }
            else{
                ret += (long)(((double)zeroCount/(double)2)*(double)(1+zeroCount));
                zeroCount = 0;
            }
        }
        ret += (long)(((double)zeroCount/(double)2)*(double)(1+zeroCount));
        return ret;
    }
}
