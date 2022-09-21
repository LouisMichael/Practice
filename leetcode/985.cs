public class Solution {
    public int[] SumEvenAfterQueries(int[] nums, int[][] queries) {
        int curSumOfEven = 0;
        int[] ret = new int[queries.Length];
        for(int i = 0; i<nums.Length; i++){
            if(nums[i]%2==0){
                curSumOfEven+=nums[i];
            }
        }
        for(int i = 0; i<queries.Length;i++){
            bool wasEven = false;
            if(nums[queries[i][1]]%2==0){
                wasEven = true;
                curSumOfEven -= nums[queries[i][1]];
            }
            nums[queries[i][1]] += queries[i][0];
            bool nowEven = false;
            if(nums[queries[i][1]]%2==0){
                nowEven = true;
                curSumOfEven += nums[queries[i][1]];
            }
            ret[i] = curSumOfEven;
        }
        return ret;
    }
}

// runs in n + m time
// where n is the length nums, we run through it once to start
// where m is the length of queries, we run through it once to get the answer
