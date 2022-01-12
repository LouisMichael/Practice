// Runtime: 214 ms, faster than 17.78% of TypeScript online submissions for Zigzag Conversion.
// Memory Usage: 45.5 MB, less than 42.62% of TypeScript online submissions for Zigzag Conversion.

function convert(s: string, numRows: number): string {
    if(numRows === 1){
        return s;
    }
    let solved: string[][] = [];
    let ret = "";
    for(let i = 0; i < numRows; i++){
        solved.push([]);
    }
    let curPos = 0;
    let desending = true;
    for(let i = 0; i < s.length; i++){
        let temp = s[i];
        solved[curPos].push(temp);
        if(desending){
            curPos += 1;
            if(curPos === numRows - 1){
                desending = !desending;
            }
        }else{
            curPos -= 1;
            if(curPos === 0){
                desending = !desending;
            }
        }
    }
    for(let i = 0; i < numRows; i++){
        for(let j = 0; j < solved[i].length; j++){
            ret += solved[i][j];
        }
    }
    return ret;
};
