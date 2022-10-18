let isSeen: Map<number,boolean> = null;
function isHappy(n: number): boolean {
    isSeen = new Map<number, boolean>();
    return isHappyRecur(n);
};

function isHappyRecur(n: number): boolean{

    console.log(n);
    if(n == 1){
        return true;
    }
    if(isSeen[n] != null){
        return false;
    }
    else {
        isSeen[n] = true;
        let next = 0;
        while(n > 0){
            next += (n%10)*(n%10);
            n = Math.floor(n/10);
        }
        return (isHappyRecur(next));
    }
}
