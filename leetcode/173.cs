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
public class BSTIterator {
// Why do you not just put this in an array? Does that take too much mem?
//     I am going to do it that simple way first
//     simply way worked the challenge was to only use O(h) mem where h is the height of the tree. I am thinking you could use a stack or queue that trys to fill when you run out.
//     public Queue<int> inOrder; 
//     public BSTIterator(TreeNode root) {
//         this.inOrder = new Queue<int>();
//         this.Populate(root);
//     }
    
//     public void Populate(TreeNode root){
//         if(root == null){
//             return;
//         }
//         this.Populate(root.left);
//         this.inOrder.Enqueue(root.val);
//         this.Populate(root.right);
//     }
    
//     public int Next() {
//         int ret = this.inOrder.Dequeue();
//         // Console.WriteLine(ret);
//         return ret;
//     }
    
//     public bool HasNext() {
//         return this.inOrder.Count > 0;
//     }
//     this way got slower but did save memory, but not a lot
    public Stack<TreeNode> stack; 
    public BSTIterator(TreeNode root) {
        this.stack = new Stack<TreeNode>();
        this.PushLefts(root);
    }
    public void PushLefts(TreeNode root){
        if(root == null){
            return;
        }
        this.stack.Push(root);
        this.PushLefts(root.left);
    }
    public int Next() {
        TreeNode next = this.stack.Pop();
        this.PushLefts(next.right);
        return next.val;
    }
    
    public bool HasNext() {
        return this.stack.Count != 0;
    }
//     A cheesy way to save space is to break the given tree so it is an in order line, lol
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */
