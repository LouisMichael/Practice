// if we don't have a memory restriction to do this in place we should just read the array, writing it to a place to be sorted, sort it and write it back
function diagonalSort(mat: number[][]): number[][] {
//     we have two lines of diagonals, the one that starts on the top row and the one that starts on the first colum
    let sorterSpace = [];
    console.log(mat.length);
    for(let i = 0; i<mat.length; i++){
        let x = i;
        let y = 0;
        while(x<mat.length && y < mat[x].length){
            sorterSpace.push(mat[x][y]);
            x++;
            y++;
        }
        // console.log(sorterSpace);
        sorterSpace.sort((n1,n2) => n1 - n2);
        // console.log(sorterSpace);
        x = i;
        y=0;
        let count = 0;
        while(x<mat.length && y < mat[x].length){
            mat[x][y] = sorterSpace[count];
            x++;
            y++;
            count++
        }
        sorterSpace = [];
    }
    for(let i = 0;i<mat[0].length;i++){
        let x = 0;
        let y = i;
        while(x<mat.length && y < mat[x].length){
            sorterSpace.push(mat[x][y]);
            x++;
            y++;
        }
        // console.log(sorterSpace);
        sorterSpace.sort((n1,n2) => n1 - n2);
        // console.log(sorterSpace);
        x = 0;
        y=i;
        let count = 0;
        while(x<mat.length && y < mat[x].length){
            mat[x][y] = sorterSpace[count];
            x++;
            y++;
            count++
        }
        sorterSpace = [];
    }
    return mat;
};
