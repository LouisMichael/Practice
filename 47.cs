// 47
public class Solution {
//     My first though is to just add to a set to remove duplicates and then just try all of the possibilities because this has the same worse case as the alternative just maybe with some exta memory
    public HashSet<string> noDupCheck;
    public IList<IList<int>> ret;
    public IList<IList<int>> PermuteUnique(int[] nums) {
        this.noDupCheck = new HashSet<string>();
        this.ret = new List<IList<int>>();
        this.PermuteUniqueRecur(nums, new bool[nums.Length], new List<int>());
        return this.ret;
    }
    public void PermuteUniqueRecur(int[] nums, bool[] used, IList<int>cur) {
        if(cur.Count == nums.Length){
//             check add, return
            string check = "";
            for(int i = 0; i<cur.Count;i++){
                check = check + cur[i] + ",";
            }
            // Console.WriteLine(check);
            if(!this.noDupCheck.Contains(check)){
                this.noDupCheck.Add(check);
                this.ret.Add(new List<int>(cur));
            }
        }
        for(int i = 0; i< nums.Length; i++){
            if(!used[i]){
                used[i] = true;
                cur.Add(nums[i]);
                this.PermuteUniqueRecur(nums, used, cur);
                used[i] = false;
                cur.RemoveAt(cur.Count-1);
            }
        }
    }
}
