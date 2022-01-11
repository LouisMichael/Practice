// Runtime: 158 ms, faster than 6.25% of TypeScript online submissions for Sum of Root To Leaf Binary Numbers.
// Memory Usage: 41.2 MB, less than 93.75% of TypeScript online submissions for Sum of Root To Leaf Binary Numbers.

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

function sumRootToLeaf(root: TreeNode | null): number {
    return sumRootToLeafRecur(root, "");
};

function sumRootToLeafRecur(root: TreeNode | null, curString: string): number {
    if(root === null){
        return 0;
    }
    let newString = `${curString}${root.val}`;
    if(root.left === null && root.right === null){
        return parseInt(newString, 2);
    }
    else{
        return sumRootToLeafRecur(root.left, newString) + sumRootToLeafRecur(root.right, newString);
    }
};
