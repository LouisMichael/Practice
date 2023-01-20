public class Solution {
    public IList<IList<int>> FindSubsequences(int[] nums) {
        // since we also have to return them we will be keeping n^2 things in memory
        // a way to write this I think is to go to use a TreeMap to keep the sorted structure as we insert more stuff
        // in the question it asks them to be diffrent so we need some sort of a set of them
        List<IList<int>> ret = new List<IList<int>>();
        HashSet<string> used = new HashSet<string>();
        for(int i = 0; i<nums.Length;i++){
            int curLengthOfRet = ret.Count;
            for(int j = 0; j<curLengthOfRet;j++){
                IList<int> list = ret[j];
                if(list[list.Count-1] <= nums[i]){
                    List<int> newList1 = new List<int>(list);
                    newList1.Add(nums[i]);
                    string key = "";
                    foreach(int num in newList1){
                        key+=num+',';
                    }
                    if(!used.Contains(key)){
                        ret.Add(newList1);
                        used.Add(key);
                    }
                }
            }
            var newList = new List<int>();
            newList.Add(nums[i]);
            ret.Add(newList);
        }
        ret.RemoveAll(x => x.Count <= 1);
        return ret;
    }
    
}
