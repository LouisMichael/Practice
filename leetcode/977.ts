// Start time 7:01
// end time 7:09
// Runtime: 189 ms, faster than 41.97% of TypeScript online submissions for Squares of a Sorted Array.
// Memory Usage: 49.6 MB, less than 12.84% of TypeScript online submissions for Squares of a Sorted Array.
function sortedSquares(nums: number[]): number[] {
    let leftPos = 0;
    let rightPos = nums.length -1;
    let solve: number[] = [];
    while(leftPos <= rightPos){
        if(Math.abs(nums[leftPos]) > Math.abs(nums[rightPos])){
            solve.push(nums[leftPos] * nums[leftPos])
            leftPos++;
        }
        else{
            solve.push(nums[rightPos] * nums[rightPos])
            rightPos--;
        }
    }
    return solve.reverse();
};
