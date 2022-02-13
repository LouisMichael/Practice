// Runtime: 151 ms, faster than 51.78% of TypeScript online submissions for Max Area of Island.
// Memory Usage: 46.2 MB, less than 34.01% of TypeScript online submissions for Max Area of Island.
let counted: boolean[][];
function maxAreaOfIsland(grid: number[][]): number {
    counted = [];
    for(let i = 0; i < grid.length;i++){
        counted[i] = [];
        for(let j = 0; j<grid[i].length;j++){
            counted[i][j] = false;
        }
    }
    // console.log(counted);
    let ret = 0;
    for(let x = 0; x< grid.length;x++){
        for(let y = 0; y< grid[x].length;y++){
            let countSpaceResult = countSpace(x,y,grid);
            if(countSpaceResult > ret){
                ret = countSpaceResult;
            }
        }
    }
    return ret;
};

function countSpace(x: number, y:number, grid:number[][]){
    if(x>grid.length -1 || x<0){
        return 0;
    }
    if(y>grid[x].length-1||y<0){
        return 0;
    }
    if(grid[x][y] == 0 || counted[x][y]){
        return 0;
    }
    else{
        counted[x][y] = true;
        return 1 
            + countSpace(x+1,y,grid)
            + countSpace(x-1,y,grid)
            + countSpace(x,y+1,grid)
            + countSpace(x,y-1,grid);
    }
}
