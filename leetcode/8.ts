// Runtime: 160 ms, faster than 22.05% of TypeScript online submissions for String to Integer (atoi).
// Memory Usage: 42.3 MB, less than 19.88% of TypeScript online submissions for String to Integer (atoi).
// A thing I could have done better is to utilize the fact that JS can hold a mentisa of 52 bits since all number are 64 bit signed floats
function myAtoi(s: string): number {
    let ret = 0;
    let neg = false;
    let pos = 0;
//     step 1
    while(pos<s.length && s[pos] === ' '){
        pos += 1;
    }
//     step 2
    if(s[pos] === '-'){
        neg = true;
        pos += 1;
    }
    else if(s[pos] === '+'){
        neg = false;
        pos += 1;
    }
    let count = 0;
    while(pos<s.length && (parseInt(s[pos], 10) || parseInt(s[pos], 10) === 0)){
        // console.log(count);
        // console.log(ret);
        if(ret === 0 && parseInt(s[pos], 10) === 0){
            pos += 1;
            continue;
        }
        if(count > 9 || ret > 214748364){
            if(neg){
                return -2147483648
            }
            else{
                return 2147483647;
            }
        }
        if(ret === 214748364){
            if(parseInt(s[pos], 10) >= 8){
                if(!neg){
                    return 2147483647;
                }
            }
            if(parseInt(s[pos], 10) >= 9){
                if(neg){
                    return -2147483648
                }
            }
        }
        ret *= 10;
        ret += parseInt(s[pos], 10);
        count += 1;
        pos += 1;
    }
    if(neg)
        return ret * -1;
    return ret;
};
