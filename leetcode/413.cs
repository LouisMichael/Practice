// Runtime: 133 ms, faster than 40.22% of C# online submissions for Arithmetic Slices.
// Memory Usage: 37.2 MB, less than 25.00% of C# online submissions for Arithmetic Slices.
// One of the more intersteting ways I saw this get solved was by haveing a value you add every time you see a set of 3, and that value goes up every time so it builds up.
// this also made the solution really terse. 
public class Solution {
    public int NumberOfArithmeticSlices(int[] nums) {
        int ret = 0;
        if(nums.Length< 2){
            return 0;
        }
        int curDiff = nums[0]-nums[1];
        int curLength = 2;
        for(int i = 2; i < nums.Length; i++){
            if(nums[i-1]-nums[i] == curDiff){
                curLength++;
            }
            else{
                ret += this.NumberOfSubSection(curLength);
                curDiff = nums[i-1]-nums[i];
                curLength = 2;
            }
        }
        ret += this.NumberOfSubSection(curLength);
        return ret;
    }
    public int NumberOfSubSection(int n){
        if(n<3){
            return 0;
        }
        n = n-2;
        return (n*n+n)/2;
    }
}
