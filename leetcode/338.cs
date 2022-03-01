// This lacked a mathy elegance since you can sovle the problem one bit at a time by only looking at the least signficant bit and then adding that to the count of half of your value at any spot.
public class Solution {
    public int[] CountBits(int n) {
        int[] ret = new int[n+1];
        for(int i = n; i >= 0; i--){
            int mask = 1;
            int count = 0;
            int test = i;
            for(int j = 0; j< 32; j++){
                if((mask & test) > 0){
                    count++;
                }
                test = test >> 1;
            }
            ret[i] = count;
        }
        return ret;
    }
}


// I think this idea is okay but I don't know that I actually get to be called in a way that the precomupte is working correctly, I TLE on this version
// public class Solution {
//     public int[] fullSolve;
//     public Solution(){
//         this.fullSolve = new int[100001];
//         int cur = 0;
//         this.fullSolve[0] = 0;
//         while(Math.Pow(2,cur) < 100001){
//             this.fullSolve[1<<cur] = 1;
//             cur++;
//         }
//         for(int i = 100000; i >= 1; i--){
//             this.fullSolve[i]=this.CountBitsRecur(i);
//         }
//     }
//     public int CountBitsRecur(int n) {
//         if(this.fullSolve[n] != 0){
//             return this.fullSolve[n];
//         }
//         else{
//             int cur = n;
//             while(this.fullSolve[cur]!=1){
//                 cur--;
//             }
//             return 1 + this.CountBitsRecur(n-cur);
//         }
//     }
    
//     public int[] CountBits(int n) {
//         int[] ret = new int[n+1];
//         for(int i = 0; i <= n; i++){
//             ret[i] = this.fullSolve[i];
//         }
//         return ret;
//     }
// }
