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

function pathSum(root: TreeNode | null, targetSum: number): number {
    return pathSumRecur(root, targetSum, []);
};

function pathSumRecur(root: TreeNode | null, targetSum: number, runningSums: number[]): number {
    if(root == null){
        return 0;
    }
    let ret = 0;
    runningSums.push(0);

    for(let i = 0; i<runningSums.length;i++){
        runningSums[i] += root.val;
        if(runningSums[i] == targetSum){
            ret++;
        }
    }
    let pathSumLeft = pathSumRecur(root.left, targetSum, [...runningSums]);
    let pathSumRight = pathSumRecur(root.right, targetSum, [...runningSums]);
    return ret + pathSumLeft + pathSumRight;
};
