public class Solution {
    public int FurthestBuilding(int[] heights, int bricks, int ladders) {
//         dp fits okay here since we can make a set number of choices to move the state forward
//         greedy seems like it would be good becuase we would like to use ladders for the largest sections and briks sparingly
//         the minimum we will be able to get through is the number of ladders, so we could put stuff in a min heap of the ladder count + one at a time pop off one that we would have to use bricks for. I think this is a cool intuiton so I will start with writing it this way
//         since c# does not seem to have a built in min heap I will just use a min piority que
        
//         the key is the index for which the transiton will follow
//         the piroity is the size of this transitoin 
        PriorityQueue<int, int> bankQueue = new PriorityQueue<int, int>(new ReverseComparer());
        int ret = 0;
        for(int i = 0; i < heights.Length-1 && i < ladders;i++){
            bankQueue.Enqueue(heights[i+1]-heights[i], heights[i+1]-heights[i]);
            ret ++;
        }
        while(bricks >= 0 && ret+1 < heights.Length){
            bankQueue.Enqueue(heights[ret+1]-heights[ret], heights[ret+1]-heights[ret]);
            int nextSmallestJump = bankQueue.Dequeue();
            // Console.WriteLine(nextSmallestJump);
            if(nextSmallestJump > 0){
                bricks -= nextSmallestJump;
            }
            
            if(bricks >= 0){
                ret++;
            }
        }
        return ret;
    }
}

public class ReverseComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        return x-y;  
    }
}
