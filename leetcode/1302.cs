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
    public int DeepestLeavesSum(TreeNode root) {
        return this.DeepestLeavesSumRecur(root).Item2;
    }
    public (int,int) DeepestLeavesSumRecur(TreeNode root) {
        if(root.right == null && root.left == null){
            // Console.WriteLine(root.val);
            return (1, root.val);
        }
        
        if(root.right != null && root.left == null){
            // Console.WriteLine("moving right" + root.val);
            (int,int)temp = this.DeepestLeavesSumRecur(root.right);
            return (temp.Item1 + 1, temp.Item2);
        }
        
        if(root.left != null && root.right == null){
            // Console.WriteLine("moving left" + root.val);
            (int,int)temp = this.DeepestLeavesSumRecur(root.left);
            return (temp.Item1 + 1, temp.Item2);
        }
        
        (int, int) left = this.DeepestLeavesSumRecur(root.left);
        (int, int) right = this.DeepestLeavesSumRecur(root.right);
        if(left.Item1 > right.Item1){
            // Console.WriteLine("taking left" + root.val);
            return (left.Item1 + 1, left.Item2);
        }
        if(right.Item1 > left.Item1){
            // Console.WriteLine("taking right" + root.val);
            return (right.Item1 + 1, right.Item2);
        }
        else{
            // Console.WriteLine("compairing" + root.val);
            return (right.Item1 + 1, right.Item2 + left.Item2);
        }
    }
}
