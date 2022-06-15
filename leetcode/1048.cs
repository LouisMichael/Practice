// Runtime: 127 ms, faster than 87.37% of C# online submissions for Longest String Chain.
// Memory Usage: 40 MB, less than 86.36% of C# online submissions for Longest String Chain.
// I went in the wrong direction I should have removed items and looked for existance
// I also missed that it was not really needed to worry about dups

public class Solution {
    public int LongestStrChain(string[] words) {
//         for every word we want to find every other word it is a predecessor of
        // then we can make this into a graph
//         I think maybe what we do is to bin all of the words by size, then at each size see we can 
        IList<WordChainValuePair>[] chainsByLength = new IList<WordChainValuePair>[17];
        for(int i = 0; i<chainsByLength.Length;i++){
            chainsByLength[i] = new List<WordChainValuePair>();
        }
        for(int i = 0; i<words.Length;i++){
            chainsByLength[words[i].Length].Add(new WordChainValuePair(words[i],1));
        }
        int maxChain = 1;
        for(int i = 0; i<chainsByLength.Length-1;i++){
            for(int j = 0; j<chainsByLength[i].Count;j++){
                for(int k = 0; k<chainsByLength[i+1].Count;k++){
                    if(this.InChain(chainsByLength[i][j].Item1, chainsByLength[i+1][k].Item1)){
                       if(chainsByLength[i+1][k].Item2 < chainsByLength[i][j].Item2 + 1){
                           chainsByLength[i+1][k].Item2 = chainsByLength[i][j].Item2 + 1;
                       }
                        if(chainsByLength[i+1][k].Item2 > maxChain){
                            maxChain = chainsByLength[i+1][k].Item2;
                        }
                    }
                }
            }
        }
        return maxChain;
    }
    public bool InChain(string word1, string word2){
        if(word2.Length != word1.Length+1){
            return false;
        }
        bool oneDiffFound = false;
        for(int i = 0; i<word1.Length;i++){
            if(!oneDiffFound){
                if(word1[i] != word2[i]){
                    if(word1[i] == word2[i+1]){
                        oneDiffFound = true;
                    }
                    else{
                        return false;
                    }
                }
            }
            else{
                if(word1[i] != word2[i+1]){
                    return false;
                }
            }
        }
        return true;
    }
    public class WordChainValuePair{
        public int Item2;
        public string Item1;
        public WordChainValuePair(string word, int count){
            this.Item1 = word;
            this.Item2 = count;
        }
    }
}
