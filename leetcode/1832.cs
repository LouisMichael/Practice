public class Solution {
    public bool CheckIfPangram(string sentence) {
        bool[] found = new bool[26];
        int count = 0;
        for(int i = 0; i < sentence.Length; i++) {
            if(!found[sentence[i]-'a']){
                found[sentence[i]-'a'] = true;
                count++;
                if(count == 26){
                    return true;
                }
            }
        }
        return false;
    }
}
