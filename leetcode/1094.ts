
// inital thought is to just sort based on the from order and then go through in order
// my followup thought was to just map out the in and out and then go through them in order
// looking at other submissions this second idea is better but the way I did it with checks
// is slow and I should have just made an empty list I then accessed

// Runtime: 133 ms, faster than 12.50% of TypeScript online submissions for Car Pooling.
// Memory Usage: 40.9 MB, less than 100.00% of TypeScript online submissions for Car Pooling.
function carPooling(trips: number[][], capacity: number): boolean {
    let evalList: number[] = [];
    for(let i = 0; i < trips.length; i++){
        if(!evalList[trips[i][1]]){
            evalList[trips[i][1]] = 0;
        }
        evalList[trips[i][1]] += trips[i][0];
        if(!evalList[trips[i][2]]){
            evalList[trips[i][2]] = 0;
        }
        evalList[trips[i][2]] -= trips[i][0];
    }
    let cur = 0;
    // console.log(evalList);
    for(let i = 0; i < evalList.length; i++){
        if(evalList[i])
            cur += evalList[i];
        if(cur > capacity){
            return false;
        }
    }
    return true;
};
