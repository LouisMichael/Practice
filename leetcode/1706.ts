function findBall(grid: number[][]): number[] {
//     Ever cell will lead down the same path every time, so I think we just solve every cell bottom up
    let solvedGrid: number[][] = [];
    for(let i = 0; i<grid.length;i++){
        solvedGrid.push([]);
    }
    for(let i = grid.length-1; i >=0 ;i--){
        for(let j = 0; j<grid[i].length;j++){
            if(grid[i][j] == 1){
                if(j+1 < grid[i].length){
                    if(grid[i][j+1] === -1){
//                         left hand part of a v
                        solvedGrid[i].push(-1);
                    }
                    else if(i < grid.length-1){
//                         roll right
                        solvedGrid[i].push(solvedGrid[i+1][j+1]);
                    }
                    else{
                        solvedGrid[i].push(j+1);
                    }
                }
                else{
//                     right wall
                    solvedGrid[i].push(-1);
                }
            }
            else{
                if(j-1 >= 0){
                    if(grid[i][j-1] === 1){
//                         right hand part of a v
                        solvedGrid[i].push(-1);
                    }
                    else if(i < grid.length-1){
//                         roll right
                        solvedGrid[i].push(solvedGrid[i+1][j-1]);
                    }
                    else{
                        solvedGrid[i].push(j-1);
                    }
                }
                else{
//                     left wall
                    solvedGrid[i].push(-1);
                }
            }
        }
    }
    return solvedGrid[0];
};
