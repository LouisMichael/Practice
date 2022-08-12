/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
//         an easy way is to just keep a list of all parents and then when finding the second node walk the two lists
//          I feel like there should be a simpler way
//         it is a binary search tree so math!
//         the lowest common ansetor will be the first time the values are split by the node we are on
        if(root == null || p == null || q == null){
            return null;
        }
        if(
            ((root.val >= p.val) && (root.val <= q.val))
            ||
            ((root.val <= p.val) && (root.val >= q.val))
        ){
            return root;
        }
        if(root.val > p.val && root.val > q.val){
            return this.LowestCommonAncestor(root.left, p, q);
        }
        return this.LowestCommonAncestor(root.right, p, q);
    }
}
