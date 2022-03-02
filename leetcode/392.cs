public class Solution {
    public bool IsSubsequence(string s, string t) {
        if(s.Length == 0) return true;
        int curPosS = 0;
        for(int i = 0; i < t.Length; i++){
            if(s[curPosS] == t[i]){
                curPosS++;
                if(curPosS == s.Length){
                    return true;
                }
            }
            
        }
        
        return false;
    }
}
