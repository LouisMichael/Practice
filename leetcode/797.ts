function allPathsSourceTarget(graph: number[][]): number[][] {
    // since I need all and not just the best or the fastest I think dfs or bfs will both work
    // I think I can work with the input as is without it needing to get mutated
    let ret = [];
    let dfsStack = [[0]];
    while(dfsStack.length > 0){
        let curStack = dfsStack.pop();
        let curNode = curStack[curStack.length-1];
        if(curNode == graph.length-1){
            ret.push(curStack);
            continue;
        }
        for(let i = 0; i<graph[curNode].length;i++){
            let next = [];
            // the spred opearator whould have been a good sub here
            for(let j = 0; j<curStack.length; j++){
                next.push(curStack[j]);
            }
            next.push(graph[curNode][i]);
            dfsStack.push(next);
        }
    }
    return ret;
};
