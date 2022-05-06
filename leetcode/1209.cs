// I think maybe a stack could be interesting where each 
// node is the letter and a count, if the count is == k then it 
// can pop, when we pop 

// my central slowdown may be in my string building at the end.
// Runtime: 240 ms, faster than 31.20% of C# online submissions for Remove All Adjacent Duplicates in String II.
// Memory Usage: 53.5 MB, less than 6.40% of C# online submissions for Remove All Adjacent Duplicates in String II.
// my solution was genraly the same as discussed solutions
public class Solution {
    public string RemoveDuplicates(string s, int k) {
        Stack<StackNode> stack = new Stack<StackNode>();
        for(int i = 0; i < s.Length;i++){
            if(stack.Count > 0 && stack.Peek().letter == s[i]){
                stack.Peek().count++;
                if(stack.Peek().count == k){
                    stack.Pop();
                }
            }
            else{
                StackNode newNode = new StackNode();
                newNode.letter = s[i];
                newNode.count = 1;
                stack.Push(newNode);
            }
        }
        string ret = "";
        while(stack.Count > 0){
            StackNode top = stack.Pop();
            string temp = "";
            for(int i = 0; i<top.count;i++){
                temp = temp + top.letter;
            }
            ret = temp + ret;
        }
        return ret;
    }
    private class StackNode{
        public int count;
        public char letter;
    }
}
