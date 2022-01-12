// Runtime: 476 ms, faster than 5.92% of TypeScript online submissions for Palindrome Number.
// Memory Usage: 48.8 MB, less than 51.76% of TypeScript online submissions for Palindrome Number.
// my algorithm was the same as some of the faster submissions so I don't understand what about my details is producing such slow runtimes. 

function isPalindrome(x: number): boolean {
    let numArray: number[] = [];
    if(x < 0){
        return false;
    }
    while(x > 0){
        numArray.push(Math.floor(x%10));
        x = Math.floor(x/10);
    }
    // console.log(numArray);
    for(let i = 0; i < Math.floor(numArray.length/2); i++){
        // console.log(numArray[i])
        // console.log(numArray[numArray.length-i-1])
        if(numArray[i] !== numArray[numArray.length-i-1]){
            return false;
        }
    }
    return true;
};
