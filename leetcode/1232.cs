public class Solution {
    // cross multiply vs actual division leads to faster computatoion
    public bool CheckStraightLine(int[][] coordinates) {
        int xChange = coordinates[1][0] - coordinates[0][0];
        int yChange = coordinates[1][1] - coordinates[0][1];
        if(xChange == 0){
            for(int i = 2; i<coordinates.Length;i++){
                if(coordinates[i][0] != coordinates[0][0]){
                    return false;
                }
            }
            return true;
        }
        
        double slope = (double)yChange / (double)xChange;
        for(int i = 2; i<coordinates.Length;i++){
            if((double)(coordinates[i][1] - coordinates[0][1])/(double)(coordinates[i][0]- coordinates[0][0]) != slope){
                return false;
            }
            
        }
        return true;
    }
}
