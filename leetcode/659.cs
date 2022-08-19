public class Solution {
    public bool IsPossible(int[] nums) {
//         at every number we can either start a new subsequance or we can add to an existing one
//         I think whenever possible we will want to add to an existing one, since the next time that value is encountered will be the same or worse
//         then I don't know the best way to find if the next element can go onto an existing subsequence, we can have a list but this will be worst case n^2
//         we can make this a little simpler using a hash map or sequances
//         you can have more then one subsequance looking for  the same value, you will want to add to the smaller one
        Dictionary<int,PriorityQueue<int,int>> subSequances = new Dictionary<int,PriorityQueue<int,int>>();
        for(int i = 0; i<nums.Length;i++){
            int tempCount = 0;
            if(subSequances.ContainsKey(nums[i]) && subSequances[nums[i]].Count > 0){
                tempCount = subSequances[nums[i]].Dequeue();
            }
            if(subSequances.ContainsKey(nums[i]+1)){
                    subSequances[nums[i]+1].Enqueue(tempCount+1,tempCount+1);
            }
            else{
                subSequances[nums[i]+1] = new PriorityQueue<int,int>();
                subSequances[nums[i]+1].Enqueue(tempCount+1,tempCount+1);
            }
        }
        bool ret = true;
        foreach(int i in subSequances.Keys){
            while(subSequances[i].Count > 0){
               int subSequanceCount = subSequances[i].Dequeue();
                Console.WriteLine(subSequanceCount);
               ret = ret && (subSequanceCount >= 3);
            }
        }
        return ret;
    }
}
