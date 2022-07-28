public class Solution {
    public bool IsAnagram(string s, string t) {
        int[] letterCount = new int[26];
        int lettersUsed = 0;
        for(int i = 0; i < s.Length; i++){
            letterCount[s[i]-'a']++;
            if(letterCount[s[i]-'a'] == 1){
                lettersUsed++;
            }
        }
        for(int i = 0; i < t.Length; i++){
            letterCount[t[i]-'a']--;
            if(letterCount[t[i]-'a'] == 0){
                lettersUsed--;
            }
            if(letterCount[t[i]-'a'] < 0){
                return false;
            }
        }
        return lettersUsed == 0;
    }
}
