function longestCommonSubsequence(text1: string, text2: string): number {
    // we can write this as a recursion problem, if we have a match we add to the total,
    // otherwise we can move forward on one the other or both words in search of more matches
    // we want to return the max of this, we can memo for speed ups using a 2d array of the 
    // index of each word
    let memo = new Array(text1.length).fill(0).map(() => new Array<number>(text2.length));
    return longestCommonSubsequenceRecur(text1, 0, text2, 0, memo);
};

function longestCommonSubsequenceRecur(text1: string, index1: number, text2: string, index2: number, memo: number[][]): number {
    let max = 0;
    // console.log("index 1: " + index1);
    // console.log("index 2: " + index2);
    if(index1 >= text1.length || index2 >= text2.length){
        return max;
    }
    if(memo[index1][index2] > 0){
        return memo[index1][index2];
    }
    if(text1[index1] == text2[index2]){
        max = 1 + longestCommonSubsequenceRecur(text1, index1 + 1, text2, index2+1, memo);
    } 
    else{
        max = Math.max(
            longestCommonSubsequenceRecur(text1, index1, text2, index2+1, memo),
            longestCommonSubsequenceRecur(text1, index1 + 1, text2, index2, memo),
            longestCommonSubsequenceRecur(text1, index1 + 1, text2, index2+1, memo)
        );
    }
    memo[index1][index2] = max;
    return max;
}
