public class Solution {
    public int NumFactoredBinaryTrees(int[] arr) {
        Array.Sort(arr);
        Dictionary<int,long> subTreeCount = new Dictionary<int,long>();
        long ret = 0;
        for(int i = 0; i<arr.Length;i++){
            long factorCount = 1;
            for(int j = 0; j<i;j++){
                if(subTreeCount.ContainsKey(arr[i]/arr[j]) && arr[i]%arr[j] == 0){
                    factorCount = (factorCount+ subTreeCount[arr[i]/arr[j]]*subTreeCount[arr[j]])%1000000007;
                }
            }
            // Console.WriteLine(arr[i] + ": " + factorCount);
            subTreeCount[arr[i]] = factorCount;
            ret = (ret+(int)(subTreeCount[arr[i]]))%1000000007;
        }
        return (int)ret;
    }
}
