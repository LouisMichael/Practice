public class Solution {
    public int Tribonacci(int n) {
        int[] mem = new int[n+3];
        mem[0] = 0;
        mem[1] = 1;
        mem[2] = 1;
        int cur = 2;
        while(cur < n){
            cur++;
            mem[cur] = mem[cur-1] + mem[cur-2] + mem[cur-3];
        }
        return mem[n];
    }
}
