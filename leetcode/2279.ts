function maximumBags(capacity: number[], rocks: number[], additionalRocks: number): number {
// I think this is pretty straightforward greedy problem with a sort
    let openSlots = new Array<number>(capacity.length);
    for(let i = 0; i<capacity.length;i++){
        openSlots[i] = capacity[i] - rocks[i];
    }
    openSlots.sort((a,b)=>a-b);
    console.log(openSlots);
    let ret = 0;
    for(let i = 0; i<openSlots.length;i++){
        if(openSlots[i] <= additionalRocks){
             ret++;
             additionalRocks -= openSlots[i];
        }
        else{
            break;
        }
    }
    return ret;
};
