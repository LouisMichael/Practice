function isValidSudoku(board: string[][]): boolean {
    let colmnNoRepeat: boolean[][] = []; // labeled left to right
    let rowNoRepeat: boolean[][] = []; // labeled top to bottom
    let boxNoRepeat: boolean[][] = []; // labled left to right top to bottom
    for(let i = 0; i<board.length;i++){
        rowNoRepeat.push([]);
        for(let j = 0; j<board[i].length;j++){
            if(!colmnNoRepeat[j]){
                colmnNoRepeat[j] = [];
            }
            if(!boxNoRepeat[j]){
                boxNoRepeat[j] = [];
            }
            if(board[i][j]!="."){
                let val = parseInt(board[i][j]);
                let boxRow = Math.floor(i/3)*3;
                let boxCol = Math.floor(j/3);
                if(rowNoRepeat[i][val-1] || colmnNoRepeat[j][val-1] || boxNoRepeat[boxRow+boxCol][val-1]){
                    return false;
                }
                else{
                    rowNoRepeat[i][val-1] = true;
                    colmnNoRepeat[j][val-1] = true;
                    boxNoRepeat[boxRow+boxCol][val-1] = true;
                }
            }
        }
    }
    return true;
};
