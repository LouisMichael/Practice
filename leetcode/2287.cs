public class Solution {
    public int RearrangeCharacters(string s, string target) {
        int[] sOccuranceCount = new int[26];
        for(int i = 0; i<s.Length;i++){
            sOccuranceCount[s[i]-'a']++;
        }
        int[] targetOccuranceCount = new int[26];
        for(int i = 0; i<target.Length;i++){
            targetOccuranceCount[target[i]-'a']++;
        }
        int ret = Int32.MaxValue;
        for(int i = 0; i<target.Length;i++){
            ret = Math.Min(ret, sOccuranceCount[target[i]-'a']/targetOccuranceCount[target[i]-'a']);
        }
        return ret;
    }
}
