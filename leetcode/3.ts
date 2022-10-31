// I think sliding window works well here

function lengthOfLongestSubstring(s: string): number {
    let left = 0;
    let right = 0;
    if(s.length == 0){
        return 0;
    }
    let cur = new Array<boolean>(26);
    cur[s.charCodeAt(right) - "a".charCodeAt(0)] = true;
    let max = 1;
    while(right < s.length-1){
        right ++;
        while(cur[(s.charCodeAt(right) - "a".charCodeAt(0))]){
            cur[(s.charCodeAt(left) - "a".charCodeAt(0))] = false;
            left++;
        }
        cur[(s.charCodeAt(right) - "a".charCodeAt(0))] = true;
        if(right - left + 1 > max){
            max = right - left + 1;
        }
    }
    return max;
};
