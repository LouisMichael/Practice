// Start time 10:08
// Finish 12:52
// Took 3 trys
// Try one I forgot to account for making sure the node I was on at the end actually repsersended the end of a word
// Second try I had a O(exonental) add time trying to build out a try that would search in linear time
// After looking at the discussion it seems the test cases don't fail on search back tracking through all diffrent options
// Runtime: 371 ms, faster than 42.42% of C# online submissions for Design Add and Search Words Data Structure.
// Memory Usage: 59.8 MB, less than 74.41% of C# online submissions for Design Add and Search Words Data Structure.
public class WordDictionary {
    public TriNode root;

    public WordDictionary() {
        this.root = new TriNode();
    }
    
    public void AddWord(string word) {
        this.AddWordAt(word, root);
    }
    
    public void AddWordAt(string word, TriNode root){
        if(word.Length == 0){
            root.isEnd = true;
            return;
        }
        int pos = word[0] - 'a';
        if(root.children[pos] == null){
            root.children[pos] = new TriNode();
        }
        this.AddWordAt(word.Substring(1), root.children[pos]);
    }
    
    public bool Search(string word) {
        return this.SearchOffset(word, 0, this.root);
    }
    public bool SearchOffset(string word, int pos, TriNode cur) {
        if(pos >= word.Length){
            return cur.isEnd;
        }
         if(word[pos] == '.'){
             bool foundWord = false;
            for(int i = 0; i<cur.children.Length; i++){
                if(cur.children[i] == null){
                    continue;
                }
                else{
                    foundWord = foundWord || this.SearchOffset(word, pos +1, cur.children[i]);
                }
            }
            return foundWord;
        }
        else{
            TriNode newCur = cur.children[word[pos] - 'a'];
            if(newCur == null){
                return false;
            }        
            else{
                return this.SearchOffset(word, pos +1,newCur);
            }
        }
    }
}


public class TriNode {
    public TriNode[] children;
    public TriNode(){
        this.children = new TriNode[26];
    }
    public bool isEnd = false;
}
