public class Solution {
    private Dictionary<int,List<int>> edgesDictionary;
    private Dictionary<char,List<int>> parentTreeLabels;
    private HashSet<int> visited;
    private int[] ret;
    public int[] CountSubTrees(int n, int[][] edges, string labels) {
        // since this is a tree not specificly a binary tree we want a fast way to get edges
        this.edgesDictionary = new Dictionary<int,List<int>>();
        this.parentTreeLabels = new Dictionary<char,List<int>>();
        this.visited = new HashSet<int>();
        foreach(int[] edge in edges){
            if(!edgesDictionary.ContainsKey(edge[0])){
                edgesDictionary[edge[0]] = new List<int>();
            }
            edgesDictionary[edge[0]].Add(edge[1]);
            if(!edgesDictionary.ContainsKey(edge[1])){
                edgesDictionary[edge[1]] = new List<int>();
            }
            edgesDictionary[edge[1]].Add(edge[0]);
        }
        this.ret = new int[n];
        this.CountSubTrees(0, labels);
        return ret;
    }
    private void CountSubTrees(int cur, string labels){
        if(this.visited.Contains(cur)){
            return;
        }
        this.visited.Add(cur);
        char curLabel = labels[cur];
        if(!this.parentTreeLabels.ContainsKey(curLabel)){
            this.parentTreeLabels[curLabel] = new List<int>();
        }
        this.parentTreeLabels[curLabel].Add(cur);
        foreach(int val in this.parentTreeLabels[curLabel]){
            this.ret[val]++;
        }
        
        foreach(int edge in this.edgesDictionary[cur]){
            this.CountSubTrees(edge,labels);
        }
        this.parentTreeLabels[curLabel].Remove(cur);
    }
}
