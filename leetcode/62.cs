public class Solution {
//     since we only need to know the number I think maybe there is a mathy answer
//     we can only go one of two directions at any point, and you can only go one direction
//     on either of two edges
    public int UniquePaths(int m, int n) {
//         we can think of this as choosing where to place the down and the right in our total spots
//     this means it is a matter of picking (m-1) things from a set of (m+n-2) spots
//         int numerator = 1;
//         for(int i = m+n-2; i>n-1;i--){
//             numerator*=i;
//         }
//         Console.WriteLine(numerator);
//         int denom = 1;
//         for(int i = m-1; i>0;i--){
//             denom*=i;
//         }
//         Console.WriteLine(denom);

//     return numerator/denom;
        long ans = 1;
        
        for (int x = n, y = 1; y < m; ++x, ++y) {
            ans = ans * x / y;
        }

        return (int) ans;
    }
}
