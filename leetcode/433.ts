function minMutation(start: string, end: string, bank: string[]): number {
// some diffrent inital thoughts
//     without the bank this is a spell correct problem which is a dp solve
//     with the bank I think maybe this is a graph problem, we go throught the bank
//     connect all the strings that could be connected, use dykstra to find the best route
//     from start to end
//     but also the more I think about it the more I wonder if we actually need to build the graph because the DP
//     sovle will also only take one more at a time expanding out, maybe instead of building a graph we just set up a 
//     set to check for existance and then do dykstra where we only add a node if it is a valid transiton
    let bankSet = new Set<string>();
    let visited = new Set<string>();
//     We want to check to see if our change will be valid quickly so we add everything to a set to get our O(1) lookup
    for(let i = 0; i<bank.length;i++){
        bankSet.add(bank[i]);
    }
//     We are going to want to count the number of rounds we take to get to our goal, we can do this by flip floping queues
    let dystraQueueCur:string[] = [];
    let dystraQueueCurNext:string[] = [];
    
    dystraQueueCurNext.push(start);
    let roundCount = -1;
    
    while(dystraQueueCurNext.length > 0){
        roundCount++;
        dystraQueueCur = dystraQueueCurNext;
        dystraQueueCurNext = [];
        while(dystraQueueCur.length > 0){
            let curStartString = dystraQueueCur.pop();
            if(curStartString == end){
                return roundCount;
            }
            visited.add(curStartString);
            for(let i = 0; i<curStartString.length;i++){
                let orignalLetter = curStartString[i];
                for(let change of ['A', 'C', 'G', 'T']){
                    let newStringArray = curStartString.split("");
                    newStringArray[i] = change;
                    let newString = newStringArray.join("");
                    if(!visited.has(newString) && bankSet.has(newString)){
                        dystraQueueCurNext.push(newString);
                    }
                }
            }
        }
    }
    return -1;
};
