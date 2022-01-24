function detectCapitalUse(word: string): boolean {
    if(word[0] == word[0].toUpperCase()){
        let trimmedWord = word.substring(1);
        return trimmedWord.toUpperCase() == trimmedWord || trimmedWord.toLowerCase() == trimmedWord; 
    }
    else{
        return word == word.toLowerCase();
    }
};
