/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
// 1379 this did not feel very medium, I think after understaning what is being asked it is pretty simple 
public class Solution {
//     they are not sorted!!
//     a bfs seems like it would be okay, a dfs seems like it would be okay, I don't undesrtand how we should search through this faster then looking at all the nodes
//     ooooh we get the root of both trees so I guess the goal is to keep a stack of the moves we made to get to the target in orignal and then repeat them. 
//     I think a deque would be good at this but I think a list that gets reversed would be okay too
// Runtime: 410 ms, faster than 60.66% of C# online submissions for Find a Corresponding Node of a Binary Tree in a Clone of That Tree.
// Memory Usage: 48.9 MB, less than 70.49% of C# online submissions for Find a Corresponding Node of a Binary Tree in a Clone of That Tree.
    
//     public List<bool> order;
//     public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target) {
//         this.order = new List<bool>();
//         return this.GetTargetCopyRecur(original, cloned, target);
//     }
//     public TreeNode GetTargetCopyRecur(TreeNode original, TreeNode cloned, TreeNode target) {
//         if(original == null){
//             return null;
//         }
//         if(original == target){
// //             we have found our goal, now we want to reverse our list and get to this spot in clone
//             // Console.WriteLine(original.val);
//             // this.order.Reverse();
//             for(int i = 0; i<this.order.Count; i++){
//                 // Console.WriteLine(this.order[i]);
//                 if(this.order[i]){
//                     cloned = cloned.right;
//                 }
//                 else{
//                     cloned = cloned.left;
//                 }
//             }
//             return cloned;
//         }
//         else{
//             this.order.Add(false);
//             TreeNode left = this.GetTargetCopyRecur(original.left, cloned, target);
//             if(left != null){
//                 return left;
//             }
//             this.order.RemoveAt(this.order.Count-1);
//             this.order.Add(true);
//             TreeNode right = this.GetTargetCopyRecur(original.right, cloned, target);
//             if(right != null){
//                 return right;
//             }
//             this.order.RemoveAt(this.order.Count-1);
//             return null;
//         }
//     }
//     Runtime: 509 ms, faster than 13.12% of C# online submissions for Find a Corresponding Node of a Binary Tree in a Clone of That Tree.
// Memory Usage: 49.1 MB, less than 34.43% of C# online submissions for Find a Corresponding Node of a Binary Tree in a Clone of That Tree.
    public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target) {
        if(original == null){
            return null;
        }
        if(original == target){
            return cloned;
        }
        TreeNode left = this.GetTargetCopy(original.left, cloned.left, target);
        if(left != null){
            return left;
        }
        TreeNode right = this.GetTargetCopy(original.right, cloned.right, target);
        if(right != null){
            return right;
        }
        return null;
    }
}
