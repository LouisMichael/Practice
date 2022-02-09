// Start time 12:09
// Runtime: 143 ms, faster than 55.54% of TypeScript online submissions for Move Zeroes.
// Memory Usage: 48.6 MB, less than 5.11% of TypeScript online submissions for Move Zeroes.
/**
 Do not return anything, modify nums in-place instead.
 */
function moveZeroes(nums: number[]): void {
    let posSlow = 0;
    let posFast = 0;
    for(let num of nums){
        if(num == 0){
            posFast++;
            nums[posSlow] = nums[posFast];
        }
        else{
            nums[posSlow] = nums[posFast];
            posFast ++;
            posSlow++;
        }
    }
    for(;posSlow < nums.length;posSlow++){
        nums[posSlow] = 0;
    }
};
// finsish time 12:14
