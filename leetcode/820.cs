public class Solution {
    public int MinimumLengthEncoding(string[] words) {
        //     the only words we can fully compress are words that are substrings of the suffix since they have to both end with #
//     a try of the reverse of the word could be good
    // and then the number you return is the size of the nodes that needed to be added to the try, no that is not quite right because you can't share if you split late
//     I guess it is a tri but if you need to split ever you take the full cost of the whole word
    
//     the solution points out that you do not need to take the time to sort if you count leaves at the end, I missed this asspect and made a more complex solve as a result
//     step one sort the list so that when we add we start with words that have to be their own section
        Array.Sort(words, (a,b)=>b.Length.CompareTo(a.Length));
        // foreach(string word in words){
        //     Console.WriteLine(word);
        // }
//     step two build the try and ever time we have to split add the total length of the word plus one for the termanator
        TriNode tri = new TriNode();
        int ret = 0;
        foreach(string word in words){
            string reverseword = new String(word.Reverse().ToArray());
            TriNode cur = tri;
            bool addWord = false;
            for(int i = 0; i< reverseword.Length;i++){
                if(cur.map.ContainsKey(reverseword[i])){
                    cur = cur.map[reverseword[i]];
                }
                else{
                    cur.map[reverseword[i]] = new TriNode();
                    cur = cur.map[reverseword[i]];
                    addWord = true;
                }
            }
            if(addWord){
                ret += reverseword.Length + 1;
            }
        }
        return ret;
    }
}
public class TriNode {
    public Dictionary<char,TriNode> map;
    public bool isValidEnd;
    public TriNode(){
        this.map = new  Dictionary<char,TriNode>();
        this.isValidEnd = false;
    }
}
