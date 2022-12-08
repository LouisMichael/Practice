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
 function findLeaves(root: TreeNode|null, leaves: number[]): void{
    if(root == null){
        return;
    }
    if(root.left == null && root.right == null){
        leaves.push(root.val);
    }
    findLeaves(root.left, leaves);
    findLeaves(root.right, leaves);
};

function leafSimilar(root1: TreeNode | null, root2: TreeNode | null): boolean {
    let leaves1 = [];
    findLeaves(root1,leaves1);
    let leaves2 = [];
    findLeaves(root2, leaves2);
    if(leaves1.length != leaves2.length){
        return false;
    }
    for(let i = 0; i<leaves1.length; i++){
        if(leaves1[i] != leaves2[i]){
            return false;
        }
    }
    return true;
};

