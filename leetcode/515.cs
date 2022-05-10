// 515
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
//     the "simple" way I think is to have an external sturcture to store the layer values in, populate this and then index over it to build the answer
//     Runtime: 169 ms, faster than 63.83% of C# online submissions for Find Largest Value in Each Tree Row.
// Memory Usage: 43.5 MB, less than 76.06% of C# online submissions for Find Largest Value in Each Tree Row.
    public Dictionary<int, int> levelDictionary;
    public int maxLevel;
    public IList<int> LargestValues(TreeNode root) {
        this.levelDictionary = new Dictionary<int, int>();
        List<int> ret = new List<int>();
        this.maxLevel = -1;
        this.LargestValuesLevelRecur(root, 0);
        
        for(int i = 0; i<= maxLevel; i++){
            ret.Add(this.levelDictionary[i]);
        }
        return ret;
    }
    public void LargestValuesLevelRecur(TreeNode root, int level){
        if(root == null){
            return;
        }
        if(level > maxLevel){
            maxLevel = level;
        }
        if(this.levelDictionary.ContainsKey(level)){
            if(this.levelDictionary[level] < root.val){
                this.levelDictionary[level] = root.val;
            }
        }
        else{
            this.levelDictionary[level] = root.val;
        }
        this.LargestValuesLevelRecur(root.right, level + 1);
        this.LargestValuesLevelRecur(root.left, level + 1);
    }
}
