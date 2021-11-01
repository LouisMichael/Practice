// Accepted after 1 incorrect solution where my issue was not acually moving over the sides instead moving through the middle
// Speed 90
// Memory 8
public class Solution {
    // Check each side for O and then flood fill those to be 1
    // Run through again and change O to X and 1 to O
    public char[][] board;
    public void Solve(char[][] board) {
        this.board = board;
        // Left
        for(int i  = 0; i < board.Length; i++){
            this.floodFill(i , 0);
        }
        // Right
        for(int i  = 0; i < board.Length; i++){
            this.floodFill(i, board[0].Length -1);
        }
        // Top
        for(int i  = 0; i < board[0].Length; i++){
            this.floodFill(0, i);
        }
        // Bottom
        for(int i  = 0; i < board[0].Length; i++){
            this.floodFill(board.Length -1 , i);
        }
        for(int i = 0; i < board.Length; i++){
            for(int j = 0; j< board[i].Length; j++){
                if(board[i][j] == 'O'){
                    board[i][j] = 'X';
                }
                if(board[i][j] == '1'){
                    board[i][j] = 'O';
                }
            }
        }
    }

    public void floodFill(int i, int j){
        // Console.WriteLine("trying at i: " + i + " j: " + j);
        if(i < 0 || j < 0 || i > this.board.Length - 1 || j > this.board[i].Length - 1)
            return;
        if(this.board[i][j] == 'O'){
            this.board[i][j] = '1';
            // Console.WriteLine("preserving at i: " + i + " j: " + j);
            this.floodFill(i + 1, j);
            this.floodFill(i - 1, j);
            this.floodFill(i, j + 1);
            this.floodFill(i, j - 1);
        }
    }
}