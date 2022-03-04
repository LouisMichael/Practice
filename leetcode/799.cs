
// public class Solution {
//     public double[,] dp;
//     public double ChampagneTower(int poured, int query_row, int query_glass) {
//         this.dp = new double[query_row+1,query_glass+1];
//         for(int i = 0; i < query_row+1; i++){
//             for(int j = 0; j < query_glass+1; j++){
//                 // Console.WriteLine(i);
//                 // Console.WriteLine(j);

//                 this.dp[i,j] = -1;
//             }
//         }
//         return this.ChampagneTowerPourOver(poured,query_row-1,query_glass)+this.ChampagneTowerPourOver(poured,query_row-1,query_glass-1);
//     }
//     public double ChampagneTowerPourOver(int poured, int query_row, int query_glass) {
        
//         if(query_glass>query_row || query_glass<0){
//             return 0;
//         }
//         if(query_row == 0){
//             return (poured -1.0)/2;
//         }
//         if(this.dp[query_row,query_glass] != -1){
//             return this.dp[query_row,query_glass];
//         }
//         double pouredIn = 0;
// //         this probably will need to be dp since I we will ask the same questions to lots of spots
//         pouredIn += this.ChampagneTowerPourOver(poured,query_row-1,query_glass);

//         pouredIn += this.ChampagneTowerPourOver(poured,query_row-1,query_glass-1);
        
         
//         this.dp[query_row,query_glass] = (pouredIn-1) > 1? (double)(pouredIn-1)/2.0 : 0;
//         return this.dp[query_row,query_glass];

//     }
// }

// My inital approch got far to complicated and didn't really save any space. 

public class Solution {
    public double ChampagneTower(int poured, int query_row, int query_glass) {
        double[,] dp = new double[query_row+1,query_row+1];
        dp[0,0] = poured;
        for(int i = 0; i< query_row; i++){
            for(int j = 0; j<= i;j++){
                double flow = (dp[i,j]-1)/2.0;
                if(flow > 0){
                    dp[i+1,j] += flow;
                    dp[i+1,j+1] += flow;
                }
            }
        }
    return Math.Min(dp[query_row, query_glass], 1.0);
    }
}
