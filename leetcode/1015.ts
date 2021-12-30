// My submission information seems bugged but I didn't really get at the solution that was intended here
// I missed several properties of the problem that make solving it much more straight forward

function smallestRepunitDivByK(k: number): number {
    let carry = 0;
    let solve = 0;
    return smallestRepunitDivByKRecur(k, -1);
};

function smallestRepunitDivByKRecur(k: number, carry: number){
    let minSolve =  Number.MAX_SAFE_INTEGER;
    // console.log("carry in is:" + carry);
    if(carry === 0){
        return 0;
    }
    if(carry < 0){
        carry = 0;
    }
    for(let i = 0; i < 10; i++){
        if( ( carry + (k * i) ) % 10 === 1){
            // console.log("trying:" + i);
            minSolve = Math.min(minSolve, 1 + smallestRepunitDivByKRecur(k, Math.floor((carry +  (k * i) )/10)));
        }
    }
    if(minSolve === Number.MAX_SAFE_INTEGER){
        return -1;
    }
    return minSolve;
}
