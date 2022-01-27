// Runtime: 463 ms, faster than 35.90% of C# online submissions for Maximum XOR of Two Numbers in an Array.
// Memory Usage: 58.1 MB, less than 51.28% of C# online submissions for Maximum XOR of Two Numbers in an Array.
// I had to look up that a tri was the correct way to go about this problem
// That intuition was really neat and fits well with how I was origanly thinking about the problem but I failed
// to match that on paper thinking to a real datastructure without a hint
public class Solution {
    public int FindMaximumXOR(int[] nums) {
        BinaryTri tri = new BinaryTri();
        for(int i = 0; i < nums.Length; i++){
            tri.add(nums[i]);
        }
        int max = 0;
        for(int i = 0; i < nums.Length; i++){
            int maxAtI = tri.findMaxXor(nums[i]);
            if(maxAtI > max){
                // Console.WriteLine("max of " + maxAtI + " found for " + nums[i]);
                max = maxAtI;
            }
        }
        return max;
    }
}

public class BinaryTri {
    public BinaryTriNode root = new BinaryTriNode();
    public void add(int num){
        int temp = num;
        BinaryTriNode cur = root;
        int mask = 1 << 31;
        
        for(int i = 0; i < 32; i++){
            if((num & mask) != 0){
                if(cur.oneChild == null){
                    cur.oneChild = new BinaryTriNode();
                }
                cur = cur.oneChild;
            }
            else{
                if(cur.zeroChild == null){
                    cur.zeroChild = new BinaryTriNode();
                }
                cur = cur.zeroChild;
            }
            num = num << 1;
        }
        cur.finalValue = temp;
    }
    public int findMaxXor(int num){
        int temp = num;
        int mask = 1 << 31;
        BinaryTriNode cur = root;

        for(int i = 0; i < 32; i++){
            if((num & mask) != 0){
                if(cur.zeroChild != null){
                    cur = cur.zeroChild;
                }
                else{
                    cur = cur.oneChild;
                }
            }
            else{
                if(cur.oneChild != null){
                    cur = cur.oneChild;
                }
                else{
                    cur = cur.zeroChild;
                }
            }
            num = num << 1;
        }
        // Console.WriteLine("max for " + temp + " found with " + cur.finalValue);

        return cur.finalValue ^ temp;
    }
}

public class BinaryTriNode {
    public BinaryTriNode oneChild = null;
    public BinaryTriNode zeroChild = null;
    public int finalValue = 0;
}
