/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
//     a breath first traversal and adding to a datastucrue could be good
//     I wonder if you can only store just the next one?
    public Dictionary<int,Node> dictionary;
    public Node Connect(Node root) {
        this.dictionary = new Dictionary<int, Node>();
        this.ConnectRecur(root, 0);
        return root;
    }
    
    public void ConnectRecur(Node root, int level) {
        if(root == null)
            return;
        if(this.dictionary.ContainsKey(level)){
            root.next = this.dictionary[level];
            this.dictionary[level] = root;
        }
        else{
            this.dictionary[level] = root;
        }
        this.ConnectRecur(root.right, level + 1);
        this.ConnectRecur(root.left, level + 1);
    }
}
