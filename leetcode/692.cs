public class Solution {
    public IList<string> TopKFrequent(string[] words, int k) {
        Dictionary<string,int> counts = new Dictionary<string,int>();
        for(int i = 0; i<words.Length;i++){
            if(counts.ContainsKey(words[i])){
                counts[words[i]]++;
            }
            else{
                counts[words[i]] = 1;
            }
        }
        string[] keys = counts.Keys.ToArray();
        Array.Sort(keys, new CountsComparitor(counts));
        List<string> ret = new List<string>();
        for(int i = 0; i<k;i++){
            ret.Add(keys[i]);
        }
        return ret;
    }
    public class CountsComparitor: IComparer<string>{
        private Dictionary<string,int> counts;
        public CountsComparitor(Dictionary<string,int> counts){
            this.counts = counts;
        }
        public int Compare(string a, string b){
            if(counts[b] - counts[a] != 0){
                return counts[b] - counts[a];
            }
            else{
                return StringComparer.CurrentCulture.Compare(a, b);
            }
        }
    }
    
}
