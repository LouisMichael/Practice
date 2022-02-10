function reverseWords(s: string): string {
    let spacedWords = s.split(' ');
    let flippedWords = [];
    for(let word of spacedWords){
        flippedWords.push(reverse(word));
    }
    let ret = "";
    for(let i = 0;i < flippedWords.length-1;i++){
        ret += flippedWords[i] + " "
    }
    ret += flippedWords[flippedWords.length-1]
    return ret;
};

function reverse(s){
    return s.split("").reverse().join("");
}
