// Runtime: 173 ms, faster than 65.22% of TypeScript online submissions for Permutation in String.
// Memory Usage: 50.5 MB, less than 13.48% of TypeScript online submissions for Permutation in String.
// I could have gotten a little better in how long I took to compare by not checking keys that did not change to see if they matched. 
function checkInclusion(s1: string, s2: string): boolean {
// intuition is going to be find a open and close a window along the length of the string
    let s1Map = {};
    for(let i = 0; i< s1.length; i++){
        if(s1Map[s1[i]]){
            s1Map[s1[i]]++;
        }
        else{
            s1Map[s1[i]] = 1;
        }
    }
    let left = 0;
    let right =0;
    let curMap = {};

    for(;right<s1.length-1;right++){
        if(curMap[s2[right]]){
            curMap[s2[right]]++;
        }
        else{
            curMap[s2[right]] = 1;
        }
    }
    
    for(;right < s2.length;right++){
        if(curMap[s2[right]]){
            curMap[s2[right]]++;
        }
        else{
            curMap[s2[right]] = 1;
        }
        if(checkMapEqual(s1Map,curMap)){
            return true;
        }
        curMap[s2[left]]--;
        left++;
    }
    return false;
};

function checkMapEqual(map1: any, map2: any):boolean{
    if(Object.keys(map1).length != Object.keys(map1).length)
        {
            return false;
        }
    for(let key in map1){
        if(map1[key] != map2[key]){
            return false;
        }
    }
    return true;
}
