function exist(board: string[][], word: string): boolean {
    // since we are only looking for one word we can just brute force walking to find the start of the word
    let used = [];
    for(let i = 0; i<board.length;i++){
        used.push([]);
    }
    for(let i = 0; i<board.length;i++){
        for(let j = 0; j<board[i].length;j++){
            if(checkForWordAtLocation(i, j, 0, used, word, board)){
                return true;
            }
        }
    }
    return false;
};
function checkForWordAtLocation(x:number, y:number, offset:number, used:boolean[][], word: string, board: string[][]):boolean{
    // console.log("checking x: " + x + " y: " + y);
    if(offset >= word.length){
        return true;
    }
    if(x<0||x>=board.length||y<0||y>=board[x].length){
        // console.log("out of baonds");
        return false;
    }
    if(used[x][y] || board[x][y]!=word.charAt(offset)){
        // console.log("not a good board check");
        return false;
    }
    let found = false;
    let directions = [[1,0],[-1,0],[0,1],[0,-1]];
    used[x][y] = true;
    for(let i = 0; i < directions.length;i++){
        found = found || checkForWordAtLocation(x+directions[i][0], y+directions[i][1], offset+1,used, word, board);
    }
    used[x][y] = false;
    return found;
}
