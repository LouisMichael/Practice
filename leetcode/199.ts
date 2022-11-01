/**
 * Definition for a binary tree node.
 * class TreeNode {
 *     val: number
 *     left: TreeNode | null
 *     right: TreeNode | null
 *     constructor(val?: number, left?: TreeNode | null, right?: TreeNode | null) {
 *         this.val = (val===undefined ? 0 : val)
 *         this.left = (left===undefined ? null : left)
 *         this.right = (right===undefined ? null : right)
 *     }
 * }
 */
// if we don't care about memory we should just fill a structure in the order we see stuff to the right
function rightSideView(root: TreeNode | null): number[] {
    let seen = [];
    rightSideViewRecur(root, 1, seen);
    return seen;
};
function rightSideViewRecur(root: TreeNode | null, level:number, seen:number[]): void {
    if(root == null){
        return;
    }
    if(seen.length<level){
        seen.push(root.val);
    }
    rightSideViewRecur(root.right, level+1, seen);
    rightSideViewRecur(root.left, level+1, seen);
};
