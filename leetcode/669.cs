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
// I could have done this better by just trimming each section using the base method
public class Solution {
    public TreeNode TrimBST(TreeNode root, int low, int high) {
//         trim low
        root = this.TrimBSTLow(root, low);
//         firstLowNode is now either the first value that needs to be trimmed or null, there still may be values that may need to be trimmed to the right of this value and all to the left need to be trimmed.
        root = this.TrimBSTHigh(root, high);
//         trim high
        return root;
    }
    
    public TreeNode TrimBSTLow(TreeNode root, int low){
        if(root == null){
            return null;
        }
        if(root.val < low){
            return this.TrimBSTLow(root.right, low);
        }
        root.left = this.TrimBSTLow(root.left, low);
        return root;
    }
    public TreeNode TrimBSTHigh(TreeNode root, int high){
        if(root == null){
            return null;
        }
        if(root.val > high){
            return this.TrimBSTHigh(root.left, high);
        }
        root.right = this.TrimBSTHigh(root.right, high);
        return root;
    }
}
