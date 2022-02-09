// Start time 09:45
// One wrong answer from having equivlant counts interleaved
// Runtime: 174 ms, faster than 23.08% of TypeScript online submissions for Sort Characters By Frequency.
// Memory Usage: 62.9 MB, less than 5.13% of TypeScript online submissions for Sort Characters By Frequency.
function frequencySort(s: string): string {
//     write one loop to get counts and put in a dictionary
    let counts = {};
    let charArray = [];
    for(let i = 0; i<s.length;i++){
        if(!counts[s[i]]){
//             adding the math radndom means all letters will have diffrent total values
            counts[s[i]] = 1 + Math.random();
        }
        else{
            counts[s[i]]++;
        }
        charArray.push(s[i]);
    }
    // console.log(charArray);
//     write a sceond loop that uses the dictionary as the custom comparator for sort
    charArray.sort((a,b) =>{
        return  counts[b] - counts[a] ;
    });
    // console.log(charArray);
    let sPrime = "";
    for(let char of charArray){
        sPrime += char;
    }
    return sPrime;
};
// end time 09:57
