function isIsomorphic(s: string, t: string): boolean {
    if(s.length !== t.length){
        return false;
    }
// I think the simple way to do this is to map them both to a new pattern and then compare these patterns
    let charMap1 = new Map<string,number>();
    let patternArray = new Array<number>(s.length);
    let totalCharSeen = 0;
    for(let i = 0; i <s.length;i++){
        if(!charMap1.has(s.charAt(i))){
            charMap1.set(s.charAt(i), totalCharSeen);
            totalCharSeen++;
        }
        patternArray[i] = charMap1.get(s.charAt(i));
    }
    let charMap2 = new Map<string,number>();
    totalCharSeen = 0;
    for(let i = 0; i<t.length;i++){
        if(!charMap2.has(t.charAt(i))){
            charMap2.set(t.charAt(i), totalCharSeen);
            totalCharSeen++;
        }
        if(patternArray[i] != charMap2.get(t.charAt(i))){
            return false;
        }
    }
    return true;
};
