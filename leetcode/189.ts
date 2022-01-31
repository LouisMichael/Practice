// Some of the intersting other ways to do this were to rotate more then once
// or to reverse the whole thing, then reverse k, then reverse the rest
/**
 Do not return anything, modify nums in-place instead.
 */
function rotate(nums: number[], k: number): void {
    let newArray = [];
    for(let i = 0; i < nums.length; i++){
        let offsetPos = (i + k)%(nums.length);
        // let temp = ;
        newArray[offsetPos] = nums[i];
    }
    for(let i = 0; i < nums.length; i++){
        nums[i] = newArray[i];
    }
    // nums = newArray;
};
