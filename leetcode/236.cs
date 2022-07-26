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
//     fast as possible is something like move each every iteration and keep a map of both first dup is the ansestor, that assumes being able to go up, lol
//     I guess we want to do like dfs and the first time we see that 2 were found at one node we return that as the answer
    
    public TreeNode ret;
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        this.FindNodes(root, p, q);
        return this.ret;
    }
//     returns how many nodes are ansestors
    public int FindNodes(TreeNode root, TreeNode p, TreeNode q) {
        if(root == null){
            return 0;
        }
        int ret = 0;
        if(root == p || root == q){
            ret += 1;
        }
        ret += this.FindNodes(root.left, p, q);
        ret += this.FindNodes(root.right, p, q);
        if(ret >= 2 && this.ret == null){
            this.ret = root;
        }
        return ret;
    }
}
