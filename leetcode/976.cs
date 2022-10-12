public class Solution {
//     I am thinking about what is a valid triangle
//     I think it is just a senario where two short legs add up to more then the third leg
//     If they are equal you have to make a line to get to the same length if they are more there is some angel to make it work
    public int LargestPerimeter(int[] nums) {
        Array.Sort(nums);
        int longLeg1 = nums[nums.Length-1];
        int longLeg2 = nums[nums.Length-2];

        for(int i = nums.Length-3;i>=0;i--){
            if(nums[i] + longLeg2 > longLeg1){
                return nums[i] + longLeg2 + longLeg1;
            }
            longLeg1 = longLeg2;
            longLeg2 = nums[i];
        }
        return 0;
    }
}
