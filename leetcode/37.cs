public class Solution {
//     I think this is a classic backtracking problem
    public void SolveSudoku(char[][] board) {
        this.SolveSudokuRecur(board,0,0);
    }
    public bool SolveSudokuRecur(char[][] board, int x, int y) {
        if(x < board.Length && y >= board[x].Length){
            return true;
        }
        if(x >= board.Length){
            return this.SolveSudokuRecur(board, 0, y+1);
        }
        if(board[x][y] != '.'){
            return this.SolveSudokuRecur(board, x+1, y);
        }
        else{
            bool solveFound = false;
            for(int i = 0; i<9;i++){
//                 check the row
                bool foundInRow = false;
                for(int j =0; j<board.Length;j++){
                     foundInRow = foundInRow | (board[j][y]-'1' == i);
                }
//                 check the col
                bool foundInCol = false;
                for(int j =0; j<board[x].Length;j++){
                     foundInCol = foundInCol | (board[x][j]-'1' == i);
                }
//                 check the box
                bool foundInBox = false;
                for(int j =0; j<3;j++){
                    for(int k =0; k<3;k++){
                        foundInBox = foundInBox | (board[((x/3)*3) + j][((y/3)*3) + k]-'1' == i);
                    }
                }
                if(!foundInBox && !foundInCol && !foundInRow){
                    //                 try this val
                    board[x][y] = (char)('1'+i);
                    if(!this.SolveSudokuRecur(board, x+1,y)){
                        board[x][y] = '.';
                    }
                    else{
                        solveFound = true;
                        break;
                    }
                }
            }
            return solveFound; 
        }
    }
}
