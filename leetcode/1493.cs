// O(n) time O(1) space
// we only run over the list one time, we keep just 3 variables to track our progress
public class Solution {
    public int LongestSubarray(int[] nums) {
        // for each group of ones we may be able to look behind, to join with the prev, we can think of looking ahead as the one in front looking behind
        int max = 0;
        int cur = 0;
        int last = 0;
        for(int i = 0; i<nums.Length;i++){
            if(nums[i] == 1){
                // if we see a 1 it can always be added to cur, this will either start a new section or grow an existing one
                cur++;
            }
            else{
                if(cur > 0){
                    // this case is moving from a string of 1 to anything else
                    // we can see if the section we just finished + the section before this one is our new max
                    // if the section before is not valid last will be 0
                    max = Math.Max(max, cur + last);
                    last = cur;
                    cur = 0;
                }
                else{
                    // 2+ not one in a row
                    // invalidate the last section we will not be able to join it to the next section
                    last = 0;
                }
            }
        }
        if(cur == nums.Length){
            // if we only ever get 1s we still need to cut one since the problem states we must delete something
            return cur -1;
        }
        max = Math.Max(max, cur + last);
        return max;
    }
}
