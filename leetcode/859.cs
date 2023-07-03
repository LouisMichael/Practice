public class Solution {
    public bool BuddyStrings(string s, string goal) {
        // must be different by exactly 2 letters, those letters must be swappable
        int mistake1 = -1;
        int mistake2 = -1;
        if(s.Length != goal.Length){
            return false;
        }
        
        for(int i = 0; i<s.Length;i++){
            if(s[i] != goal[i]){
                if(mistake1 < 0){
                    mistake1 = i;
                }
                else if(mistake2<0){
                    mistake2 = i;
                }
                else{
                    return false;
                }
            }
        }
        if(mistake1 < 0){
            int[] letterCount = new int[26];
            for(int i = 0; i<s.Length;i++){
                letterCount[s[i]-'a']++;
                if(letterCount[s[i]-'a'] > 1){
                    return true;
                }
            }
            return false;
        }
        if(mistake2 < 0){
            return false;
        }
        if(s[mistake1] == goal[mistake2] && s[mistake2] ==goal[mistake1]){
            return true;
        }
        return false;
    }
}
