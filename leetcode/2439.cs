public class Solution {
    public int MinimizeArrayValue(int[] nums) {
        // the one move we can do is decrease a value & increase the value of one behind it
        // we can vizulize this as moving points from right to left
        // I think we can solve in n time, you go from left to right and you keep track of the max to the left, and the number of openings to move stuff into
        long maxToLeft = nums[0];
        long holes = 0;
        for(int i = 1; i<nums.Length;i++){
            long diff = nums[i] - maxToLeft;
            // Console.WriteLine(diff);
            if(diff > 0){
                if(holes > diff){
                    holes -= diff;
                }
                else{
                    diff -= holes;
                    if((diff % (i+1)) > 0){
                        holes = (i+1) - (diff % (i+1));
                    }
                    else{
                        holes = 0;
                    }
                    maxToLeft += (diff/(i+1));
                    if(holes > 0){
                        maxToLeft += 1;
                    }
                }
            }
            else{
                holes += diff * -1;
            }
        }
        return (int)maxToLeft;
    }
}
// this is solved with fewer lines by noting that we simply take the max of the current max min, and a possible new max min. 
