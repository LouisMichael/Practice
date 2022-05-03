// pointer from start to find out of place by decreasing
// pointer from end to find out of place increase
// after finding this out of order element we need to find where we need to sort to get it in place so this is binary search over the rest of the section.

// Runtime: 138 ms, faster than 56.86% of C# online submissions for Shortest Unsorted Continuous Subarray.
// Memory Usage: 39.7 MB, less than 95.10% of C# online submissions for Shortest Unsorted Continuous Subarray.
public class Solution {
    public int FindUnsortedSubarray(int[] nums) {
        int maxLowerRange = 0;
        int minUpperRange = nums.Length-1;
        for(; maxLowerRange < nums.Length-1;maxLowerRange++){
            if(nums[maxLowerRange+1]<nums[maxLowerRange]){
                break;
            }
        }
        for(; minUpperRange > 0;minUpperRange--){
            if(nums[minUpperRange]<nums[minUpperRange-1]){
                break;
            }
        }
        if(maxLowerRange == nums.Length-1 && minUpperRange == 0){
//             sorted return 0
            return 0;
        }
        int minToSort = nums[minUpperRange];
        int maxToSort = nums[maxLowerRange];
        for(int i = maxLowerRange; i<minUpperRange; i++){
            if(nums[i] > maxToSort){
                maxToSort = nums[i];
            }
            if(nums[i] < minToSort){
                minToSort = nums[i];
            }
        }
        int actualLowerBound = 0;
        for(; actualLowerBound<maxLowerRange;actualLowerBound++){
            if(minToSort<nums[actualLowerBound]){
                break;
            }
        }
        int actualUpperBound = nums.Length-1;
        for(; actualUpperBound>minUpperRange;actualUpperBound--){
            if(maxToSort>nums[actualUpperBound]){
                break;
            }
        }
        // Console.WriteLine("maxLowerRange: " +  maxLowerRange);
        // Console.WriteLine("minUpperRange: " +  minUpperRange);
        // Console.WriteLine("actualUpperBound: " +  actualUpperBound);
        // Console.WriteLine("actualLowerBound: " +  actualLowerBound);
        return actualUpperBound - actualLowerBound + 1;
        
    }
    
}
