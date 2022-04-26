// Runtime: 2888 ms, faster than 5.17% of C# online submissions for Min Cost to Connect All Points.
// Memory Usage: 51.5 MB, less than 92.53% of C# online submissions for Min Cost to Connect All Points.
// The approch I broadly took would be called Kruskal's Algorithm
// I should have bothered to actaully implement a union find data structure for speed. 

// The final aproch discussed in the soluiton is to grow out the tree by just looking at nodes not in the tree and trying to find the one that is eisest to add which seems like a simper version of this.
public class Solution {
//     first thought is greedy but I want to try to get a proof of it working before I try to implement
//     second thought we would like connect all points and then dikstras or something. IDK if this works since we are aloud to revisit
//     I am thinking something like a greedy mege would be good, every point starts as its own color and you add one edge to reduce the 
//     total number of colors, IDK how to prove this works but it works
//     the thing I do not jump to knowing how to do is finding the next smallest connection quickly
//     calculating pair wise distances seems like a lot of work but I also don't have a better idea right off the bat so I guess I write up that
    public int MinCostConnectPoints(int[][] points) {
        int groupCount = points.Length;
//         this stores how close point x is to point y at location [x][y]
        int[][] pointsPairDistances = new int[points.Length][];
//         this stores a ranked order of how close each point is to another, [x][0] is the closest point to point x where x is the order of appearnce in the orinal list, this position will also always be x, so the actal closest point to x will be at 1
        int[][] pointClosnessSorted = new int[points.Length][];
        
        int[] pointsColors = new int[points.Length];
        int ret = 0;
        for(int i = 0; i < points.Length; i++){
//             all points start in their own color
            pointsColors[i] = i;
            pointsPairDistances[i] = new int[points.Length];
            for(int j = 0; j < points.Length; j++){
                pointsPairDistances[i][j] = Math.Abs(points[i][0]-points[j][0]) + Math.Abs(points[i][1]-points[j][1]);
            }
//             for a speedup I can a custom sort here
//             I also think I can get a speedup on color merge if I do something like store linked lists of the elements currently in a color
        }
        while(groupCount > 1){
            int minJoin = -1;
            int minJoinColor1 = -1;
            int minJoinColor2 = -1;
            int[] closestJoinByPoint = new int[points.Length];
            int[] closestJoinByColor = new int[points.Length];
            for(int i = 0; i<points.Length;i++){
                int closestJoinVal = -1;
                for(int j = 0; j<points.Length;j++){
                    if(i == j){
                        continue;
                    }
                    if((closestJoinVal < 0 || (closestJoinVal > 0 && pointsPairDistances[i][j]<closestJoinVal)) && pointsColors[i] != pointsColors[j]){
                        closestJoinVal = pointsPairDistances[i][j];
                        closestJoinByPoint[i] = j;
                        if(closestJoinVal<minJoin || minJoin < 0){
                            minJoin = closestJoinVal;
                            minJoinColor1 = pointsColors[i];
                            minJoinColor2 = pointsColors[j];
                        }
                    }
                }
            }
            // Console.WriteLine(minJoin);
            // Console.WriteLine("merging color1, " + minJoinColor1 + " with color2, " + minJoinColor2);
            // for(int i = 0; i<points.Length;i++){
            //     Console.WriteLine("point " + i + " is color "+ pointsColors[i] + " before merge");
            // }
//             merge the closest colors with a new edge
            groupCount--;
            ret+=minJoin;
            for(int i = 0; i<points.Length;i++){
                if(pointsColors[i] == minJoinColor2){
                    pointsColors[i] = minJoinColor1;
                }
            }
        }
        return ret;
    }
}
