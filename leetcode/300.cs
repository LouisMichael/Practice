public class Solution {
    public int LengthOfLIS(int[] nums) {
//         in problems like these I think the trick is about keeping only a current and a next possible canidate set
//         for every spot we could either add to the existing set or start a new set or skip
//         we gernally want to start at low spots and add with the smallest increase
//         we can stawrt a stack, and we can push an item onto the stack if it is larger then the peak, or we pop items off the stack until we can push it on
//         when we pop items off we can put them in a queue
//         A way I know whould work is if we consider the starting points from the right
        int[] best = new int[nums.Length];
        int ret = 1;
        for(int i = nums.Length -1; i>=0; i--){
            best[i] = 1;
            for(int j = i; j < nums.Length;j++){
                if(nums[j] > nums[i] && best[i] < best[j] + 1){
                    best[i] = best[j] + 1;
                    if(best[i] > ret){
                        ret = best[i];
                    }
                }
            }
        }
        return ret;
    }
}
//  a better way to do this is to just maintain a best version at all times where you overwrite the number that could fit
