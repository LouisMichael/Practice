// In the provied solution they look at every letter as it shows up in the second pass instead of getting the first and the last in the first pass
// Runtime: 170 ms, faster than 54.85% of C# online submissions for Partition Labels.
// Memory Usage: 41.4 MB, less than 56.55% of C# online submissions for Partition Labels.
public class Solution {
    public IList<int> PartitionLabels(string s) {
//         the first and the last occurance of each letter needs to be in the same group
//         first we can find this in o(n) by running over s
//         we can then try to cut at every postion of s and check if it is valid in o(26)
        int[] firstShown = new int[26];
        int[] lastShown = new int[26];
        List<int> ret = new List<int>();
        for(int i = 0; i< s.Length;i++){
            if(firstShown[s[i]-'a'] < 1){
                firstShown[s[i]-'a'] = i+1;
            }
            lastShown[s[i]-'a'] = i+1;
        }
        int curCutLength = 0;
        for(int i = 1; i<s.Length+1;i++){
            bool cutPossible = true;
            curCutLength++;
            for(int j = 0; j<firstShown.Length;j++){
                if((firstShown[j]<=i&&lastShown[j]<=i) || (firstShown[j]>i&&lastShown[j]>i)){
                    cutPossible = true;
                }
                else{
                    cutPossible = false;
                    break;
                }
            }
            if(cutPossible){
                ret.Add(curCutLength);
                curCutLength = 0;
            }
        }
        return ret;
    }
}
