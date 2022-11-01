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

function isSymmetric(root: TreeNode | null): boolean {
    return isMirror(root.left, root.right);
};
function isMirror(node1: TreeNode | null, node2: TreeNode | null): boolean {
    
    if(node1 == null && node2 == null){
        return true;
    }
    if(node1 == null || node2 == null){
        return false;
    }
    // console.log(node1.val);
    // console.log(node2.val);
    if(node1.val != node2.val){
        return false;
    }
    return isMirror(node1.left, node2.right) && isMirror(node1.right, node2.left);
};
