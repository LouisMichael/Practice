// Runtime: 154 ms, faster than 22.22% of TypeScript online submissions for Koko Eating Bananas.
// Memory Usage: 42 MB, less than 88.89% of TypeScript online submissions for Koko Eating Bananas.
// Binary serach seems to be popular in other submissions, I may be able to optomize some by not doing it as a recursive function.
function minEatingSpeed(piles: number[], h: number): number {
    let maxPile = 0;
    for(let i = 0; i < piles.length; i++){
        if(piles[i]>maxPile){
            maxPile = piles[i];
        }
    }
    return minEatingSpeedSearch(piles, h, maxPile, 1);
};

function minEatingSpeedSearch(piles: number[], h:number, hRangeHigh: number, hRangeLow: number){
    let count = 0;
    let rate = Math.floor((hRangeLow + hRangeHigh) / 2);
    if(hRangeHigh < hRangeLow){
        return Number.MAX_SAFE_INTEGER;
    }
    for(let i = 0; i < piles.length; i++){
        count += Math.ceil(piles[i]/rate);
        if(count > h){
            return minEatingSpeedSearch(piles, h, hRangeHigh, rate + 1);
        }
    }
    return Math.min(rate, minEatingSpeedSearch(piles, h, rate - 1, hRangeLow));
}
