public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        Array.Sort(candidates);
        IList<IList<int>> ret = new List<IList<int>>();
        this.CombinationSum2Recur(candidates, target, 0, ret, new Stack<int>());
        return ret;
    }
    public void CombinationSum2Recur(int[] candidates, int target, int pos, IList<IList<int>> ret, Stack<int> cur){
        if(target == 0){
            ret.Add(cur.ToList());
            return;
        }
        if(pos >= candidates.Length || target < candidates[pos]){
            return;
        }
        cur.Push(candidates[pos]);
        this.CombinationSum2Recur(candidates, target - candidates[pos], pos + 1, ret, cur);
        cur.Pop();
        while(pos + 1 < candidates.Length && candidates[pos] == candidates[pos+1]){
            pos = pos +1;
        }
        this.CombinationSum2Recur(candidates, target, pos + 1, ret, cur);
    }
}
