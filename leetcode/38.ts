let results = new Map<number,string>();
results[1] = "1";
function countAndSay(n: number): string {
    if(results[n] != null){
        return results[n];
    }
    let prev = countAndSay(n-1);
    let curVal = parseInt(prev[0]);
    let curCount = 1;
    let ret = "";
    for(let i = 1; i<prev.length;i++){
        if(parseInt(prev[i]) == curVal){
            curCount++;
        }
        else{
            ret += curCount;
            ret += curVal;
            curCount = 1;
            curVal = parseInt(prev[i]);
        }
    }
    ret += curCount;
    ret += curVal;
    // console.log(results);
    results[n] = ret;
    return ret;
};
