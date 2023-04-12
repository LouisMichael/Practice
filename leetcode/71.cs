public class Solution {
    public string SimplifyPath(string path) {
        Stack<string> stack =  new Stack<string>();
        string[] splitPath = path.Split('/');
        for(int i = 0; i<splitPath.Length;i++){
            if(splitPath[i].Equals(".")){
                continue;
            }
            if(splitPath[i].Equals("..")){
                if(stack.Count > 0){
                    stack.Pop();
                }
            }
            else if(splitPath[i].Length > 0){
                stack.Push(splitPath[i]);
            }
        }
        StringBuilder builder = new StringBuilder();
        string[] stackArray = stack.ToArray();
        Array.Reverse(stackArray);
        for(int i = 0; i<stackArray.Length;i++){
            builder.Append('/');
            builder.Append(stackArray[i]);
        }
        if(builder.Length > 0){
            return builder.ToString();
        }
        return "/";
    }
}
