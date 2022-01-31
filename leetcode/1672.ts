// Runtime: 48 ms, faster than 100.00% of TypeScript online submissions for Richest Customer Wealth.
// Memory Usage: 44.6 MB, less than 5.26% of TypeScript online submissions for Richest Customer Wealth.
// The wording of this was really hard to get I had to read a few examples before I got what it was asking
function maximumWealth(accounts: number[][]): number {
    let max = 0;
    for(let i = 0; i< accounts.length;i++){
        let temp = 0;
        for(let j = 0; j< accounts[i].length; j++){
            temp += accounts[i][j];
        }
        if(temp > max){
            max = temp;
        }
    }
    return max;
};
