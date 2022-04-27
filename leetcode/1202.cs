public class Solution {
    public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs) {
//         I think we just keep swapping until we do a pass where we do not swap
//         maybe we do a speedup where we only start trying swaps again if there is some change to them.
//         maybe we can skip actually doing the swaps just by figuring out what sections are connected and then sorting the sections that are connected
//         since it is a coloring probelm we could use a union join datastructure
     
        

        UnionFindFlaterSet<int> unionFindSet = new UnionFindFlaterSet<int>();
        char[] ret = new char[s.Length];
        for(int i = 0; i<s.Length;i++){
            unionFindSet.Add(i);
        }
        //         run over the pairs and merge all the colors

        for(int i = 0; i<pairs.Count;i++){
            unionFindSet.Merge(pairs[i][0], pairs[i][1]);
        }
    //         run over the colors and get their strings
        foreach(List<int> list in unionFindSet.GetSets()){
//             run over the list build the sub string
            List<char> subString = new List<char>();
//             and the list of positons
            List<int> posList = new List<int>();
            foreach(int cur in list){
                // Console.WriteLine(cur.val);
                subString.Add(s[cur]);
                posList.Add(cur);
            }
//             sort both lists so we can then use them to add to a final version
            subString.Sort();
            posList.Sort();
            for(int i = 0; i<posList.Count; i++){
                ret[posList[i]] = subString[i];
            }
        }
        return new string(ret);
    }
}
public class UnionFindFlaterSet<T> { 
    public Dictionary<T, Node<T>> valToNodeMap;
    public UnionFindFlaterSet(){
        this.valToNodeMap = new Dictionary<T, Node<T>>();
    }
    public void Add(T val){
        Node<T> newNode = new Node<T>(val);
        this.valToNodeMap.Add(val, newNode);
    }
    public void Merge(T val1, T val2){
        Node<T> val1Top = this.valToNodeMap[val1];
        int val1Rank = 0;
        while(val1Top.next != null){
            val1Top = val1Top.next;
            val1Rank++;
        }
        Node<T> val2Top = this.valToNodeMap[val2];
        int val2Rank = 0;
        while(val2Top.next != null){
            val2Top = val2Top.next;
            val2Rank++;
        }
        if(val1Top != val2Top){
            if(val2Rank > val1Rank){
                val1Top.next = val2Top;
                this.valToNodeMap[val1].next = val2Top;
            }
            else{
                val2Top.next = val1Top;
                this.valToNodeMap[val2].next = val1Top;
            }
        }
    }
    public List<List<T>> GetSets(){
        Dictionary<T, List<T>> sets = new Dictionary<T, List<T>>();
        foreach(T val in this.valToNodeMap.Keys){
            Node<T> valTop = this.valToNodeMap[val];
            while(valTop.next != null){
                valTop = valTop.next;
            }
            if(sets.ContainsKey(valTop.val)){
                sets[valTop.val].Add(val);
            }
            else{
                sets[valTop.val] = new List<T>();
                sets[valTop.val].Add(val);
            }
        }
        List<List<T>> ret = new List<List<T>>();
        foreach(T key in sets.Keys){
            ret.Add(sets[key]);
        }
        return ret;
    }
}

// This makes these long lists but they are not flat which is actually kind of the point of fast find.
// that results in too much time trying to find the end of lists and my TLE on first submissoin
public class UnionFindSetLongChains<T> {
    public Dictionary<Node<T>, Node<T>> distinctSetPairsHeadToTail;
    public Dictionary<Node<T>, Node<T>> distinctSetPairsTailToHead;
    public Dictionary<T, Node<T>> valToNodeMap;
    public UnionFindSetLongChains(){
        this.distinctSetPairsHeadToTail = new Dictionary<Node<T>,Node<T>>();
        this.distinctSetPairsTailToHead = new Dictionary<Node<T>,Node<T>>();

        this.valToNodeMap = new Dictionary<T, Node<T>>();
    }
    public void Add(T val){
        Node<T> newNode = new Node<T>(val);
        this.valToNodeMap.Add(val, newNode);
        this.distinctSetPairsHeadToTail.Add(newNode, newNode);
        this.distinctSetPairsTailToHead.Add(newNode, newNode);
    }
    public void Merge(T val1, T val2){
        Node<T> val1Tail = this.valToNodeMap[val1];
        while(val1Tail.next != null){
            val1Tail = val1Tail.next;
        }
        Node<T> val2Tail = this.valToNodeMap[val2];
        while(val2Tail.next != null){
            val2Tail = val2Tail.next;
        }
        if(val1Tail != val2Tail){
            // Console.WriteLine("trying to merge: " + val1Tail.val + " with " + val2Tail.val);
            val1Tail.next = this.distinctSetPairsTailToHead[val2Tail];
//             point val1 head to val2Tail
            this.distinctSetPairsHeadToTail[this.distinctSetPairsTailToHead[val1Tail]] = val2Tail;
            this.distinctSetPairsHeadToTail.Remove(this.distinctSetPairsTailToHead[val2Tail]);
            
            this.distinctSetPairsTailToHead[val2Tail] = this.distinctSetPairsTailToHead[val1Tail];
            this.distinctSetPairsTailToHead.Remove(val1Tail);
        }
    }
    
}
public class Node<T> {
    public T val;
    public Node<T> next;
    public Node(T val){
        this.val = val;
    }
}
