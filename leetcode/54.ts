function spiralOrder(matrix: number[][]): number[] {
    let left = 0;
    let bottom = matrix.length;
    let top = 0; 
    let right = matrix[0].length;
    let count = 0;
    let total = right * bottom;
    let ret: number[] = [];
    while(count < total){
        for(let i = left; i < right; i++){
            ret[count] = matrix[top][i];
            count++;
        }
        if(count >= total){
            break;
        }
        top++;
        for(let i = top; i<bottom;i++){
            ret[count] = matrix[i][right-1];
            count++;
        }
        if(count >= total){
            break;
        }
        right--;
        
        for(let i = right-1; i>=left;i--){
            ret[count] = matrix[bottom-1][i];
            count++;
        }
        if(count >= total){
            break;
        }
        bottom--;
        for(let i = bottom-1; i>=top;i--){
            ret[count] = matrix[i][left];
            count++;
        }
        if(count >= total){
            break;
        }
        left++;
    }
    return ret;
};
