public class Solution {
    public int MinOperations(int[] nums) {
        // I think we want to find the max power of two that is less than the goal val
        // then we want to add one and multiply to get to that value, and add one at the end if we need to get to an odd value
        // this is close but I still don't think right, I think maybe we can instead think about this as a bit counting exersise, we can left shift with our second version of our op, and we can set a 1 with the first version of our op so we want the total number of 1 bits + the farthest right shifted value
        int ret = 0;
        int maxShiftCount = 0;
        for(int i = 0; i<nums.Length;i++){
            (int,int) oneBitAndShiftCount = this.OneBitAndShiftCount(nums[i]);
            ret += oneBitAndShiftCount.Item1;
            maxShiftCount = Math.Max(maxShiftCount, oneBitAndShiftCount.Item2);
        }
        return ret + maxShiftCount;
    }
    public (int,int) OneBitAndShiftCount(int num){
        int oneCount = 0;
        int shiftCount = 0;
        while(num != 0){
            if((1&num) != 0){
                oneCount++;
            }
            num = num >> 1;
            shiftCount++;
        }
        return (oneCount,shiftCount-1);
    }
}
