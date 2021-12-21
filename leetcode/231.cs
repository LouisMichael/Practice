// Your runtime beats 80.43 % of csharp submissions.
// There was a no loop way to do it which was really cool but I did not get quickly 
// (n & (n-1)) == 0

public class Solution {
    public bool IsPowerOfTwo(int n) {
        int test = 1;
        for(int i = 0; i < 64; i ++){
            if(n <= 0){
                return false;
            }
            if((test & n) == n){
                return true;
            }
            test = test << 1;
            // Console.WriteLine(Convert.ToString(test, toBase: 2));
        }
        return false;
    }
}
