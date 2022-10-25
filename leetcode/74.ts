// There is an okay way to do this where you search up/down then you search left/right but the best way is to pretend the whole thing is a line and seach the whole thing at once 

function searchMatrix(matrix: number[][], target: number): boolean {
    let left = 0;
    let width = matrix[0].length;
    let right = (matrix.length * width)-1;
    while(left <= right) {
        let mid = Math.floor((left + right)/2);
        let midVal = matrix[Math.floor(mid/width)][mid%width]
        console.log("mid: " + mid);
        console.log("midVal: " + midVal);
        if(midVal > target){
            right = mid - 1;
        } else if(midVal < target){
            left = mid + 1;
        } else{
            return true;
        }
    }
    return false;
};
