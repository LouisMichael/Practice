public class Solution {
    public int MinInsertions(string s) {
//         the )) must be next to each other, clarification recived
//         thinking about cases, when you see ( you will have to find a )) to follow, if there is not a )) you will have to make one
//         if you find )) it either closes a ( or we will need to add a ( for it to close
//         if you find a ) without a second, you will have to add a ) and repeat the steps for finding a ))
//         I think you can maintian one stack and run cases, and get a O(N) run time, and O(N) memory
//         with paren problems you can also usally run with constant extra memory by just running a tally
        Stack<bool> paranStack = new Stack<bool>();
        int ret = 0;
        for(int i = 0; i<s.Length; i++){
            if(s[i] == '('){
                paranStack.Push(true);
            }
            else if(s[i] == ')'){
                if(i+1 >= s.Length || s[i+1] != ')'){
//                     we can't have un paired closing
                    ret++;
                }
                else{
                    i++;
                }
                if(paranStack.Count > 0){
                    paranStack.Pop();
                }
                else{
//                     we have to add the opening pair for this colosing set
                    ret++;
                }
            }
        }
//         every opening not closed adds two closing. 
        // Console.WriteLine(paranStack.Count);
        ret = ret + ((paranStack.Count)*2);
        return ret;
    }
}
