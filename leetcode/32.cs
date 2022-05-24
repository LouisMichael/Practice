public class Solution {
//     I think we may need two stacks one that is the length of ranges and one that is tracking the paren
//     there is apparently also a no extra space way to do this and a dp way to do this
    public int LongestValidParentheses(string s) {
        Stack<int> startParen = new Stack<int>();
        Stack<int> setLength = new Stack<int>();
        Stack<int> setLocations = new Stack<int>();
        int max = 0;
        for(int i = 0; i<s.Length;i++){
            if(s[i] == '('){
                startParen.Push(i);
            }
            else{
                if(startParen.Count>0){
                    int openingLocal = startParen.Pop();
                    int size = i - openingLocal + 1;
                    while(setLocations.Count>0 && setLocations.Peek() > openingLocal){
                        setLocations.Pop();
                        setLength.Pop();
                    }
                    // Console.WriteLine(setLocations.Count);
                    if(setLocations.Count>0 && (startParen.Count == 0 || startParen.Peek() < setLocations.Peek())){
                        int naborSetLength = setLength.Pop();
                        setLength.Push(size + naborSetLength);
                    }
                    else{
                        setLength.Push(size);
                        setLocations.Push(openingLocal);
                    }
                    if(setLength.Peek() > max){
                        max = setLength.Peek();
                    }
                }
                else{
//                     straggle closing can divide valid ranges
                    startParen = new Stack<int>();
                    setLength = new Stack<int>();
                    setLocations = new Stack<int>();
                }
            }
        }
        return max;
    }
}
