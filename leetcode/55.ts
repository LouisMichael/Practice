// I want to try a greedy approch, I think if you go to the next spot that will get you to the farthest next possible range, every time, you will 
function canJump(nums: number[]): boolean {
    let curMaxDistance = nums[0];
    for(let i = 0; i<nums.length;i++){
        if(i > curMaxDistance){
            return false;
        }
        if(i+nums[i] > curMaxDistance){
            curMaxDistance = i+nums[i];
        }
    }
    return true;
};
