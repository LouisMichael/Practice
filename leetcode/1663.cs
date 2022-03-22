public class Solution {
//     to make it as small as possible we want to only be using a at the end 
//     to do this we need to keep track of positions remaining and score remaining
    
    public string GetSmallestString(int n, int k) {
        char[] ret = new char[n];
        int curScore = k;
        for(int i = n-1; i >= 0; i--){
            if(curScore - i > 0){
                int next = Math.Min(26,curScore - i);
                ret[i] = Convert.ToChar(next + 'a' - 1);
                curScore -= next;
            } else{
                Console.WriteLine("Unexpected case where score is not possible");
            }
        }
        return new string(ret);
    }
}
