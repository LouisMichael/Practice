// Runtime: 123 ms, faster than 32.38% of TypeScript online submissions for Binary Search.
// Memory Usage: 46.1 MB, less than 13.56% of TypeScript online submissions for Binary Search.
function search(nums: number[], target: number): number {
    let minPos = 0;
    let maxPos = nums.length-1;
    while(minPos <= maxPos){
        let midPos = Math.floor((maxPos + minPos)/2);
        console.log(midPos);
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
    return -1;
};
