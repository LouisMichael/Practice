function uniqueOccurrences(arr: number[]): boolean {
// there is a simple run through the list twice solution, I also think that might just be the best
// I could have used for of loops in both sections here
let mapVal2Counts = new Map<number,number>();
    for(let i = 0; i<arr.length;i++){
        let curVal = mapVal2Counts.get(arr[i]);
        if(curVal){
            mapVal2Counts.set(arr[i],curVal+1);
        }else{
            mapVal2Counts.set(arr[i],1);
        }
    }
    let usedSet = new Set<number>();
    let valueArray = Array.from(mapVal2Counts.values());
    for(let i = 0; i<valueArray.length;i++){
        if(usedSet.has(valueArray[i])){
            return false;
        }
        usedSet.add(valueArray[i]);
    }
    return true;
};
