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

function maxAncestorDiff(root: TreeNode | null): number {
    return maxAncestorDiffRecur(root, root.val, root.val);
};

function maxAncestorDiffRecur(root: TreeNode| null, maxSoFar:number, minSoFar:number): number{
    if(root == null){
        return 0;
    }
    if(root.val > maxSoFar){
        maxSoFar = root.val;
    }
    if(root.val < minSoFar){
        minSoFar = root.val;
    }
    let maxAbsVal = Math.abs(minSoFar - maxSoFar);
    let maxLeft = maxAncestorDiffRecur(root.left, maxSoFar, minSoFar);
    let maxRight = maxAncestorDiffRecur(root.right, maxSoFar, minSoFar);
    return Math.max(maxAbsVal, maxLeft, maxRight);
};
