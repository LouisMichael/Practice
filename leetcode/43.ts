
// we need to go right to left
function add(num1: string, num2: string): string {
    if(num1.length < num2.length){
        let temp = num1;
        num1 = num2;
        num2 = temp;
    }
    //     num1 is now longer or the same as num2
    let carry = 0;
    let ret = "";
    if(num1.length === 1 && num1[0] === "0"){
        return num2;
    }
    if(num2.length === 1 && num2[0] === "0"){
        return num1;
    }
    for(let i = 0; i<num1.length;i++){
        let num2Val = num2.length-i >0 ? parseInt(num2[num2.length-(i+1)]) : 0;
        let num1Val = parseInt(num1[num1.length-(i+1)]);
        let nextVal = num1Val + num2Val + carry;
        carry = Math.floor(nextVal/10);
        nextVal = nextVal % 10;
        ret = `${nextVal}` + ret;

    }
    if(carry > 0){
        ret = `${carry}` + ret;
    }
    return ret;
}

function multiply(num1: string, num2: string): string {
//     lets order them by how long they are so we know ahead of time
    if(num1.length === 1 && num1[0] === "0"){
        return "0";
    }
    if(num2.length === 1 && num2[0] === "0"){
        return "0";
    }
    if(num1.length < num2.length){
        let temp = num1;
        num1 = num2;
        num2 = temp;
    }
    //     num1 is now longer or the same as num2
    let ret = "";
    for(let j = 0; j<num2.length;j++){
        let curMultiply = parseInt(num2[num2.length-(j+1)]);
        let carry = 0;
        let curValue = "";
        for(let i = 0; i<num1.length;i++){
            let num1Val = parseInt(num1[num1.length-(i+1)]);
            let nextVal = (curMultiply * num1Val) + carry;
            carry = Math.floor(nextVal/10);
            nextVal = nextVal % 10;
            curValue = `${nextVal}` + curValue;
        }
        if(carry > 0){
            curValue = `${carry}` + curValue;
        }
        if(curValue !== "0"){
           curValue = curValue + "0".repeat(j)
        }
        ret = add(ret, curValue);
    }
    return ret;
    
};
