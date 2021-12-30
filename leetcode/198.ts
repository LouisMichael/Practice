// Runtime: 80 ms, faster than 55.21% of TypeScript online submissions for House Robber.
// Memory Usage: 40.7 MB, less than 14.31% of TypeScript online submissions for House Robber.
// This could be done in a more iterative way since you only need to look at the positions directly around you at the time of deciding. 
let dynamicSolve:number[];

function rob(nums: number[]): number {
    dynamicSolve = [];
    for(let i = 0; i < nums.length; i++){
        dynamicSolve.push(-1);
    }
    return robRecur(nums, 0);
};

function robRecur(nums: number[], pos: number){
    if(pos >= nums.length){
        return 0;
    }
    if(dynamicSolve[pos] !== -1){
        return dynamicSolve[pos];
    }
    else{
        let temp = Math.max(robRecur(nums, pos + 1), nums[pos]+ robRecur(nums, pos + 2));
        dynamicSolve[pos] = temp;
    }
    return dynamicSolve[pos];
}
