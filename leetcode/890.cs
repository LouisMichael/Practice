public class Solution {
//     for each word we are looking for a simpification of the repetiton of values

    public IList<string> FindAndReplacePattern(string[] words, string pattern) {
        int[] patternTracker = new int[26];
        int[] patternAsNumber = new int[pattern.Length];
        int patternNewValue = 1;
        for(int i = 0; i<pattern.Length; i++){
            int curLetterAsNumber = patternTracker[pattern[i]-'a'];
            if(curLetterAsNumber == 0){
                patternTracker[pattern[i]-'a'] = patternNewValue;
                curLetterAsNumber = patternNewValue;
                patternNewValue++;
            }
            patternAsNumber[i] = curLetterAsNumber;
        }
        List<string> ret = new List<string>();
        for(int i = 0; i<words.Length;i++){
            bool match = true;
            patternTracker = new int[26];
            patternNewValue = 1;
            for(int j = 0; j < words[i].Length;j++){
                int curLetterAsNumber = patternTracker[words[i][j]-'a'];
                if(curLetterAsNumber == 0){
                    patternTracker[words[i][j]-'a'] = patternNewValue;
                    curLetterAsNumber = patternNewValue;
                    patternNewValue++;
                }
                if(curLetterAsNumber != patternAsNumber[j]){
                    match = false;
                    break;
                }
            }
            if(match){
                ret.Add(words[i]);
            }
        }
        return ret;
    }
}
