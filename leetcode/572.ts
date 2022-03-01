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

// I took too many submissions, the main issue was that i was checking for sub tree and equal tree at many points when these tasks should be broken up
public class Solution {
     public bool IsSubtree(TreeNode root, TreeNode subRoot) {
         if(subRoot == null || root == null){
            return root == subRoot;
        }
         if(this.isSameTree(root,subRoot)){
             return true;
         }
         else{
             if(this.IsSubtree(root.left, subRoot)||this.IsSubtree(root.right, subRoot)){
                 return true;
             }
         }
         return false;
     }
    
    public bool isSameTree(TreeNode root, TreeNode subRoot){
        if(subRoot == null || root == null){
            return root == subRoot;
        }
        if(root.val == subRoot.val){
            if(this.isSameTree(root.right,subRoot.right) && this.isSameTree(root.left,subRoot.left)){
                return true;
            }
        }
        return false;
    }
}
