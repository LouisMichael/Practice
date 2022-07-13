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

// Runtime: 195 ms, faster than 59.94% of C# online submissions for Binary Tree Level Order Traversal.
// Memory Usage: 41.7 MB, less than 64.67% of C# online submissions for Binary Tree Level Order Traversal.
public class Solution {
    
    public IList<IList<int>> LevelOrder(TreeNode root) {
        return this.LevelOrderRecur(root, 0, new List<IList<int>>());
    }
    public IList<IList<int>> LevelOrderRecur(TreeNode root, int level, IList<IList<int>> cur) {
        if(root == null){
            return cur;
        }
        if(cur.Count < level + 1){
            cur.Add(new List<int>());
        }
        cur[level].Add(root.val);
        this.LevelOrderRecur(root.left, level + 1, cur);
        this.LevelOrderRecur(root.right, level + 1, cur);
        return cur;
    }
}
