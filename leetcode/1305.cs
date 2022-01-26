// start time 2:10
// accepted 2:43
// total time 33 min
// Runtime: 228 ms, faster than 87.78% of C# online submissions for All Elements in Two Binary Search Trees.
// Memory Usage: 48.7 MB, less than 82.22% of C# online submissions for All Elements in Two Binary Search Trees.

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
    public IList<int> GetAllElements(TreeNode root1, TreeNode root2) {
        List<int> leftListList = new List<int>();
        List<int> rightListList = new List<int>();
        List<int> solve = new List<int>();
        int leftPos = 0;
        int rightPos = 0;
        this.GetAllElementsSingleTree(root1, leftListList);
        this.GetAllElementsSingleTree(root2, rightListList);
        
        int[] leftList = leftListList.ToArray();
        int[] rightList = rightListList.ToArray();

        while(leftPos < leftList.Length && rightPos < rightList.Length){
            if(leftList[leftPos] < rightList[rightPos]){
                solve.Add(leftList[leftPos]);
                leftPos ++;
            }
            else{
                solve.Add(rightList[rightPos]);
                rightPos ++;
            }
        }
        for(; leftPos < leftList.Length; leftPos++){
            solve.Add(leftList[leftPos]);
        }
        for(; rightPos < rightList.Length; rightPos++){
            solve.Add(rightList[rightPos]);
        }
        return solve;
        
        
    }
    
    public void GetAllElementsSingleTree(TreeNode root, IList<int> list){
        if(root == null){
            return;
        }
        this.GetAllElementsSingleTree(root.left, list);
        list.Add(root.val);
        this.GetAllElementsSingleTree(root.right, list);
    }
}
