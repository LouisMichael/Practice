public class Solution {
    public int[] SearchRange(int[] nums, int target) {
//         my first thought is to do it as two phases of binary search 
//         first would be a standard search, second phase whould be to use the location that was found to run seprate searches for upper and lower
        int[] phase1Result = this.Phase1(nums, target, 0, nums.Length-1);
        if(phase1Result[0] == -1){
            return phase1Result;
        }
        else{
            return new int[] {this.Phase2Left(nums, target, phase1Result[0], phase1Result[1]), this.Phase2Right(nums, target, phase1Result[0], phase1Result[1])};
        }
    }
    public int[] Phase1(int [] nums, int target, int left, int right){
        if(left > right){
            return new int[] {-1,-1};
        }
        int mid = (left + right)/2;
        if(nums[mid] == target){
            return new int[] {left, right};
        }
        if(nums[mid]>target){
            return this.Phase1(nums, target, left, mid-1);
        }
        else{
            return this.Phase1(nums, target, mid+1, right);
        }
    }
    public int Phase2Left(int [] nums, int target, int left, int right){
        if(left > right){
            return -1;
        }
        int mid = (left + right)/2;
        if(nums[mid] == target && (mid == 0 || nums[mid-1] != target)){
            return mid;
        }
        if(nums[mid]>target || nums[mid] == target){
            return this.Phase2Left(nums, target, left, mid-1);
        }
        else{
            return this.Phase2Left(nums, target, mid+1, right);
        }
    }
    public int Phase2Right(int [] nums, int target, int left, int right){
        if(left > right){
            return -1;
        }
        int mid = (left + right)/2;
        if(nums[mid] == target && (mid == nums.Length-1 || nums[mid+1] != target)){
            return mid;
        }
        if(nums[mid]>target){
            return this.Phase2Right(nums, target, left, mid-1);
        }
        else{
            return this.Phase2Right(nums, target, mid+1, right);
        }
    }
}public class Solution {
    public int[] SearchRange(int[] nums, int target) {
//         my first thought is to do it as two phases of binary search 
//         first would be a standard search, second phase whould be to use the location that was found to run seprate searches for upper and lower
        int[] phase1Result = this.Phase1(nums, target, 0, nums.Length-1);
        if(phase1Result[0] == -1){
            return phase1Result;
        }
        else{
            return new int[] {this.Phase2Left(nums, target, phase1Result[0], phase1Result[1]), this.Phase2Right(nums, target, phase1Result[0], phase1Result[1])};
        }
    }
    public int[] Phase1(int [] nums, int target, int left, int right){
        if(left > right){
            return new int[] {-1,-1};
        }
        int mid = (left + right)/2;
        if(nums[mid] == target){
            return new int[] {left, right};
        }
        if(nums[mid]>target){
            return this.Phase1(nums, target, left, mid-1);
        }
        else{
            return this.Phase1(nums, target, mid+1, right);
        }
    }
    public int Phase2Left(int [] nums, int target, int left, int right){
        if(left > right){
            return -1;
        }
        int mid = (left + right)/2;
        if(nums[mid] == target && (mid == 0 || nums[mid-1] != target)){
            return mid;
        }
        if(nums[mid]>target || nums[mid] == target){
            return this.Phase2Left(nums, target, left, mid-1);
        }
        else{
            return this.Phase2Left(nums, target, mid+1, right);
        }
    }
    public int Phase2Right(int [] nums, int target, int left, int right){
        if(left > right){
            return -1;
        }
        int mid = (left + right)/2;
        if(nums[mid] == target && (mid == nums.Length-1 || nums[mid+1] != target)){
            return mid;
        }
        if(nums[mid]>target){
            return this.Phase2Right(nums, target, left, mid-1);
        }
        else{
            return this.Phase2Right(nums, target, mid+1, right);
        }
    }
}
