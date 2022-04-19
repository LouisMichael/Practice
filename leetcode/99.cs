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
// my first attampt ended up being miss guided because I was trying to hard to use the tree strucutre, better explinatinos just thought about how it worked if you flattend it and then applied that idea to the traversal. 
public class Solution {
    TreeNode first = null;
    TreeNode second = null;
    TreeNode last = null;
    public void RecoverTree(TreeNode root) {
        this.InOrderCheck(root);
        int temp = first.val;
        first.val = second.val;
        second.val = temp;
    }
    
    public void InOrderCheck(TreeNode root){
        if(root == null){
            return;
        }
        this.InOrderCheck(root.left);
        if(last != null){
            if(last.val > root.val){
                if(first == null){
                    second = root;
                    first = last;
                }
                else{
                    second = root;
                }
            }
        }
        // Console.WriteLine(root.val);
        last = root;
        this.InOrderCheck(root.right);
    }
    
//     public TreeNode SearchForMissPlace(TreeNode root, int min, int max){
//         if(root == null){
//             return null;
//         }
//         if(root.val > max || root.val < min){
//             return root;
//         }
//         else{
//             TreeNode leftSearch = this.SearchForMissPlace(root.left, min, root.val);
//             TreeNode rightSearch = this.SearchForMissPlace(root.right, root.val, max);
//             if(leftSearch != null && rightSearch != null){
//                 return root;
//             }
//             if(leftSearch != null){
//                 return leftSearch;
//             }
//             return rightSearch;
//         }
//     }
    
//     public void FindSwap(TreeNode root, TreeNode missPlace){
//         if(root == null){
//             return;
//         }
//         if(root.left == missPlace && root.val < missPlace.val && (root.right == null || root.right.val > missPlace.val) ){
//             int temp = missPlace.val;
//             missPlace.val = root.val;
//             root.val = temp;
//             return; 
//         }
//         if(root.right == missPlace && root.val > missPlace.val && (root.left == null || root.left.val < missPlace.val) ){
//             int temp = missPlace.val;
//             missPlace.val = root.val;
//             root.val = temp;
//             return; 
//         }
//         if((root.left == null || missPlace.val > root.left.val) && (root.right == null || missPlace.val < root.right.val)){
//             int temp = missPlace.val;
//             missPlace.val = root.val;
//             root.val = temp;
//             return;
//         }
//         else{
//             this.FindSwap(root.left, missPlace);
//             this.FindSwap(root.right, missPlace);
//         }
//         return;
//     }
}
