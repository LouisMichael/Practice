public class Solution {
//     this is a varaiton on a two pointer problem we have sloved prevously
//     we try to expand while keeping a dictionary of the value and its location
//     if we get a repeated value we jump to the location that is a reapeat
//     I don't think we need to do indexes since we need to deduct the range
//     There is a way where you keep the index of the value and it is helpful but it is not in speeding up the math it is neededing to do fewer set operations
//     by keeping track of last time you saw instead of in current or not. 
    public int MaximumUniqueSubarray(int[] nums) {
        int left = 0;
        int right = 0;
        HashSet<int> noRepeatSet = new HashSet<int>();
        noRepeatSet.Add(nums[0]);
        int max = nums[0];
        int cur = nums[0];
        while(right != nums.Length -1){
            right++;
            while(noRepeatSet.Contains(nums[right])){
                noRepeatSet.Remove(nums[left]);
                cur-=nums[left];
                // Console.WriteLine("Removed: " + nums[left]);
                left++;
                // Console.WriteLine("Cur: " + cur);
            }
            noRepeatSet.Add(nums[right]);
            cur+=nums[right];
            if(cur>max){
                max = cur;
            }
        }
        return max;
    }
}
