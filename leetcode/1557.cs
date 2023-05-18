public class Solution {
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges) {
        // we can think of each node as a tree, it may also be in another tree
        // we want to return the root node of all trees
        // more simply can we just return the list of all nodes with no input, since we are garenteed no cycle
        int[] inDegree = new int[n];
        foreach(IList<int> edge in edges){
            inDegree[edge[1]]++;
        }
        List<int> ret = new List<int>();
        for(int i = 0; i<n; i++){
            if(inDegree[i] == 0){
                ret.Add(i);
            }
        }
        return ret;
    }
}
