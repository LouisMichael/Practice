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
let max = 0;
function diameterOfBinaryTree(root: TreeNode | null): number {
    max = 0;
    diameterOfBinaryTreeRecur(root);
    return max;
};

// return the tallest child and sees if the distance between the tallest of its children is the max
function diameterOfBinaryTreeRecur(root: TreeNode): number {
    if(root == null){
        return 0;
    }
    
    let leftHight = diameterOfBinaryTreeRecur(root.left);
    let rightHight = diameterOfBinaryTreeRecur(root.right);
    if(leftHight + rightHight > max){
        max = leftHight + rightHight;
    }
    return Math.max(leftHight, rightHight)+1;
};
