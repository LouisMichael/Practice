function canVisitAllRooms(rooms: number[][]): boolean {
    // I think this is a pretty staight forward bfs, with a set to check we hit everything
    // switched to dfs because js supports stack behavior better
    let visitedSet = new Set();
    let roomStack = [0];
    while(roomStack.length > 0){
        let curRoom = roomStack.pop();
        if(visitedSet.has(curRoom)){
            continue;
        }
        visitedSet.add(curRoom);
        for(let roomNumber of rooms[curRoom]){
            roomStack.push(roomNumber);
        }
    }
    return visitedSet.size == rooms.length;
};