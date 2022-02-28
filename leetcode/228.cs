// Your runtime beats 46.59 % of csharp submissions
// Two wrong answer on not including the empty set and not 
// accounting for negative numbers
public class Solution {
    public IList<string> SummaryRanges(int[] nums) {
        List<string> ret = new List<string>();

        if(nums.Length == 0){
            return ret;
        }
        int cur = nums[0];
        int startRange = nums[0];
        int endRange =  nums[0];
        for(int i = 0; i < nums.Length; i++){
            if(Math.Abs(nums[i]-cur) <= 1){
                endRange = nums[i];
                cur = nums[i];
            }
            else{
                if(endRange > startRange){
                    ret.Add(startRange + "->" + endRange);
                }
                else{
                    ret.Add(startRange+"");
                }
                startRange = nums[i];
                endRange = nums[i];
                cur = nums[i];
            }
        }
        if(endRange > startRange){
            ret.Add(startRange + "->" + endRange);
        }
        else{
            ret.Add(startRange+"");
        }

        return ret;
    }
}
