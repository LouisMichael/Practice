// I am trying to figure out why this is not just a mapping operation where we go over the list
// and ever time we see a number if we have its complement we will remove both from the map and add 1 to the return value
// that seemed simple but it worked
// Runtime: 308 ms, faster than 41.94% of C# online submissions for Max Number of K-Sum Pairs.
// Memory Usage: 45.4 MB, less than 87.10% of C# online submissions for Max Number of K-Sum Pairs.
// there is also a cool way to do it in costant space where you sort the list and then index in from both sides to find matches
public class Solution {

    public int MaxOperations(int[] nums, int k) {
        Dictionary<int,int> countOfNum = new Dictionary<int, int>();
        int ret = 0;
        foreach(int num in nums){
            if(countOfNum.ContainsKey(k - num) && countOfNum[k - num]>0){
                ret++;
                countOfNum[k - num]--;
            }
            else{
                if(countOfNum.ContainsKey(num)){
                    countOfNum[num]++;
                }
                else{
                    countOfNum[num] = 1;
                }
            }
        }
        return ret;
    }
}
