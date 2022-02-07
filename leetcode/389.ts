// Runtime: 68 ms, faster than 100.00% of TypeScript online submissions for Find the Difference.
// Memory Usage: 45.7 MB, less than 5.26% of TypeScript online submissions for Find the Difference.
// less then 15 min, first intuiton was correct
function findTheDifference(s: string, t: string): string {
    let charMapS = {};
    for(let char of s){
        if(charMapS[char]){
            charMapS[char]++;
        }
        else{
            charMapS[char] = 1;
        }
    }
    let charMapT = {};
    for(let char of t){
         if(charMapT[char]){
            charMapT[char]++;
            if(charMapS[char] < charMapT[char]){
                return char;
            }
        }
        else{
            if(!charMapS[char]){
                return char;
            }
            charMapT[char] = 1;
        }
    }
    return '-';
};
