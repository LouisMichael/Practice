// did this two ways one with the built in and that worked as expected 
// one with the two pointer method I think the problem is aiming to have you use
/**
 Do not return anything, modify s in-place instead.
 */
function reverseString(s: string[]): void {
    // s = s.reverse();
    let left = 0;
    let right = s.length -1;
    while(left < right){
        let temp = s[left];
        s[left]=s[right];
        s[right] = temp;
        left++;
        right --;
    }
};
