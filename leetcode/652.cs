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
    private HashSet<string> seen;
    private Dictionary<string, TreeNode> used; 
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root) {
        this.seen = new HashSet<string>();
        this.used = new Dictionary<string, TreeNode>();
        this.Traverse(root);
        return this.used.Values.ToList();
    }
    public string Traverse(TreeNode root){
        if(root == null){
            return "null";
        }
        string curHash = root.val + "," + this.Traverse(root.left)  + ","+ this.Traverse(root.right);
        if(this.seen.Contains(curHash)){
            if(!this.used.ContainsKey(curHash)){
                this.used[curHash] = root;
            }
        } 
        else{
            this.seen.Add(curHash);
        }
        return curHash;
    }
}
