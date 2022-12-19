function validPath(n: number, edges: number[][], source: number, destination: number): boolean {
// since we are only intersted in if a path exists we can do a very simple depth first search
    let visited = new Array<boolean>(n);
    let edgesMap = new Map<number,number[]>();
    for(let edge of edges){
        if(!edgesMap.has(edge[0])){
            edgesMap.set(edge[0],[]);
        }
        edgesMap.get(edge[0]).push(edge[1]);
        // console.log(edgesMap.get(edge[0]));
        if(!edgesMap.has(edge[1])){
            edgesMap.set(edge[1],[]);
        }
        edgesMap.get(edge[1]).push(edge[0]);
        // console.log(edgesMap.get(edge[1]));
    }
    let stack = [];
    stack.push(source);
    while(stack.length > 0){
        let cur = stack.pop();
        if(visited[cur]){
            continue;
        }
        visited[cur] = true;
        if(cur == destination){
            return true;
        }
        for(let edge of edgesMap.get(cur)){
            stack.push(edge);
        }
    }
    return false;
};
