// a way to do this would be with a copy 
// a way to do this would be with a custom sort
// I think you can cut down on mem usage if you do two pointer
// Runtime: 222 ms, faster than 26.77% of C# online submissions for Sort Array By Parity.
// Memory Usage: 45.2 MB, less than 56.89% of C# online submissions for Sort Array By Parity.
public class Solution {
    public int[] SortArrayByParity(int[] nums) {
        int low = 0;
        int high = nums.Length-1;
        while(low<high){
            if(nums[low]%2==1 && nums[high]%2==0){
                int temp = nums[low];
                nums[low] = nums[high];
                nums[high] = temp;
            }
            if(nums[low]%2!=1){
                low++;
            }
            if(nums[high]%2!=0){
                high--;
            }
        }
        return nums;
    }
}
