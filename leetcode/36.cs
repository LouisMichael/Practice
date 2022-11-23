public class Solution {
    public bool IsValidSudoku(char[][] board) {
        bool[,,] used = new bool[9,9,3];
        for(int i = 0; i < board.Length; i++){
            for(int j=0; j < board[i].Length; j++)
            {
                if(board[i][j] == '.'){
                    continue;
                }
                
                if(used[board[i][j] - '1',i,0]){
                    return false;
                }
                else{
                    used[board[i][j] - '1',i,0] = true;
                }
                if(used[board[i][j] - '1',j,1]){
                    return false;
                }
                else{
                    used[board[i][j] - '1',j,1] = true;
                }
                // Console.WriteLine((i/3)+((j/3)*3));
                if(used[board[i][j] - '1',(i/3)+((j/3)*3),2]){
                    return false;
                }
                else{
                    used[board[i][j] - '1',(i/3)+((j/3)*3),2] = true;
                }
            }
        }
        return true;
    }
}
