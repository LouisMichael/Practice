function longestPalindrome(words: string[]): number {
//     we are looking for two things, pairs that are forward and backwards + double letter words since they are internally palindromes
    let wordCounts = {};
    let doubles = {};
    let ret = 0;
    for(let i = 0; i<words.length; i++){
        if(words[i].charAt(0) == words[i].charAt(1)){
            if(doubles[words[i]]){
                doubles[words[i]]++;
            }
            else{
                doubles[words[i]] = 1;
            }
        }
        else{
            wordCounts[words[i]] ? wordCounts[words[i]]++ : wordCounts[words[i]] = 1;
        }
    }
    let usedOddDouble = false;
    for(let word in doubles){
        if(!usedOddDouble && doubles[word] > 0 && doubles[word] % 2 == 1){
            ret += 2;
            doubles[word]-1;
            usedOddDouble = true;
        }
        ret+= Math.floor(doubles[word]/2)*4;
    }
    for(let word in wordCounts){
        let wordReversed = word.split("").reverse().join("");
        if(wordCounts[wordReversed] && wordCounts[wordReversed] > 0){
            let pairUsage = Math.min(wordCounts[wordReversed],wordCounts[word])
            ret+=pairUsage*4;
            wordCounts[wordReversed] -= pairUsage;
            wordCounts[word] -= pairUsage;
        }
    }
    return ret;
};
