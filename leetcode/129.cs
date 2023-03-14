/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int SumNumbers(TreeNode root) {
        return SumNumbersRecur(root, 0);
    }
    public int SumNumbersRecur(TreeNode root, int cur) {
        if(root == null){
            return 0;
        }
        cur = (cur * 10) + root.val;
        if(root.left == null && root.right == null){
            return cur;
        }
        else{
            return this.SumNumbersRecur(root.left, cur) + this.SumNumbersRecur(root.right, cur);
        }
    }
}
