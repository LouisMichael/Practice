public class Solution {
    public int RemoveElement(int[] nums, int val) {
        int left = 0;
        for(int i = 0; i<nums.Length;i++){
            if(nums[i] == val){
                continue;
            }
            else{
                nums[left] = nums[i];
                left++;
            }
        }
        return left;
    }
}
