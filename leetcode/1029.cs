public class Solution {
//     I think the trick may be in the differance between the two cities for each person
//     if we sort by the diff and then pick then send to whichever until it is not possible
//     to anymore
    public int TwoCitySchedCost(int[][] costs) {
        Array.Sort<int[]>(costs,(x,y)=> Math.Abs(y[0] - y[1]) -  Math.Abs(x[0] - x[1]));
        int aCount = 0;
        int bCount = 0;
        int ret = 0;
        for(int i = 0; i<costs.Length;i++){
            if((costs[i][0] > costs[i][1] && bCount < costs.Length/2) || aCount >= costs.Length/2){
                bCount++;
                ret += costs[i][1];
                // Console.WriteLine(costs[i][1]);

            }
            else{
                aCount++;
                ret += costs[i][0];
                // Console.WriteLine(costs[i][0]);
            }
        }
        return ret;
    }
}
