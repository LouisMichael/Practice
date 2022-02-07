// Runtime: 140 ms, faster than 14.81% of TypeScript online submissions for Remove Duplicates from Sorted Array II.
// Memory Usage: 44.9 MB, less than 25.93% of TypeScript online submissions for Remove Duplicates from Sorted Array II.
// My first intuatoin was correct in how to do this problem and the solve took about 15 min
function removeDuplicates(nums: number[]): number {
    let slowPointer: number = 0;
    let curNum: number = nums[0];
    let curNumCount: number = 0;
    for(let i = 0; i < nums.length; i++){
        let curPosVal = nums[i];
        if(curPosVal == curNum){
            curNumCount ++;
            if(curNumCount <= 2){
                nums[slowPointer] = nums[i];
                slowPointer++;
            }
        }
        else{
            curNum = curPosVal;
            curNumCount = 1;
            nums[slowPointer] = nums[i];
            slowPointer++;
        }
    }
    return slowPointer;
};
