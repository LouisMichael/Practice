public class Solution {
    public bool IncreasingTriplet(int[] nums) {
// if you start on the left you have to check everything to see if there is a value greater then if you find it you have to keep going
//         can we skip some steps? we can find the valid set of nums[k] by keeping a copy of the greatest value seen going in from the right
//         then we can keep a value stored for j as the second largest, 
//         I think we can do it in one sweep by just establishing how to look for a final value
        Integer max = null;
        Integer secondGreatest = null;
        Integer minSearch = null;
        for(int i = nums.Length - 1; i >= 0; i--){
            if(max == null || nums[i] > max.val){
                max = new Integer();
                max.val = nums[i];
                secondGreatest = null;
            }
            if(max != null && nums[i] < max.val && (secondGreatest == null || secondGreatest.val < nums[i])){
                secondGreatest = new Integer();
                secondGreatest.val = nums[i];
                if(minSearch == null || secondGreatest.val > minSearch.val){
                    minSearch = new Integer();
                    minSearch.val = nums[i];
                }
            }
            if(minSearch != null && nums[i] < minSearch.val){
                return true;
            }
        }
        return false;
    }
    public class Integer{
        public int val;
    }
}
