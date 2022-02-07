// Runtime: 64 ms, faster than 97.95% of TypeScript online submissions for Search Insert Position.
// Memory Usage: 44.9 MB, less than 6.71% of TypeScript online submissions for Search Insert Position.
function searchInsert(nums: number[], target: number): number {
    let minPos = 0;
    let maxPos = nums.length-1;
    while(minPos <= maxPos){
        let midPos = Math.floor((maxPos + minPos)/2);
        // console.log(midPos);
        if(nums[midPos] == target){
            return midPos;
        }
        if(nums[midPos] > target){
            maxPos = midPos -1;
        }
        else{
            minPos = midPos + 1;
        }
    }
    if(nums[maxPos] > target){
        return maxPos - 1;
    }
    else{
        return maxPos + 1;
    }
};
