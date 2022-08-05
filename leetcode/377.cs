class Solution {
//     my first thought is about trying to make a grid, where you subtract each 
//     value from target and at the end the value you get for 0 is the solve.
    public int[] mem;
    public int CombinationSum4(int[] nums, int target) {
        this.mem = new int[target+1];
        for(int i = 0; i<this.mem.Length;i++){
            this.mem[i] = -1;
        }
        return this.combinationSum4Recur(nums, target);
    }
    public int combinationSum4Recur(int[] nums, int target) {
        if(target == 0){
            return 1;
        }
        if(target < 0){
            return -1;
        }
        if(this.mem[target] > -1){
            return this.mem[target];
        }
        int ret = 0;
        for(int i = 0; i<nums.Length;i++){
            int temp = this.combinationSum4Recur(nums, target-nums[i]);
            if(temp >=0){
                ret += temp;
            }
        }
        // Console.WriteLine("target: " + target + " ret: " + ret);
        this.mem[target] = ret;
        return ret;
    }
}
