function closeStrings(word1: string, word2: string): boolean {
    // since we can switch all letter locations and we can switch all letter meanings I think we only care about the number of times each letter occurs and that the same letter appear in each word
    let letterCountsInWord1 = new Array<number>(26).fill(0);
    let letterCountsInWord2 = new Array<number>(26).fill(0);
    if(word1.length != word2.length){
        return false;
    }
    for(let i = 0; i<word1.length;i++){
        letterCountsInWord1[word1[i].charCodeAt(0) - 'a'.charCodeAt(0)]++;
        letterCountsInWord2[word2[i].charCodeAt(0) - 'a'.charCodeAt(0)]++;
    }
    // console.log(letterCountsInWord1);
    // console.log(letterCountsInWord2);
    for(let i = 0; i<26;i++){
        if(letterCountsInWord1[i] > 0 && letterCountsInWord2[i] == 0 || letterCountsInWord2[i] > 0 && letterCountsInWord1[i] == 0){
            return false;
        }
    }
    letterCountsInWord1.sort();
    letterCountsInWord2.sort();
    for(let i = 0; i<26;i++){
        if(letterCountsInWord1[i] != letterCountsInWord2[i]){
            return false;
        }
    }
    return true;
};
