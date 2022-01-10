
// Runtime: 143 ms, faster than 15.57% of TypeScript online submissions for Add Binary.
// Memory Usage: 40.7 MB, less than 80.84% of TypeScript online submissions for Add Binary.

function addBinary(a: string, b: string): string {
    let longString : string;
    let shortString : string;
    if(b.length > a.length){
        longString = b;
        shortString = a;
    }
    else{
        longString = a;
        shortString = b;
    }
    let carry = 0;
    let output = "";
    for(let i = 0; i < longString.length; i++){
        let shortStringCurVal = 0;
        if(shortString.length > i){
            shortStringCurVal = parseInt(shortString[shortString.length - i - 1],10);
        }
        let longStringCurVal = parseInt(longString[longString.length - i - 1],10);
        let next = shortStringCurVal + longStringCurVal + carry;
        if(next > 1){
            carry = 1;
            next -= 2;
        }
        else{
            carry = 0;
        }
        output = next + output;
    }
    if(carry > 0){
        output = carry + output;
    }
    return output;
};

// // This simpler set of funciton calls does not work because a and b length are not less then 32
// function addBinary(a: string, b: string): string {
//     let aVal = parseInt(a, 2);
//     let bVal = parseInt(b,2);
//     return (aVal + bVal).toString(2);
// }
