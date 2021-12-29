// Runtime: 146 ms, faster than 12.74% of TypeScript online submissions for Populating Next Right Pointers in Each Node.
// Memory Usage: 45.4 MB, less than 99.02% of TypeScript online submissions for Populating Next Right Pointers in Each Node.
// Notes: I guess function calls are very expensive here but that their memory usage is also not counted 
// Faster solutions employed as very similar approch but just kept a cur pointer instead of recursing.
/**
 * Definition for Node.
 * class Node {
 *     val: number
 *     left: Node | null
 *     right: Node | null
 *     next: Node | null
 *     constructor(val?: number, left?: Node, right?: Node, next?: Node) {
 *         this.val = (val===undefined ? 0 : val)
 *         this.left = (left===undefined ? null : left)
 *         this.right = (right===undefined ? null : right)
 *         this.next = (next===undefined ? null : next)
 *     }
 * }
 */
let levelDictionary = {};
function connect(root: Node | null): Node | null {
    levelDictionary = {};
    connectRecur(root, 0);
    return root;
};

function connectRecur(root: Node | null, level: number): void{
    if(root == null){
        return;
    }
    if(levelDictionary[level] != null){
        root.next = levelDictionary[level];
    }
    levelDictionary[level] = root;
    connectRecur(root.right, level + 1);
    connectRecur(root.left, level + 1);
}
