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
    public bool IsValidBST(TreeNode root) {
        return this.IsValidBSTRecur(root, Int32.MinValue, Int32.MaxValue);
    }
    public bool IsValidBSTRecur(TreeNode root, long min, long max) {
        if(root == null){
            return true;
        }
        else if((long)root.val > max || (long)root.val < min){
            return false;
        }
        return this.IsValidBSTRecur(root.left, min, (long)root.val-1) && this.IsValidBSTRecur(root.right, (long)root.val+1, max);
    }
}
