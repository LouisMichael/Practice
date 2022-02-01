// Runtime: 128 ms, faster than 56.71% of TypeScript online submissions for Best Time to Buy and Sell Stock.
// Memory Usage: 52 MB, less than 10.18% of TypeScript online submissions for Best Time to Buy and Sell Stock.
function maxProfit(prices: number[]): number {
    let min = prices[0];
    let maxProf = 0;
    for(let i = 0; i < prices.length; i++){
        let diff = prices[i] - min;
        if(diff > maxProf){
            maxProf = diff;
        }
        if(prices[i] < min){
            min = prices[i]
        }
    }
    return maxProf;
};
