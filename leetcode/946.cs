// I think I need to do a scan across the pushed items for each poped item 
// I don't know if backtracking is the right call for this or not

// Runtime: 123 ms, faster than 69.64% of C# online submissions for Validate Stack Sequences.
// Memory Usage: 40.6 MB, less than 51.79% of C# online submissions for Validate Stack Sequences.

// ended up spending a lot of time thinking about a case that was not real, since we have uniqu values a greedy aproch works
// we don't have to worry about back tracking on duplicates
public class Solution {
    
    public bool ValidateStackSequences(int[] pushed, int[] popped) {
        int pushedLoc = 0;
        int poppedLoc = 0;
        Stack<int> cur = new Stack<int>();
        while(pushedLoc < pushed.Length && poppedLoc < popped.Length){
            cur.Push(pushed[pushedLoc]);
            pushedLoc++;
            while(cur.Count > 0 && cur.Peek() == popped[poppedLoc]){
                cur.Pop();
                poppedLoc++;
            }
        }
        return cur.Count == 0;
    }
}
