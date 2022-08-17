public class Solution {
    public int UniqueMorseRepresentations(string[] words) {
//         We are just trainslating bundling and adding to a set
//         then giving back the size of the set
        Dictionary<string,int> setOfDistinctWords = new Dictionary<string,int>();
       string[] map = new string[]{".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."};
        for(int i = 0 ; i< words.Length; i++){
            string concat = "";
            for(int j = 0; j<words[i].Length; j++){
                concat = concat + map[words[i][j] - 'a'];
            }
            if(!setOfDistinctWords.ContainsKey(concat)){
                setOfDistinctWords[concat] = 1;
            }
        }
        return setOfDistinctWords.Count;
    }
}
