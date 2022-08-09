public class Solution {
    public int CountVowelPermutation(int n) {
//         I think I can do this in linear time, by just counting the tailing vowls at each step
        long[] vowlCount = new long[] {1,1,1,1,1};
        long[] nextVowlCount = new long[5];
        for(int i = 1; i<n;i++){
//             a -> e
            nextVowlCount[1] = (nextVowlCount[1] + vowlCount[0]) % 1000000007;
//             e -> a
            nextVowlCount[0] =(nextVowlCount[0]+ vowlCount[1]) % 1000000007;
//             e -> i
            nextVowlCount[2] =(nextVowlCount[2]+ vowlCount[1]) % 1000000007;
//             i->a
            nextVowlCount[0] =(nextVowlCount[0]+ vowlCount[2]) % 1000000007;
//             i->e
            nextVowlCount[1] =(nextVowlCount[1]+ vowlCount[2]) % 1000000007;
//             i->o
            nextVowlCount[3] =(nextVowlCount[3]+ vowlCount[2]) % 1000000007;
//             i->u
            nextVowlCount[4] =(nextVowlCount[4]+ vowlCount[2]) % 1000000007;
//             o->i
            nextVowlCount[2] = (nextVowlCount[2]+vowlCount[3]) % 1000000007;
//             o->u
            nextVowlCount[4] =(nextVowlCount[4] + vowlCount[3]) % 1000000007;
//             u->a
            nextVowlCount[0] =(nextVowlCount[0]+ vowlCount[4]) % 1000000007;
            
            vowlCount = nextVowlCount;
            nextVowlCount = new long[5];
        }
        long ret = 0;
        for(int i = 0; i<5;i++){
            ret = (ret+ vowlCount[i]) % 1000000007;
        }
        return (int)ret;
    }
}
