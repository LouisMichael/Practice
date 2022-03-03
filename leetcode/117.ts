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
    public Node Connect(Node root) {
        return this.ConnectNext(root, null);
    }
    
    public Node ConnectNext(Node root, Node next){
        if(root == null){
            return root;
        }
        root.next = next;
        Node rightChild = root.right;
        if(rightChild == null){
            rightChild = root.left;
        }
        this.ConnectNext(rightChild, this.FindNext(next));
        if(root.right != null && root.left != null){
            this.ConnectNext(root.left, root.right);
        }
        return root;
    }
    
    public Node FindNext(Node root){
        if(root == null){
            return root;
        }
        if(root.left != null){
            return root.left;
        }
        if(root.right != null){
            return root.right;
        }
        else{
            return this.FindNext(root.next);
        }
    }
}
