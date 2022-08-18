// since I will not always use the full list I could have gotten some small speedup by using a heap intsead of a full sort
public class Solution {
    public int MinSetSize(int[] arr) {
//         We can just be greedy picking the most common ones until it is a total of half or more, so we just need to sort by the number of occurances
//         holds key which is the number, and val which is the number of times it apprears
        Dictionary <int, int> occurCount = new Dictionary <int, int>();
        for(int i = 0; i<arr.Length;i++){
            if(occurCount.ContainsKey(arr[i])){
                occurCount[arr[i]]++;
            }
            else{
                occurCount[arr[i]]=1;
            }
        }
        List<int> countList = occurCount.Values.ToList();
        countList.Sort();
        int total = 0;
        int ret = 0;
        while(total < arr.Length/2){
            total += countList[countList.Count-ret-1];
            ret++;
        }
        return ret;
    }
}
