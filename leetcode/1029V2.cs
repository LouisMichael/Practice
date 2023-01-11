public class Solution {
    public int TwoCitySchedCost(int[][] costs) {
//         sort them in the order of how much it matters, then assign them that way
        Array.Sort(costs, (a,b)=> Math.Abs(b[0]-b[1])-Math.Abs(a[0]-a[1]));
        int ret = 0;
        int usedA = 0;
        int usedB = 0;
        while(usedA < costs.Length/2 && usedB < costs.Length/2){
            if(costs[usedA + usedB][0] < costs[usedA + usedB][1]){
                ret += costs[usedA + usedB][0];
                usedA++;
            }
            else{
                ret += costs[usedA + usedB][1];
                usedB++;
            }
        }
        while(usedA < costs.Length/2 || usedB < costs.Length/2){
            if(usedA < usedB){
                ret += costs[usedA + usedB][0];
                usedA++;
            }
            else{
                ret += costs[usedA + usedB][1];
                usedB++;
            }
        }
        return ret;
    }
}
