// can a word be shown more than once?
// a tri is a good way to store the word list
// I had to run a test case for this but you should not have repeats in the output

function findWords(board: string[][], words: string[]): string[] {
    let ret = [];
    let triHead = buildTri(words);
    let used = new Array<boolean[]>(board.length);
    for(let i = 0; i<board.length;i++){
        used[i]= new Array<boolean>(board[i].length);
    }
    for(let i = 0; i<board.length;i++){
        for(let j=0;j<board[i].length;j++){
            
            findWordsRecur(board, triHead, used, i, j, ret);
        }
    }
    return ret;
}

function findWordsRecur(board: string[][], curNode: TriNode, used: boolean[][], posX: number, posY:number, ret: string[]): void {
    if(posX < 0 || posX > board.length -1 || posY < 0 || posY > board[posX].length-1) {
        return;
    }
    if(used[posX][posY]){
        return;
    }
    used[posX][posY] = true;
    let nextNode = curNode.next[board[posX][posY].charCodeAt(0)-"a".charCodeAt(0)];
    if(nextNode){
        if(nextNode.isValid){
            ret.push(nextNode.word);
            nextNode.isValid = false;
            // console.log(used);
        }
        findWordsRecur(board, nextNode, used, posX + 1, posY, ret);
        findWordsRecur(board, nextNode, used, posX, posY + 1, ret); 
        findWordsRecur(board, nextNode, used, posX - 1, posY, ret); 
        findWordsRecur(board, nextNode, used, posX, posY - 1, ret);      
    }
    
    used[posX][posY] = false;
}

function buildTri(words: string[]): TriNode{
    let head = new TriNode();
    for(let i = 0; i<words.length;i++){
        let cur = head;
        for(let j = 0; j<words[i].length;j++){
            let nextNode = cur.next[words[i].charCodeAt(j) - "a".charCodeAt(0)];
            if(!nextNode){
                nextNode = new TriNode();
                nextNode.cur = words[i].charAt(j);
                cur.next[words[i].charCodeAt(j) - "a".charCodeAt(0)] =nextNode;
            }
            cur = nextNode;
        }
        cur.isValid = true;
        cur.word = words[i];
    }
    return head;
}

class TriNode{
    public next: TriNode[];
    public cur: string;
    public isValid: boolean;
    public word: string;
    public constructor(){
        this.next = new Array<TriNode>(26);
        this.isValid = false;
    }
}
