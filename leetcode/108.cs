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
    public TreeNode SortedArrayToBST(int[] nums) {
        return this.SortedArrayToBSTRecur(nums, 0, nums.Length-1);
    }
    public TreeNode SortedArrayToBSTRecur(int[] nums, int start, int end) {
        if(start > end){
            return null;
        }
        int midPoint = (start + end)/2;
        TreeNode newNode = new TreeNode();
        newNode.val = nums[midPoint];
        newNode.left = this.SortedArrayToBSTRecur(nums, start, midPoint-1);
        newNode.right = this.SortedArrayToBSTRecur(nums, midPoint+1, end);
        return newNode;
    }
}
