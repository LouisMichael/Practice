function longestCommonPrefix(strs: string[]): string {
    let max = "";
    let curIndex = -1;
    let curValue = "";
    while(strs.length>0 && strs[0].length>curIndex){
        curIndex++;
        if(strs[0].length > curIndex){
            curValue = strs[0][curIndex];
        }
        else{
            return max;
        }
        for(let i = 1; i < strs.length;i++){
            if(strs[i].length < curIndex || strs[i][curIndex] != curValue){
                return max;
            }
        }
        max = max + curValue;
    }
    return max;
};

//  I could build a tri or I can keep a set of all prefixs and then just see the longest one that is alreayd a match, this is less memory efficent then the tri but also may be fatster
// I solved the wrong problem...
// let set = new Set<string>(); 
//     let max = "";
//     for(let s of strs){
//         let prefix = "";
//         for(let char of s){
//             prefix = prefix + char;
//             if(set.has(prefix) && prefix.length > max.length){
//                 max = prefix;
//             }
//             if(!set.has(prefix)){
//                 set.add(prefix);
//             }
//         }
//     }
//     return max;
