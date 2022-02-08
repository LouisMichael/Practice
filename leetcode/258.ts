// Runtime: 84 ms, faster than 87.50% of TypeScript online submissions for Add Digits.
// Memory Usage: 45.4 MB, less than 12.50% of TypeScript online submissions for Add Digits.
function addDigits(num: number): number {
    
    while(Math.floor(num / 10) != 0){
        let cur = 0;
        while(Math.floor(num / 1) != 0){
            // console.log(cur);
            cur += num % 10;
            num = Math.floor(num / 10);
        }
        num = cur;
        // console.log(num);
    }
    return num;
};
