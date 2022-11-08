// I think this is a pretty simple stack problem

function makeGood(s: string): string {
    let stack = [];
    let stringInArray = s.split("");
    for(let i = 0; i<stringInArray.length;i++){
        // console.log(stack);
        // stack.length > 0 ? console.log(stack[stack.length-1].toUpperCase()) : console.log("0");
        if(stack.length > 0 && stack[stack.length-1] != stringInArray[i] && (stack[stack.length-1].toUpperCase() == stringInArray[i] ||stack[stack.length-1].toLowerCase() == stringInArray[i]) ){
            stack.pop();
        }
        else{
            stack.push(stringInArray[i]);
        }
    }
    return stack.join("");
};
