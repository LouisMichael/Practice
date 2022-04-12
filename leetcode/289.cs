// Runtime: 156 ms, faster than 76.67% of C# online submissions for Game of Life.
// Memory Usage: 42.3 MB, less than 10.00% of C# online submissions for Game of Life.
public class Solution {
    public void GameOfLife(int[][] board) {
        
        for(int i =0; i< board.Length; i++){
            for(int j = 0; j<board[i].Length;j++){
                board[i][j] = this.CheckCell(board, i, j);
            }
        }
        for(int i =0; i< board.Length; i++){
            for(int j = 0; j<board[i].Length;j++){
                // Console.WriteLine(board[i][j]);
                board[i][j] = board[i][j] >> 1;
                // Console.WriteLine(board[i][j]);
            }
        }
    }
    
    public int CheckCell(int[][] board, int x, int y){
        int liveNeighbors = 0;
        for(int i = Math.Max(0,x-1); i<=Math.Min(board.Length-1,x+1);i++){
            for(int j = Math.Max(0,y-1); j<=Math.Min(board[i].Length-1,y+1);j++){
                if(j==y && i==x){
                    continue;
                }
                if(board[i][j] %2 == 1){
                    // Console.WriteLine("liveNeighbors:"+liveNeighbors);
                    liveNeighbors++;
                }
            }
        }
        if(board[x][y] %2 == 1){
            if(liveNeighbors > 3){
                return board[x][y];
            }
            if(liveNeighbors > 1){
                return board[x][y] + 2;
            }
            return board[x][y];
        }
        else{
            if(liveNeighbors == 3){
                return board[x][y] + 2;
            }
            return board[x][y];
        }
    }
}
