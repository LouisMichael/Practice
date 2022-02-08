// Runtime: 131 ms, faster than 76.02% of TypeScript online submissions for Rotate Array.
// Memory Usage: 52.4 MB, less than 23.28% of TypeScript online submissions for Rotate Array.

/**
 Do not return anything, modify nums in-place instead.
 */
function rotate(nums: number[], k: number): void {
//     invert the array
    k = k % nums.length;
    nums = nums.reverse();
    for(let i = 0; i < Math.floor(k/2); i++){
        let temp = nums[i];
        nums[i] = nums[k-i-1];
        nums[k-i-1] = temp;
    }
    for(let i = 0; i < Math.floor((nums.length-k)/2); i++){
        let temp = nums[k+i];
        nums[k+i] = nums[nums.length-1-i];
        nums[nums.length-1-i] = temp;
    }
};
