function minFallingPathSum(matrix: number[][]): number {
    let maxFrom = [];
    for(let i = 0; i<matrix.length-1;i++){
        maxFrom.push([]);
    }
    maxFrom.push(matrix[matrix.length-1]);
    for(let i = matrix.length-2; i>=0; i--){
        for(let j = 0; j < matrix[i].length;j++){
            maxFrom[i][j] = matrix[i][j];
            let maxTest = maxFrom[i+1][j];
            if(j > 0){
                maxTest = Math.min(maxTest, maxFrom[i+1][j-1]);
            }
            if(j < matrix[i].length-1){
                maxTest = Math.min(maxTest, maxFrom[i+1][j+1]);
            }
            console.log(maxTest)
            maxFrom[i][j] += maxTest;
        }
    }
    let maxTotal = maxFrom[0][0];
    for(let j = 0; j<matrix[0].length;j++){
        maxTotal = Math.min(maxTotal, maxFrom[0][j]);
    }
    return maxTotal;
};
