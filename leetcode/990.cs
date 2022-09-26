// I got way to fancy in my Union Find implemntation, I could have just used single letters as my storage and made everything smaller and faster
// I also did not do a good job of thinking of test cases, missing two looping fail cases
public class Solution {
    public bool EquationsPossible(string[] equations) {
//         I think this is a union find thing, since we want to set by step build groups and then some links may merge big groups together
        UnionFind unionFind = new UnionFind();
        foreach(string s in equations){
            if(s[1] == '='){
                unionFind.Add(s[0]);
                unionFind.Add(s[3]);
                unionFind.Merge(s[0], s[3]);
            }
        }
        foreach(string s in equations){
            if(s[1] == '!'){
                unionFind.Add(s[0]);
                unionFind.Add(s[3]);
                UnionFindNode first = unionFind.dict[s[0]];
                UnionFindNode second = unionFind.dict[s[3]];
                while(first.next != unionFind.head){
                    first = first.next;
                }
                while(second.next != unionFind.head){
                    second = second.next;
                }
                if(first == second){
                    return false;
                }
            }
        }
        return true;
    }
    public class UnionFind{
        public UnionFindNode head;
        public Dictionary<char, UnionFindNode> dict;
        public UnionFind(){
            this.dict = new Dictionary<char, UnionFindNode>();
        }
        public void Merge(char firstChar, char secondChar){
            if(firstChar == secondChar){
                return;
            }
            UnionFindNode first = this.dict[firstChar];
            UnionFindNode second = this.dict[secondChar];

            while(first.next != this.head){
                first = first.next;
            }
            while(second.next != this.head){
                second = second.next;
            }
            if(first == second){
                return;
            }
            if(first.prev.Count < second.prev.Count){
                UnionFindNode temp = second;
                second = first;
                first = temp;
            }
            first.prev.Add(second);
            second.next = first;
            foreach(UnionFindNode node in second.prev.ToList()){
                first.prev.Add(node);
                node.next = first;
            }
            second.prev = new List<UnionFindNode>();
        }
        public void Add(char c){
            if(dict.ContainsKey(c)){
                return;
            }
            else{
                UnionFindNode adding = new UnionFindNode();
                adding.next = this.head;
                adding.val = c; 
                dict[c] = adding;
            }
        }
    }
    public class UnionFindNode{
            public UnionFindNode next;
            public char val;
            public List<UnionFindNode> prev;
            public UnionFindNode(){
                this.prev = new List<UnionFindNode>();
            }
        }
}
