public class Solution {
    public int MaximumSum(int[] nums) {
        // we only need to keep track of a few things, which numbers have what sum of digits and the maxium values of those numbers
        Dictionary<int, int> maxDigitCount = new Dictionary<int, int>();
        Dictionary<int, int> secondMostDigitCount = new Dictionary<int, int>();
        int ret = -1;
        for(int i = 0; i<nums.Length;i++){
            int digitSum = 0;
            int temp = nums[i];
            while(temp > 0){
                digitSum += temp %10;
                temp = temp /10;
            }
            if(!maxDigitCount.ContainsKey(digitSum)){
                maxDigitCount[digitSum] = nums[i];
            }
            else if(maxDigitCount[digitSum] < nums[i]){
                int temp2 =  maxDigitCount[digitSum];
                maxDigitCount[digitSum] = nums[i];
                secondMostDigitCount[digitSum] = temp2;
                ret = Math.Max(ret, secondMostDigitCount[digitSum]+maxDigitCount[digitSum]);
            }
            else if(!secondMostDigitCount.ContainsKey(digitSum) || secondMostDigitCount[digitSum] < nums[i]){
                secondMostDigitCount[digitSum] = nums[i];
                ret = Math.Max(ret, secondMostDigitCount[digitSum]+maxDigitCount[digitSum]);
            }
        }
        return ret;
    }
}
