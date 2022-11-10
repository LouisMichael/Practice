// this is a simple stack problem
function removeDuplicates(s: string): string {
    let stack = [];
    for(let i = 0; i<s.length;i++){
        if(stack.length > 0 && stack[stack.length-1] == s.charAt(i)){
            stack.pop();
        }
        else{
            stack.push(s.charAt(i));
        }
    }
    return stack.join("");
};
