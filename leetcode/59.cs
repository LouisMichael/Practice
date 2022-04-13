public class Solution {
    public int[][] GenerateMatrix(int n) {
        int[][] ret = new int[n][];
        for(int i = 0; i < n ; i++){
            ret[i] = new int[n];
        }
        int count = 0;
        int topBound = 0;
        int bottomBound = n;
        int rightBound = n;
        int leftBound = 0;
        while(count < (n*n)){
//             right
            if(count < (n*n)){
                for(int x = leftBound; x<rightBound;x++){
                    count++;
                    ret[topBound][x] = count;
                    // Console.WriteLine(count);
                }
                topBound ++;
            }
            
//             down
            if(count < (n*n)){
                for(int y = topBound; y<bottomBound;y++){
                    count++;
                    ret[y][rightBound-1] = count;
                    // Console.WriteLine(count);
                }
                rightBound--;
            }
//             left
            if(count < (n*n)){
                for(int x = rightBound-1; x>=leftBound;x--){
                    count++;
                    ret[bottomBound-1][x] = count;
                    // Console.WriteLine(count);
                }
                bottomBound--;
            }
//             up
            if(count < (n*n)){
                for(int y = bottomBound-1; y>=topBound;y--){
                    count++;
                    ret[y][leftBound] = count;
                    // Console.WriteLine(count);
                }
                leftBound++;
            }
        }
        
        return ret;
    }
}
