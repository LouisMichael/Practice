// I am like 90% sure this is a two pointer problem
function removeDuplicates(nums: number[]): number {
    let write = 0;
    for(let i = 0; i<nums.length;i++){
        if(i > 0 && nums[i] == nums[write-1]){
            continue;
        }
        else{
            nums[write] = nums[i];
            write++;
        }
    }
    return write;
};
