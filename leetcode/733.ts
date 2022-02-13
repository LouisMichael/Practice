// Runtime: 76 ms, faster than 97.67% of TypeScript online submissions for Flood Fill.
// Memory Usage: 45.4 MB, less than 8.37% of TypeScript online submissions for Flood Fill.
function floodFill(image: number[][], sr: number, sc: number, newColor: number): number[][] {
    if(image[sr][sc] == newColor){
        return image;
    }
    return floodFillRecur(image, sr, sc, newColor, image[sr][sc]);
}
function floodFillRecur(image: number[][], sr: number, sc: number, newColor: number, oldColor: number): number[][] {
    if(sr < 0 || sr > image.length-1){
        return image;
    }
    if(sc < 0 || sc > image[sr].length-1){
        return image;
    }
    if(image[sr][sc] == oldColor){
        image[sr][sc] = newColor;
    }
    else{
        return image;
    }
    image = floodFillRecur(image, sr +1, sc, newColor, oldColor);
    image = floodFillRecur(image, sr -1, sc, newColor, oldColor);
    image = floodFillRecur(image, sr, sc+1, newColor, oldColor);
    image = floodFillRecur(image, sr, sc-1, newColor, oldColor);
    return image;
};
