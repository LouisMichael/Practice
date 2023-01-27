public class Solution {
    public IList<string> FindAllConcatenatedWordsInADict(string[] words) {
        // I think this is an okay try problem, we want to run over the list and build the tri, then we want to run over the words again and 
        // if they hit a stop in the traversal we will start an additonal traversal from the top, 
        // Step 1 build the tri
        Tri tri = new Tri();
        List<string> ret = new List<string>();
        foreach(string word in words){
            tri.Add(word);
        }
        foreach(string word in words){
            Queue<TriNode> queue = new Queue<TriNode>();
            queue.Enqueue(tri.root);
            for(int j = 0; j<word.Length;j++){
                int queueSize = queue.Count();
                for(int i = 0; i< queueSize;i++){
                    TriNode cur = queue.Dequeue();
                    // Console.WriteLine(cur.val);
                    if(cur.end && tri.root.next[word[j]-'a'] != null){
                        queue.Enqueue(tri.root.next[word[j]-'a']);
                        // Console.WriteLine("found a possible subword");
                    }
                    if(cur.next[word[j]-'a'] != null){
                        queue.Enqueue(cur.next[word[j]-'a']);
                        // Console.WriteLine("found a path forward");
                    }
                }
            }
            int wordCount = 0;
            // Console.WriteLine(queue.Count);
            while(queue.Count > 0){
                TriNode cur = queue.Dequeue();
                // Console.WriteLine(cur.val);
                if(cur.end){
                    wordCount++;
                    // Console.WriteLine(wordCount);
                    if(wordCount > 1){
                        ret.Add(word);
                        break;
                    }
                }
            }
        }
        return ret;
    }
    public class Tri{
        public TriNode root;
        public Tri(){
            this.root = new TriNode(' ');
        }
        public void Add(string s){
            TriNode cur = this.root;
            for(int i =0; i< s.Length;i++){
                if(cur.next[s[i]-'a'] == null){
                    cur.next[s[i]-'a'] = new TriNode(s[i]);
                }
                cur = cur.next[s[i]-'a'];
            }
            cur.end = true;
            // Console.WriteLine(s);
        }
    }
    public class TriNode{
        public bool end;
        public TriNode[] next;
        public char val;
        public TriNode(char val){
            this.next = new TriNode[26];
            this.val = val;
        }
    }
}
