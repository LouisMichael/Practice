// start 12:37
// finish 12:41
// Runtime: 114 ms, faster than 65.63% of TypeScript online submissions for Matrix Diagonal Sum.
// Memory Usage: 45.1 MB, less than 6.25% of TypeScript online submissions for Matrix Diagonal Sum.
function diagonalSum(mat: number[][]): number {
    let total =0;
    for(let i = 0; i < mat.length; i++){
        total += mat[i][i];
    }
    for(let i = 0; i < mat.length; i++){
        let secondary = mat.length - 1 - i;
        if(secondary != i){
            total += mat[secondary][i];
        }
    }
    return total;
};
