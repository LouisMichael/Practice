// start time 11:40
// Runtime: 120 ms, faster than 22.22% of TypeScript online submissions for K-diff Pairs in an Array.
// Memory Usage: 48.1 MB, less than 22.22% of TypeScript online submissions for K-diff Pairs in an Array.
// I missed a fun way of doing it where you only go through the list once
// at each position you first try to see if you already have your goal the way I did it
// but you also try the inverse of the equation so you check if you missed on the first time
function findPairs(nums: number[], k: number): number {
//     load everything into a map since we need to account for the matching case
        let myNumMap = {};
        for(let num of nums){
            if(myNumMap[num]){
                myNumMap[num] ++;
            }
            else{
                myNumMap[num] = 1;
            }
        }
//     loop over the map and at each look for x - y = k
//     -k + cur = search
//     this will double count uniqu sets since we will solve the equation 
        let count = 0;
        for(let prop in myNumMap){
            let num = parseInt(prop);
            let goalFind = num - k;
            if(goalFind == num){
                if(myNumMap[num] >= 2)
                count++;
            }
            else if(myNumMap[goalFind]){
                count++;
            }
            // console.log(goalFind);
        }
    return count;
    
};
// end time 11:57
