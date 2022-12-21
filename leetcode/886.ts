function possibleBipartition(n: number, dislikes: number[][]): boolean {
    class Node {
        public visited: boolean;
        public color: boolean | null;
        public links: number[]
        public constructor(){
            this.links = [];
        }   
    }
    // lets try to put them into two "colorings" true, and false
    // we can start at some value, and arbartarely assign it, then we can put all its disliks into a stack
    // then for each value in that stack we can color them, and put thier dislikes into a next stack
    // we can do this until all nodes have been assigned a color, or we reach a condrodiciotn
    // a note for making sure this works, this needs a bi directional connection which is not very explicit in the problem
    let nodeList: Node[] = []
    for(let i = 1; i<n+1;i++){
        nodeList[i] = new Node();
        nodeList[i].color = null;
    }
    for(let i = 0; i<dislikes.length;i++){
        nodeList[dislikes[i][0]].links.push(dislikes[i][1]);
        nodeList[dislikes[i][1]].links.push(dislikes[i][0]);
    }
    let curStack = [];
    let nextStack = [];
    let curColor = true;
    for(let node of nodeList){
        if(!node){
            continue;
        }
        if(node.color != null){
            continue;
        }
        nextStack.push(node);
        while(nextStack.length > 0){
            curStack = nextStack;
            nextStack = [];
            curColor = !curColor;
            while(curStack.length > 0){
                let cur = curStack.pop();
                if(cur.color != null){
                    if(cur.color == curColor){
                        continue;
                    }
                    return false;
                }
                cur.color = curColor;
                for(let link of cur.links){
                    nextStack.push(nodeList[link]);
                }
            }
        }
    }
    return true;
};
