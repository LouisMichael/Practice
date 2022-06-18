// tri that is for lower case english words
public class Tri{
    public TriNode root;
    public class Tri(){
        this.root = new TriNode(''); 
    }
    public void AddWord(sting word){
        TriNode cur = this.root;
        for(int i = 0; i<word.Length; i++){
            if(cur.next[word[i]-'a'] == null){
                cur.next[word[i]-'a'] = new TriNode(word[i]-'a');
            }
            cur = cur.next[word[i]-'a'];
        }
        cur.isValid = true;
    }
    public List<string> FindWordStartingWith(string prefex){
        
        TriNode cur = this.root;
        for(int i = 0; i<prefex.Length;i++){
            if(cur.next[prefex[i]-'a'] != null){
                cur = cur.next[prefex[i]-'a'];
            }
            else{
                return null;
            }
        }
        return this.listWordsFrom(prefex, cur);
        
    }
    public List<string> listWordsFrom(string prefex, TriNode cur){
        List<string> retList = new List<string>();
        if(cur.isValid){
            retList.Add(prefex);
        }
        for(int i = 0; i< cur.next.Length;i++){
            if(cur.next[i] != null){
                List<string> temp = listWordsFrom(prefex + ('a'+i), cur.next[i]);
                for(int j = 0; j<temp.Count;j++){
                    retList.Add(temp[j]);
                }
            }
        }
        return retList;
    }
   public class TriNode {
       public char cur;
       public TriNode[] next;
       public bool isValid;
       public TriNode(char newCur) {
           this.isValid = false;
           this.cur = newCur;
           this.next = new TriNode[26]; 
       }
   } 
}
