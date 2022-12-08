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

function rangeSumBST(root: TreeNode | null, low: number, high: number): number {
    let ret = 0;
    if(root == null){
        return ret;
    }
    ret += rangeSumBST(root.right, low, high) + rangeSumBST(root.left, low, high);
    if(root.val >= low && root.val <= high){
        ret += root.val;
    }
    return ret;
};
