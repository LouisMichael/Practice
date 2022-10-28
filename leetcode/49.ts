function groupAnagrams(strs: string[]): string[][] {
    let map = new Map<string,string[]>();
    for(let i = 0; i<strs.length;i++){
        let countArray = letterCountArray(strs[i]);
        if(!map.has(countArray)){
            map.set(countArray, new Array<string>(0));
        }
        map.get(countArray).push(strs[i]);
    }
    // console.log(map);
    // console.log([...map.values()]);
    return Array.from(map.values());
    // let ret = new Array<string[]>(0);
    // let itero = map.keys();
    // console.log(itero);
    // for(const s of itero){
    //     console.log(s);
    //     ret.push(map[s]);
    // }
    // return ret;
};

function letterCountArray(str): string {
    let ret = new Array<number>(26);
    for(let i = 0; i<26; i++){
        ret[i] = 0;
    }
    for(let i = 0; i<str.length;i++){
        ret[str.charCodeAt(i) - "a".charCodeAt(0)]++;
    }
    // console.log("" + ret);
    return "" + ret;
}
