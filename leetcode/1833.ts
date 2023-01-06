function maxIceCream(costs: number[], coins: number): number {
// we just sort the array and choose the first x we can afford
    costs.sort((a,b)=>a-b);
    // console.log(costs);
    let ret = 0;
    for(let i = 0; i<costs.length;i++){
        if(costs[i]<=coins){
            ret++;
            coins -= costs[i];
        }
        else{
            break;
        }
    }
    return ret;
};
