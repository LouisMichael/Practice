function reverseVowels(s: string): string {
let vowlLocatons = [];
let vowelsInWord = [];
let vowels = ['a','e','i','o','u','A','E','I','O','U'];
let retArray = s.split('');
for(let i = 0; i<retArray.length;i++){
    if(vowels.includes(retArray[i])){
        vowlLocatons.push(i);
        vowelsInWord.push(retArray[i]);
    }
}
// console.log(vowelsInWord);
for(let i = 0; i<vowelsInWord.length; i++){
    retArray[vowlLocatons[vowelsInWord.length-i-1]] = vowelsInWord[i];
}
return retArray.join("");
};
