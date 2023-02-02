public class Solution {
//     a way to do this is to have a max so far for every word, and if it is broken return false
    public bool IsAlienSorted(string[] words, string order) {
        Dictionary<char, int> orderRef = new Dictionary<char, int>();
        for(int i = 0; i<order.Length;i++){
            orderRef[order[i]] = i;
        }
        int maxSoFar = -1;
        for(int i = 0; i<words.Length-1;i++){
            if(this.Compare(words[i],words[i+1],orderRef) > 0){
                return false;
            }
        }
        return true;
    }
    // return a negative number if s1 is less then s2, 0 if they are the same and positve number if s1 is larger then s2;
    public int Compare(string s1, string s2, Dictionary<char, int> orderRef){
        for(int i =0; i<Math.Min(s1.Length,s2.Length);i++){
            if(s1[i] != s2[i]){
                return orderRef[s1[i]] - orderRef[s2[i]];
            }
        }
        return s1.Length - s2.Length;
    }
}
