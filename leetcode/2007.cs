public class Solution {
    public int[] FindOriginalArray(int[] changed) {
//         if we sort it we will run into our values in a way we can expect
//         going from smallest to largest, every small value that is not part of an
//         existing pair must be the smaller value in a new pair
        if(changed.Length % 2 != 0){
            return new int[0];
        }
        Array.Sort(changed);
        int pairsFound = 0;
        int[] ret = new int[changed.Length/2];
//         the key is the value, the first value of the tuple is the count of times it should be doubled and the second value is how many times it has
        Dictionary<int,(int,int)> matchedCount = new Dictionary<int,(int,int)>();
        for(int i = 0; i < changed.Length;i++){
            if(changed[i]%2 == 0 && matchedCount.ContainsKey(changed[i]/2) && matchedCount[changed[i]/2].Item1 > matchedCount[changed[i]/2].Item2){
                matchedCount[changed[i]/2]=(matchedCount[changed[i]/2].Item1 ,matchedCount[changed[i]/2].Item2+1);
                if(pairsFound < ret.Length){
                    ret[pairsFound] = changed[i]/2;
                }
                pairsFound++;
            }
            else{
                if(!matchedCount.ContainsKey(changed[i])){
                    // Console.WriteLine(changed[i] + " did not find a match");
                    matchedCount[changed[i]] = (1,0); 
                }
                else{
                    matchedCount[changed[i]] = (matchedCount[changed[i]].Item1+1, matchedCount[changed[i]].Item2);
                }
            }
        }
        if(pairsFound*2 == changed.Length){
            return ret;
        }
        else{
            return new int[0];
        }
    }
}
