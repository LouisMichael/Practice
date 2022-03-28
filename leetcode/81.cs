public class Solution {
//     I think the best way is binary search with some extra logic around finding the pivot
//     another problem that this made me think of but that is not actually related is the putting a rotated array back
//     the trick in this other problem was to flip the diffrent sections but this will be linear where this problem should be able 
//     to be solved faster, a nieve search of the space would be linear just check if any element is the one we want
    
//     I took a lot of tries, mostly around not thinking about how having items that would be the same would work, I ended up looking at the provided solve to wrap up
    public bool Search(int[] nums, int target) {
        int left = 0;
        int right = nums.Length-1;
        while(left<=right){
            int mid = (left+right)/2;
            if(nums[mid]==target){
                return true;
                
            }
            if (!isBinarySearchHelpful(nums, left, nums[mid])) {
                left++;
                continue;
            }
            if(nums[left] < nums[right]){
//                 regular search
                if(nums[mid] < target){
                    left=mid+1;
                }
                else{
                    right = mid-1;
                }
            }
            if(nums[left] < nums[mid]){
//                 pivot is in the right
                if(nums[mid] < target){
                    left = mid+1;
                }
                else{
                    if(nums[left]>target){
                        left=mid+1;
                    }
                    else{
                        right = mid-1;
                    }
                }
            }
            else{
//                 pivot is in the left
                if(nums[mid] < target){
                    if(nums[right]<target){
                        right = mid -1;
                    }
                    else{
                        left = mid+1;
                    }
                }
                else{
                    right=mid-1;
                }
            }
        }
        return false;
    }
    // returns true if we can reduce the search space in current binary search space
    private bool isBinarySearchHelpful(int[] arr, int start, int element) {
        return arr[start] != element;
    }
}
