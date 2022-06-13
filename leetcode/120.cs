public class Solution {
//     this seems like a dp problem, I don't know if bottom up is beeter then top down or not, I think since there are only two options at a given spot maybe bottom up is simpler
//     I think we only ever need to store two layers at a time since the best next step can be seen in the last step
    public int MinimumTotal(IList<IList<int>> triangle) {
        IList<int> lastLayerSolve = triangle[triangle.Count-1];
        for(int j = triangle.Count-2; j>=0; j--){
            IList<int> curLayerSolve = new List<int>();
            for(int i = 0; i<triangle[j].Count;i++){
                curLayerSolve.Add(triangle[j][i]+Math.Min(lastLayerSolve[i],lastLayerSolve[i+1]));
            }
            lastLayerSolve = curLayerSolve;
        }
        return lastLayerSolve[0];
    }
}
