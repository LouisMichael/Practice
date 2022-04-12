public class Solution {
    public void GameOfLife(int[][] board) {
        int[][] ret = new int[board.Length][];
        for(int i =0; i< board.Length; i++){
            ret[i] = new int[board[i].Length];
            for(int j = 0; j<board[i].Length;j++){
                ret[i][j] = this.CheckCell(board, i, j);
            }
        }
        for(int i =0; i< board.Length; i++){
            for(int j = 0; j<board[i].Length;j++){
                board[i][j] = ret[i][j];
            }
        }
    }
    
    public int CheckCell(int[][] board, int x, int y){
        int liveNeighbors = 0;
        int deadNeighbors = 0;
        for(int i = -1; i<=1;i++){
            if(i+x < 0 || i+x >= board.Length){
                continue;
            }
            for(int j = -1; j<=1;j++){
                if(j+y < 0 || j+y >= board[i+x].Length || (j==0 && i==0)){
                    continue;
                }
                if(board[x+i][y+j] == 1){
                    liveNeighbors++;
                }
                else{
                    deadNeighbors++;
                }
            }
        }
        if(board[x][y] == 1){
            if(liveNeighbors > 3){
                return 0;
            }
            if(liveNeighbors > 1){
                return 1;
            }
            return 0;
        }
        else{
            if(liveNeighbors == 3){
                return 1;
            }
            return 0;
        }
    }
}
