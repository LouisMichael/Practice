// I liked the explenation I read about how when we move the lower pointer towards the middle we are elminating all of the combinations that use it 
// but we can show all of the combinationas that use this point are the same or smaller. 

// Runtime: 265 ms, faster than 44.03% of C# online submissions for Container With Most Water.
// Memory Usage: 44.8 MB, less than 87.77% of C# online submissions for Container With Most Water.
public class Solution {
    public int MaxArea(int[] height) {
        int left = 0;
        int right = height.Length-1;
        int max = 0;
        while(left < right){
            int cur = Math.Min(height[left],height[right]) * (right - left);
            if(cur > max){
                max = cur;
            }
            if(height[right]>height[left]){
                left ++;
            }
            else{
                right --;
            }
        }
        return max;
    }
}
