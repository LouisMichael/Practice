public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        int[] sortedNums = (int[])nums.Clone();
        int[] ret = new int[2];
        Array.Sort(sortedNums);
        for(int i=0; i < nums.Length; i++){
            int tempTarget = target - nums[i];
            int targetFoundAtIndexInSorted = Array.BinarySearch(sortedNums, tempTarget);
            // Console.WriteLine(targetFoundAtIndexInSorted);
            if(targetFoundAtIndexInSorted >= 0){
                for(int j = 0; j < nums.Length; j++){
                    if(j == i){
                        // Console.WriteLine("moving on");
                        continue;
                    }
                    if(sortedNums[targetFoundAtIndexInSorted] == nums[j]){
                        ret[0] = i;
                        ret[1] = j;
                        return ret;
                    }
                }
            }
        }
        return null;
    }
}
