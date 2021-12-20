// Your runtime beats 37.33 % of csharp submissions.
// The faster way to do this is to not loop the list the second time to build the answer
// I thought of this at first but the thing I missed was that to conserve memeory you can 
// also throw away the current version ever time you get a new smallest value

public class Solution {
    public IList<IList<int>> MinimumAbsDifference(int[] arr) {
        Array.Sort(arr);
        int prev = arr[0];
        int cur = arr[1];
        int minDistance = cur - prev;
        IList<IList<int>> solve = new List<IList<int>>();
        for(int i = 1; i < arr.Length; i++){
            prev = arr[i-1];
            cur = arr[i];
            if(cur-prev < minDistance){
                minDistance = cur-prev;
            }
        }
        for(int i = 1; i < arr.Length; i++){
            prev = arr[i-1];
            cur = arr[i];
            if(cur-prev == minDistance){
                IList<int>pair = new List<int>();
                pair.Add(prev);
                pair.Add(cur);
                solve.Add(pair);
            }
        }
        return solve;
    }
}
