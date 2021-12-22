// 72 ms, faster than 91.21% of TypeScript online submissions for Decode String.

function decodeString(s: string): string {
    let captureInt = "";
    let capturingInt = false;
    let captureGroup = "";
    let capturingGroup = false;
    let stack: captureNode[] = [];
    stack.push(new captureNode());
    for(let i = 0; i < s.length; i++){
        if(isInt(s[i]))
       {
            if(!capturingInt){
                capturingInt = true;
            }
            captureInt += s[i];
       }
        else{
            if(capturingInt){
                capturingInt = false;
                let newNode: captureNode = new captureNode();
                newNode.repeat = parseInt(captureInt, 10);
                stack.push(newNode);
                captureInt = "";
                // console.log("new node");
            }
            if(s[i] == ']'){
                // console.log("pop node");

                let finishNode = stack.pop();
                for(let i = 0; i < finishNode.repeat; i++){
                    stack[stack.length - 1].stringStore += finishNode.stringStore;
                }
            }
            if(s[i] != '[' && s[i] != ']'){
                // console.log(stack.length);
                stack[stack.length - 1].stringStore += s[i];
            }
        }
    
    }
    return stack.pop().stringStore;
};

function isInt(c: string){
    return c[0] == '0'
      || c[0] == '1'
      || c[0] == '2'
      || c[0] == '3'
      || c[0] == '4'
      || c[0] == '5'
      || c[0] == '6'
      || c[0] == '7'
      || c[0] == '8'
      || c[0] == '9';
}

class captureNode{
    public repeat: number = 0;
    public stringStore: string = "";
}
