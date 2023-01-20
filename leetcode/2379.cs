public class Solution {
    public int MinimumRecolors(string blocks, int k) {
        // I think this is a sliding window problem, we want to cout the number of W in a window of size k and then return the min
        int wCount = 0; 
        for(int i = 0; i< k;i++){
            if(blocks[i] == 'W'){
                wCount++;
            }
        }
        int min = wCount;
        int start = 0;
        int end = k;
        for(;end < blocks.Length;end++){
            start++;
            if(blocks[end] == 'W'){
                wCount++;
            } 
            if(blocks[start-1] == 'W'){
                wCount--;
            }
            // Console.WriteLine(wCount);
            min = Math.Min(min,wCount);
        }
        return min;
    }
}
