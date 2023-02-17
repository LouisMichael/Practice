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
    public int last;
    public int min;
    public int MinDiffInBST(TreeNode root) {
        // its already sorted just as a tree!
        // in the sorted set our answer will be two values that are next to each other
        // we will look at the values in order if we do a in order traversal of the tree
        this.last = -1;
        this.min = -1;
        this.NextInOrder(root);
        return this.min;
    }
    public void NextInOrder(TreeNode root) {
        if(root == null){
            return;
        }
        this.NextInOrder(root.left);
        if(this.last == -1){
            this.last = root.val;
        }
        else {
            int diff = root.val - this.last;
            if(min == -1 || diff < min){
                min = diff;
            }
            this.last = root.val;
        }
        this.NextInOrder(root.right);
    }
}
