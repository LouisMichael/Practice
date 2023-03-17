public class Trie {
    public TriNode root;
    public Trie() {
        this.root = new TriNode();
    }
    
    public void Insert(string word) {
        TriNode cur = this.root;
        for(int i = 0; i<word.Length;i++){
            int nextVal = word[i] - 'a';
            if(cur.next[nextVal] == null){
                cur.next[nextVal] = new TriNode();
            }
            cur = cur.next[nextVal];
        }
        cur.valid = true;
    }
    
    public bool Search(string word) {
        TriNode cur = this.root;

        for(int i = 0; i<word.Length;i++){
            int nextVal = word[i] - 'a';
            if(cur.next[nextVal] == null){
                return false;
            }
            cur = cur.next[nextVal];
        }
        return cur.valid;
    }
    
    public bool StartsWith(string prefix) {
        TriNode cur = this.root;

        for(int i = 0; i<prefix.Length;i++){
            int nextVal = prefix[i] - 'a';
            if(cur.next[nextVal] == null){
                return false;
            }
            cur = cur.next[nextVal];
        }
        return true;
    }

    public class TriNode{
        public TriNode[] next;
        public bool valid;
        
        public TriNode(){
            this.next = new TriNode[26];
        }
    } 
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
