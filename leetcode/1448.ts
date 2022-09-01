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
// another way to think about the problem is that the node we arive at is >= to the max we have seen so far 
function goodNodes(root: TreeNode | null): number {
    return goodNodesRecur(root, -100000);

};

function goodNodesRecur(root: TreeNode | null, maxSoFar: number): number {
    let ret:number = 0;
    if(root == null){
        return ret;
    }
    if(root.val >= maxSoFar){
        maxSoFar = root.val;
        ret++;
    }
    ret += goodNodesRecur(root.left, maxSoFar);
    ret += goodNodesRecur(root.right, maxSoFar);
    return ret;
};
