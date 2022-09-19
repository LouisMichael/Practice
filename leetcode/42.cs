public class Solution {
    public int Trap(int[] height) {
//         we want the min of the max to the right vs the max to the left
        int[] maxFromLeft = new int[height.Length];
        int curMax = 0;
        for(int i = 0; i< height.Length;i++){
            if(height[i] > curMax){
                curMax = height[i];
            }
            maxFromLeft[i] = curMax;
        }
        curMax = 0;
        int ret = 0;

        for(int i = height.Length - 1; i >= 0; i--){
            if(height[i] > curMax){
                curMax = height[i];
            }
            ret += Math.Min(maxFromLeft[i], curMax) - height[i];
        }
        return ret;
    }
}
