// Runtime: 96 ms, faster than 77.38% of TypeScript online submissions for Excel Sheet Column Number.
// Memory Usage: 44.9 MB, less than 21.43% of TypeScript online submissions for Excel Sheet Column Number.

function titleToNumber(columnTitle: string): number {
    let cur = 0;
    for(let i = 0; i < columnTitle.length; i++){
        cur *= 26;
        cur += columnTitle[i].charCodeAt(0)-64;
    }
    return cur;
};
