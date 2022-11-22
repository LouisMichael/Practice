// we can see from one of the examples that greedy will not work perfect, so I think this is a dp problem,
// the classic stairs by 1 or 2 deal but first we have to do some work to get all the number of ways we can take the stairs by
function numSquares(n: number): number {
    let perfectBase = 2;
    let steps = [1];
    while(steps[steps.length-1] < n){
        steps.push(perfectBase*perfectBase);
        perfectBase++;
    }
    let memo = new Array<number>(n);
    // console.log(steps);
    return numSteps(n, memo, steps);
};

function numSteps(cur: number, memo: number[], steps:number[]): number {
    // console.log(cur);
    if(cur == 0){
        return 0;
    }
    if(cur < 0){
        return -1;
    }
    if(memo[cur-1] > 0){
        return memo[cur-1];
    }
    let min = -1;
    for(let i = 0; i<steps.length;i++){
        let stepsNeeded = numSteps(cur-steps[i], memo, steps) + 1;
        if(min < 0 || (stepsNeeded > 0 && stepsNeeded< min)){
            min = stepsNeeded;
        }
    }
    memo[cur-1] = min;
    return min;
};
