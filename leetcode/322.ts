// I think this is a dp problem 
// you can think of it as the stairs problem where you can take 1 or x steps at a time
// but here the diffrent amounts of steps you can take are the coin denominations
// I think we can also get fancy with a greedy option that tries to use the largest denomntions first

function coinChange(coins: number[], amount: number): number {
    let memo = new Array<number>(amount);
    return coinChangeRecur(coins, amount, memo);
};

function coinChangeRecur(coins: number[], amount: number, memo: number[]): number {
    if(amount == 0){
        return 0;
    }
    if(amount < 0){
        return -1;
    }
//     The array should be set to undifiend on start, this will be falsey 
    if(memo[amount]){
        return memo[amount];
    }
    let min = -1;
    for(let i = 0; i<coins.length; i++){
        let iThCoinTry = coinChangeRecur(coins, amount - coins[i], memo) + 1;
        if(iThCoinTry > 0 && (iThCoinTry < min || min < 0)){
            min = iThCoinTry;
        }
    }
    memo[amount] = min;
    return min;
}
