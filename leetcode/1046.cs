// Runtime: 161 ms, faster than 9.36% of C# online submissions for Last Stone Weight.
// Memory Usage: 36.5 MB, less than 87.19% of C# online submissions for Last Stone Weight.
public class Solution {
    public int LastStoneWeight(int[] stones) {
//         Se we want a datastructure that stays sorted and then we leverage it to play the game? 
//         c# sorted list is not a perfect fit because it does not support duplicate entries
//         since sontes.Length is small  it may be okay to just call a resort at the end of every round
//         the name of the strucutre that I wanted was a heap, forgot that one, in C# priorityQueue is the name of the impletation I wanted
        int count = stones.Length;
        while(count > 1){
            Array.Sort(stones,0,count);
            // for(int i = 0; i< count;i++){
            //     Console.WriteLine(stones[i]);
            // }
            // Console.WriteLine("-------------");
            int largest = stones[count-1];
            int secondLargets = stones[count - 2];
            stones[count-1] = 0;
            stones[count-2] = largest-secondLargets;
            if(largest == secondLargets){
                count -= 2;
            }
            else{
                count -= 1;
            }
        }
        return stones[0];
    }
}
