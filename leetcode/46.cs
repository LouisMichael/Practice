public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
         IList<IList<int>> ret =  new List<IList<int>>();
        this.PermuteRecur(nums, 0, new List<int>(), ret);
        return ret;
    }
    
    public void PermuteRecur(int[] nums, int pos, IList<int> cur, IList<IList<int>> ret) {
        if(pos >= nums.Length){
            ret.Add(cur);
            return;
        }
        for(int i = 0; i<=cur.Count;i++){
            IList<int> next = new List<int>(cur);
            next.Insert(i, nums[pos]);
            this.PermuteRecur(nums, pos + 1, next, ret);
        }
    }
}
