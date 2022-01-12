// Runtime: 132 ms, faster than 62.69% of TypeScript online submissions for Insert into a Binary Search Tree.
// Memory Usage: 46.8 MB, less than 85.07% of TypeScript online submissions for Insert into a Binary Search Tree.

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

function insertIntoBST(root: TreeNode | null, val: number): TreeNode | null {
    if(root === null){
        let ret = new TreeNode();
        ret.val = val;
        return ret;
    }
    if(root.val > val){
        root.left = insertIntoBST(root.left, val);
    }
    else{
        root.right = insertIntoBST(root.right, val);
    }
    return root;
};
