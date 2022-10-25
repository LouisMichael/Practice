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

function isBalanced(root: TreeNode | null): boolean {
    return isBalancedRecur(root) >= 0;
};

function isBalancedRecur(root: TreeNode | null): number {
    if(root == null){
        return 0;
    }
    let leftHeight = isBalancedRecur(root.left) + 1;
    let rightHeight = isBalancedRecur(root.right) + 1;
    if(leftHeight == 0 || rightHeight == 0){
        return -1;
    }
    else{
        if(leftHeight - rightHeight > 1 || rightHeight - leftHeight > 1){
            return -1;
        }
        return(Math.max(leftHeight, rightHeight));
    }
};
