public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        List<IList<int>> ret = new List<IList<int>>();
        for(int i = 1; i<numRows+1; i++){
            IList<int> temp = new List<int>();
            for(int j = 0; j < i; j++){
                if(j == 0 || j == i-1){
                    temp.Add(1);
                }
                else{
                    temp.Add(ret[i-2][j-1] + ret[i-2][j]);
                }
            }
            ret.Add(temp);
        }
        return ret;
    }
}
