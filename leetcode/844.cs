// pretty straight forward usage of stacks, was good to use the method for less code repeat
// I think == works and is much faster then compare which I used in my first version
public class Solution {
    public bool BackspaceCompare(string s, string t) {
        return this.ProcessStringWithBackspace(t) == this.ProcessStringWithBackspace(s);
    }
    
    private string ProcessStringWithBackspace(string s){
        Stack<char> stackForS = new Stack<char>();
        foreach(char c in s){
            if(c == '#'){
                if(stackForS.Count != 0){
                    stackForS.Pop();
                }
            }
            else{
                stackForS.Push(c);
            }
        }
        return new string(stackForS.ToArray());
    }
}
