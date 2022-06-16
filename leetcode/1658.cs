public class Solution {
//     this feels like a memo problem? At each step you can either remove from right or left, if you get under 0 at any point you can't do it from that state
//     we oom on memo?! It does not feel like this is too big
//     maybe there is a better way to do it with just one pass from each side?
//     since we are monotic decreasing in either direction we can get a dictionary of the index from one side and the total it pulls out
//     and then going from the other side we can similarly see if there is a valid pair
    public Dictionary<int, int> valuesFromTheLeft;
    public int MinOperations(int[] nums, int x) {
        int cur = 0;
        this.valuesFromTheLeft = new Dictionary<int, int>();
        for(int i = 0; i<nums.Length;i++){
            cur+=nums[i];
            valuesFromTheLeft[cur] = i;
        }
        int minNumberOfMoves = -1;
        if(x == 0){
            return 0;
        }
        if(valuesFromTheLeft.ContainsKey(x)){
            minNumberOfMoves = valuesFromTheLeft[x]+1;
        }
        cur = 0;
        for(int i = nums.Length-1; i>=0; i--){
            cur += nums[i];
            // Console.WriteLine(cur);
            if(valuesFromTheLeft.ContainsKey(x-cur) && valuesFromTheLeft[x-cur] < i){
                int total = nums.Length - i + valuesFromTheLeft[x-cur] +1;
                if(total < minNumberOfMoves|| minNumberOfMoves < 0){
                    minNumberOfMoves = total;
                }
            }
            if(cur == x){
                int total = nums.Length - i;
                if(total < minNumberOfMoves || minNumberOfMoves < 0){
                    minNumberOfMoves = total;
                }
            }
        }
        return minNumberOfMoves;
    }
    
    
    
    // public int MinOperations(int[] nums, int left, int right, int x) {
    //     Console.WriteLine("running subsequance");
    //     if(x == 0){
    //         return 0;
    //     }
    //     if(x < 0 || left > right){
    //         return -1;
    //     }
    //     if(this.memo[left][right] != 0){
    //         return this.memo[left][right];
    //     }
    //     int leftRemove = this.MinOperations(nums, left +1, right, x-nums[left]) +1;
    //     int rightRemove = this.MinOperations(nums, left, right-1, x-nums[right])+1;
    //     int ret = -1;
    //     if(leftRemove > 0 && rightRemove > 0){
    //          ret = Math.Min(leftRemove, rightRemove);
    //     }
    //     else if(leftRemove <= 0 && rightRemove <= 0){
    //         ret = -1;
    //     }
    //     else{
    //         ret = Math.Max(leftRemove, rightRemove);
    //     }
    //     this.memo[left][right] = ret;
    //     return ret;
    // }
}
