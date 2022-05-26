public class Solution {
    // you need to treat n as an unsigned value
    public int hammingWeight(int n) {
        int temp = n;
        int mask = 1;
        int count = 0;
        for(int i = 0; i<32; i++){
            if((temp & mask) > 0){
                count++;
            }
            temp = temp >> 1;
        }
        return count;
    }
}
