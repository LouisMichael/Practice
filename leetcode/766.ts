function isToeplitzMatrix(matrix: number[][]): boolean {
//     there are m + n - 1 diagnals
    for(let i = 0; i<matrix.length;i++){
        const curVal = matrix[i][0];
        // console.log(curVal);
        for(let j = i+1; j<matrix.length;j++){
            if(j-i < matrix[j].length && matrix[j][j-i] != curVal){
                return false;
            }
        }
    }
    for(let i = 1; i<matrix[0].length;i++){
        const curVal = matrix[0][i];
        // console.log(curVal);
        for(let j = i+1; j<matrix[0].length;j++){
            if(j-i < matrix.length && matrix[j-i][j] != curVal){
                return false;
            }
        }
    }
    return true;
};
