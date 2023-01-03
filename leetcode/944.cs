public class Solution {
    // this may be better refrased as counting not sorted colums
    // I am just going to run over all of the values and compare with the last value, if they are out of order I will add them to the set of out of order values
    // we can stop looking at stuff if we look down the colum instead of across
    public int MinDeletionSize(string[] strs) {
        bool[] outOfOrder = new bool[strs[0].Length];
        for(int i =1; i<strs.Length;i++){
            for(int j = 0; j<strs[i].Length;j++){
                if(strs[i-1][j]-'a' > strs[i][j]-'a'){
                    outOfOrder[j] = true;
                }
            }
        }
        int outOfOrderCount = 0;
        for(int j = 0; j<outOfOrder.Length;j++){
            if(outOfOrder[j]){
                outOfOrderCount++;
            }
        }
        return outOfOrderCount;
    }
}
