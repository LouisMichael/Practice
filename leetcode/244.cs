public class WordDistance {
    public Dictionary<string, List<int>>  dict;
    public WordDistance(string[] wordsDict) {
        // Make a dictionary of all the loactions of a word
        this.dict = new Dictionary<string, List<int>>();
        for(int i = 0; i< wordsDict.Length; i++){
            string word = wordsDict[i];
            if(!this.dict.ContainsKey(word)){
                this.dict[word] = new List<int>();
            }
            this.dict[word].Add(i);
        }
    }
    
    public int Shortest(string word1, string word2) {
        List<int> listOfIndexForWord1 = this.dict[word1];
        List<int> listOfIndexForWord2 = this.dict[word2];
        int min = Math.Abs(listOfIndexForWord1[0]-listOfIndexForWord2[0]);
        // [1,4,10]
        // [3,8,20] 
        // int indexList1 = 0;
        // int indexList2 = 0;
        // while(indexList1 < listOfIndexForWord1.Count){

        // }
        for(int i = 0; i<listOfIndexForWord1.Count; i++){
            for(int j= 0; j<listOfIndexForWord2.Count; j++){
                min = Math.Min(Math.Abs(listOfIndexForWord1[i]-listOfIndexForWord2[j]), min);
            }
        }
        return min;
    }
}

/**
 * Your WordDistance object will be instantiated and called as such:
 * WordDistance obj = new WordDistance(wordsDict);
 * int param_1 = obj.Shortest(word1,word2);
 */
