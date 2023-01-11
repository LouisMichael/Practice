public class Solution {
    private HashSet<int> visted;
    private Dictionary<int, List<int>> edgesDict;
    public int MinTime(int n, int[][] edges, IList<bool> hasApple) {
        this.visted = new HashSet<int>();
        this.edgesDict = new Dictionary<int, List<int>>();
        for(int i = 0; i<edges.Length;i++){
            if(!this.edgesDict.ContainsKey(edges[i][0])){
                this.edgesDict[edges[i][0]] = new List<int>();
            }
            if(!this.edgesDict.ContainsKey(edges[i][1])){
                this.edgesDict[edges[i][1]] = new List<int>();
            }
            this.edgesDict[edges[i][0]].Add(edges[i][1]);
            this.edgesDict[edges[i][1]].Add(edges[i][0]);
        }
        return this.MinTimeRecur(0, hasApple);
    }
    public int MinTimeRecur(int cur, IList<bool> hasApple){

        List<int> edges = new List<int>();
        if(this.edgesDict.ContainsKey(cur)){
            edges = this.edgesDict[cur];
        }
        if(this.visted.Contains(cur)){
            return 0;
        }
        this.visted.Add(cur);
        int sumFetchApple = 0;
        // console.log(cur);
        for(int i = 0 ; i< edges.Count;i++){
            sumFetchApple += this.MinTimeRecur(edges[i], hasApple);
        }
        if(cur != 0 && (sumFetchApple > 0 || hasApple[cur])){
            sumFetchApple += 2;
        }
        return sumFetchApple;
    }
}
