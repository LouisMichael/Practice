function orangesRotting(grid: number[][]): number {
//     I think we can moddle this pretty well with two queues one for the current round and one for the next round
    let curRound = new Array<number[]>();
    let nextRound = new Array<number[]>();
    let freshCount = 0;
    let rounds = 0;
    for(let i = 0; i<grid.length;i++){
        for(let j = 0; j<grid[i].length;j++){
            if(grid[i][j] == 2){
                nextRound.push([i,j]);
            }
            else if(grid[i][j] == 1){
                freshCount++;
            }
        }
    }
    while (freshCount > 0 && nextRound.length > 0){
        rounds++;
        curRound = nextRound;
        nextRound = new Array<number[]>();
        while(curRound.length > 0){
            let nextRoundPair = curRound.pop();
            let newRotX = nextRoundPair[0];
            let newRotY = nextRoundPair[1];
            if(newRotX + 1 < grid.length && grid[newRotX + 1][newRotY] == 1){
                grid[newRotX+1][newRotY] = 2;
                nextRound.push([newRotX +1,newRotY]);
                freshCount--;
            }
            if(newRotX - 1 >= 0 && grid[newRotX - 1][newRotY] == 1){
                grid[newRotX-1][newRotY] = 2;
                nextRound.push([newRotX-1,newRotY]);
                freshCount--;
            }
            if(newRotY + 1 < grid[newRotX].length && grid[newRotX][newRotY + 1] == 1){
                grid[newRotX][newRotY + 1] = 2;
                nextRound.push([newRotX,newRotY + 1]);
                freshCount--;
            }
            if(newRotY - 1 >= 0 && grid[newRotX][newRotY - 1] == 1){
                grid[newRotX][newRotY-1] = 2;
                nextRound.push([newRotX,newRotY-1]);
                freshCount--;
            }
        }
    }
    if(freshCount == 0){
        return rounds;
    }
    return -1;
};
