function halvesAreAlike(s: string): boolean {
    let vowelCount1 = 0;
    let vowelCount2 = 0;
    let half = Math.floor(s.length/2);
    for(let i = 0; i<half;i++){
        if(isVowel(s[i])){
            vowelCount1++;
        }
        if(isVowel(s[i+half])){
            vowelCount2++;
        }
    }
    // console.log(vowelCount1);
    // console.log(vowelCount2);
    return vowelCount1 === vowelCount2;
};
function isVowel(check: string): boolean{
    return ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'].includes(check.charAt(0));
}
