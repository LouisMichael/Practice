function runningSum(nums: number[]): number[] {
let ret = new Array<number>(nums.length);
let sum = 0;
for(let i = 0; i<nums.length;i++){
    sum += nums[i];
    ret[i] =sum;
}
return ret;
};
