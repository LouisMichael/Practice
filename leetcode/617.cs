// Runtime: 118 ms, faster than 58.99% of C# online submissions for Merge Two Binary Trees.
// Memory Usage: 40 MB, less than 42.86% of C# online submissions for Merge Two Binary Trees.
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
    public TreeNode MergeTrees(TreeNode root1, TreeNode root2) {
        if(root1 == null && root2 == null){
            return null;
        }
        if(root2 == null){
//             modifying when half is null is not needed since it will just make no change at ever next step=
            root1.left = this.MergeTrees(root1.left, null);
            root1.right = this.MergeTrees(root1.right, null);
            return root1;
        }
        if(root1 == null){
            root2.left = this.MergeTrees(null, root2.left);
            root2.right = this.MergeTrees(null, root2.right);
            return root2;
        }
        root1.val += root2.val;
        root1.left = this.MergeTrees(root1.left, root2.left);
        root1.right = this.MergeTrees(root1.right, root2.right);
        return root1;
    }
}
