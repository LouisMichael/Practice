// shortest path is dixstras, but since we don't have diffrent weights we could also do a bfs and it would be the same

function nearestExit(maze: string[][], entrance: number[]): number {
    let bfsQueue:number[][] = [];
    let bfsQueueNext:number[][] = [entrance];
    let ret = -1;
    let visited: boolean[][] = new Array(maze.length).fill(false).map(() => new Array(maze[0].length).fill(false));
    console.log(visited);
    console.log(maze);
    let offsets = [[1,0],[-1,0],[0,1],[0,-1]];
    while(bfsQueueNext.length > 0){
        ret++;
        bfsQueue = bfsQueueNext;
        bfsQueueNext = [];
        let startLength = bfsQueue.length;
        for(let i =0;i<startLength;i++){
            let x = bfsQueue[i][0];
            let y = bfsQueue[i][1];
            console.log("x: "+ x + " y: " + y);
            if(x === 0 || x === maze.length-1 || y === 0 || y === maze[x].length-1){
                if(x != entrance[0] || y != entrance[1]){
                    return ret;
                }
            }
            if(visited[x][y]){
                continue;
            }
            else{
                visited[x][y] = true;
            }
            for(let j = 0; j<offsets.length;j++){
                let newX = x + offsets[j][0];
                let newY = y + offsets[j][1];
                // console.log("newX: "+ newX + " newY: " + newY);
                if(newX >= 0 && newX < maze.length && newY >=0 && newY < maze[newX].length && maze[newX][newY] === '.' && !visited[newX][newY]){
                    // console.log("newX: "+ newX + " newY: " + newY);
                    bfsQueueNext.push([newX,newY]);
                }
            }
        }
    }
    return -1;
};
