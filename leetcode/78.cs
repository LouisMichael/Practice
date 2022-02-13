// Runtime: 132 ms, faster than 72.12% of C# online submissions for Subsets.
// Memory Usage: 42.9 MB, less than 5.62% of C# online submissions for Subsets.
public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        IList<IList<int>> ret = new List<IList<int>>();
        for(int i = 0; i < 1<<nums.Length;i++){
            int map = 1;
            int test = i;
            IList<int> set = new List<int>();
            for(int j = 0; j <nums.Length;j++){
                if((map & test)>0){
                    set.Add(nums[j]);
                }
                test = test >> 1;
            }
            ret.Add(set);
        }
        
        return ret;
    }
}
