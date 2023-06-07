public class Solution {
    public int MinFlips(int a, int b, int c) {
        // I think we just go place by place and count hwo many if any we need to change
        // when c  = 0 both a and b must be 0
        // when c = 1 one or the other does
        int mask = 1;
        int ret = 0;
        for(int i = 0; i<32;i++){
            if((c & mask) == 0){
                if((a & mask) != 0){
                    ret++;
                }
                if((b & mask) != 0){
                    ret ++;
                }
            }
            else{
                if((a & mask) == 0 && (b & mask) == 0){
                    ret++;
                }
            }
            mask = mask << 1;
        }
        return ret;
    }
    // there is an intersting alternative that combines using xor and bit count to do this in O(1) since bitcount uses a precomputed table in many languages. 
}
