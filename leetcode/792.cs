public class Solution {
    public int NumMatchingSubseq(string s, string[] words) {
//         my first thought is to make a structure kind of like a try crossed with a greedy algorithm
//         we build a structure that is the position of every letter + occurance then we loop over the other words and
//         see if we can take the next lowest of each of the letters, if we get to the end of the word we incrment our output
        IList<int>[] letterPostions = new IList<int>[26];
        int ret = 0;
        for(int i = 0; i<26;i++){
            letterPostions[i] = new List<int>();
        }
        for(int i = 0; i<s.Length;i++){
            letterPostions[s[i]-'a'].Add(i);
        }
        for(int i = 0; i<words.Length;i++){
            int cur = 0;
            bool wholeWord = true;
            for(int j = 0; j<words[i].Length;j++){
                int curWordLetterAsNum = words[i][j]-'a';
                bool found = false;
                for(int x = 0; x < letterPostions[curWordLetterAsNum].Count; x++){
                    
                    if(letterPostions[curWordLetterAsNum][x] >= cur){
                        cur = letterPostions[curWordLetterAsNum][x]+1;
                        found = true;
                        break;
                    }
                }
                if(!found){
                    wholeWord = false;
                    break;
                }
            }
            if(wholeWord){
               ret++; 
            }
        }
        return ret;
    }
}
