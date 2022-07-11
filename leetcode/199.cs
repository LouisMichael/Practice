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
//     I think this is just a dfs with a key for the level you are on
//     Given the example it seems like you would be able to recurse down mostly just the right but if you don't have a right you need to use a left and if a layer does not exist on your subtree you need to look at other parts of the tree so a full traversal is needed.
//     the way this got written is O(2N) since I loop to build the list at the end instead of just taking the action when I am already at the location which I think could be faster
    public Dictionary<int,int> solveKey;
    public IList<int> RightSideView(TreeNode root) {
        this.solveKey = new Dictionary<int,int>();
        this.RightSideViewRecur(root, 0);
        List<int> ret = new List<int>();
        int count = 0;
        while(this.solveKey.ContainsKey(count)){
            ret.Add(this.solveKey[count]);
            count++;
        }
        return ret;
    }
    public void RightSideViewRecur(TreeNode root, int level) {
        if(root == null){
            return;
        }
        if(!this.solveKey.ContainsKey(level)){
            this.solveKey[level] = root.val;
        }
        this.RightSideViewRecur(root.right, level +1);
        this.RightSideViewRecur(root.left, level +1);
    }
    
}
