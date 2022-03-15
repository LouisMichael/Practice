// Runtime: 106 ms, faster than 75.37% of C# online submissions for Minimum Remove to Make Valid Parentheses.
// Memory Usage: 40.8 MB, less than 73.11% of C# online submissions for Minimum Remove to Make Valid Parentheses.
// there was a better version of this that mostly did the same thing but with string builder instead of my fake version of that behavior
public class Solution {
    public string MinRemoveToMakeValid(string s) {
//         try it out with one stack
        Stack<int> openPeren = new Stack<int>();
        bool[] removeLocations = new bool[s.Length];
        int removeCount = 0;
        for(int i = 0; i < s.Length;i++){
            if(s[i] == '('){
                openPeren.Push(i);
            }
            if(s[i]==')'){
                if(openPeren.Count > 0){
                    openPeren.Pop();
                }
                else{
                    removeLocations[i]=true;
                    removeCount++;
                }
            }
        }
        int removeOpenPeren = openPeren.Count;
        for(int i = 0; i < removeOpenPeren; i++){
            removeLocations[openPeren.Pop()] = true;
            removeCount++;
        }
        // Console.WriteLine(removeLocations.Count);
        char[] ret = new char[s.Length-removeCount];
        int retCount = 0;
        for(int i = 0; i < s.Length; i++){
            if(!removeLocations[i]){
                ret[retCount] = s[i];
                retCount++;
            }
            
        }
        return new string(ret);
    }
}
