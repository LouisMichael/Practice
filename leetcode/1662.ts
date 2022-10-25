function arrayStringsAreEqual(word1: string[], word2: string[]): boolean {
    let leftWord = 0;
    let rightWord = 0;
    let leftLetter = 0;
    let rightLetter = 0;
    while(leftWord < word1.length && rightWord < word2.length){
        if(word1[leftWord][leftLetter] != word2[rightWord][rightLetter]){
            return false;
        } else{
            if(word1[leftWord].length-1 === leftLetter){
                leftWord++;
                leftLetter = 0;
            } else{
                leftLetter++;
            }
            if(word2[rightWord].length-1 === rightLetter){
                rightWord++;
                rightLetter = 0;
            } else{
                rightLetter++;
            }
        }
    }
    return (leftWord == word1.length && rightWord == word2.length);
};
