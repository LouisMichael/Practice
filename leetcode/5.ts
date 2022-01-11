// Runtime: 277 ms, faster than 48.96% of TypeScript online submissions for Longest Palindromic Substring.
// Memory Usage: 44.9 MB, less than 55.06% of TypeScript online submissions for Longest Palindromic Substring.

function longestPalindrome(s: string): string {
    let max = "";
    for(let i = 0; i < s.length * 2 - 1; i++){
        let temp = longestPalindromeAtPivot(s, i);
         // console.log(temp);
        if(temp.length > max.length){
            max = temp;
        }
    }
    return max;
};

function longestPalindromeAtPivot(s: string, pos: number): string {
    let left = Math.floor(pos/2);
    let right = Math.ceil(pos/2); 
    // console.log(left + " is left " + right + " is right");
    let ret = "";
    while(left > -1 && right < s.length){
        if(s[left] != s[right]){
            left += 1;
            right -= 1;
            break;
        }
        else{
            ret = s.substring(left, right + 1);
            left -= 1;
            right += 1;
        }
    }
    return ret;
    
}
