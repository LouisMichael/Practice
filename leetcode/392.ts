function isSubsequence(s: string, t: string): boolean {
    let sPointer = 0;
    let tPointer = 0;
    while(tPointer < t.length && sPointer < s.length){
        if(s.charAt(sPointer) === t.charAt(tPointer)){
            sPointer++;
            tPointer++;
        }
        else{
            tPointer++;
        }
    }
    return sPointer === s.length;
};
