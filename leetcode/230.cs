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
    public int offsetCount = 0;
    public int KthSmallest(TreeNode root, int k) {
        if(root == null){
            return -1;
        }
        int lookLeft = this.KthSmallest(root.left,k);
        if(lookLeft >= 0){
            return lookLeft;
        }
        this.offsetCount++;
        if(this.offsetCount == k){
            return root.val;
        }
        int lookRight = this.KthSmallest(root.right,k);
        if(lookRight > 0){
            return lookRight;
        }
        return -1;
    }
}
