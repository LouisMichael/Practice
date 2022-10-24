// we can store letter usage in a 26 bit number, this lets us look for intersections quickly
//     we can also use this number as a key in a dp mem table
//     There may also be a greedy way to do this problem, where we want to find pairs with the least overlap
//     the total problem length is small though so we may just want to use backtracking
// ts has a 64 bit num, so we are good to look at used as a num
function maxLength(arr: string[]): number {
//     I think I need to guard against arr haveing invalid elments
    let arrKey = new Array<number>(arr.length);
    for(let i = 0; i<arr.length; i++){
        let key = 0;
        for(let j=0; j<arr[i].length;j++){
            if((key & 1 << (arr[i][j].charCodeAt(0) - 'a'.charCodeAt(0))) != 0){
                key = 0;
                arr[i] = "";
                break;
            }
            key = key | 1 << (arr[i][j].charCodeAt(0) - 'a'.charCodeAt(0));
            // console.log(dec2bin(key));
        }
        arrKey[i] = key;
    }
    // console.log(arrKey);
    return maxLengthRecur(arrKey, arr, 0, 0);
};

function dec2bin(dec) {
  return (dec >>> 0).toString(2);
}

function maxLengthRecur(arr: number[],arrString: string[], used: number, pos:number): number {
    // console.log("pos: " + pos + " used: " + used);
    let max = 0;
//     67,108,863 is 26 ones

    if(pos >= arr.length || used >= 67108863){
        return 0;
    }
    for(let i = pos; i<arr.length;i++){
        // console.log(dec2bin(used));
        // console.log(dec2bin(arr[pos]));
        // console.log((used & arr[pos]));
        if((used & arr[i]) === 0){
            let takePos = maxLengthRecur(arr, arrString, used | arr[i], i + 1) + arrString[i].length;
            if(max < takePos){
                max = takePos;
                if(max == 26){
                    return 26;
                }
            }
        }
    }
    // console.log("max: " + max);
    return max;
};
