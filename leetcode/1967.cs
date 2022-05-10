// 1967
// Runtime: 105 ms, faster than 55.42% of C# online submissions for Number of Strings That Appear as Substrings in Word.
// Memory Usage: 38.3 MB, less than 40.96% of C# online submissions for Number of Strings That Appear as Substrings in Word.
public class Solution {
    public int NumOfStrings(string[] patterns, string word) {
        int count = 0;
        foreach(string pattern in patterns){
            if(word.IndexOf(pattern) >= 0){
                count ++;
            }
        }
        return count;
    }
}
