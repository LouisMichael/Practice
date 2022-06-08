public class Solution {
//     I think the best way is greedy because I don't see how removing less the biggest would get you to save turns in a later round
//     to find a palandrome I think there is a all pivots and a two pointer method, I think all pivotes is simpler to think about
//     I did not do a good job of reading the problem at all, I was trying to solve for a substring and not a subsequance
//     public int RemovePalindromeSub(string s) {
//         int totalRounds =0;
//         while(s.Length > 0){
//             int maxStart = 0;
//             int maxEnd = 0;
//             int maxLength = 0;
//             for(int i = 0; i<s.Length*2; i++){
//                 int middle = i/2;
//                 if(i%2==0){
// // with no middle
//                     int curCheck = this.FindPalindrome(s, middle-1, middle);
//                     if(curCheck > maxLength){
//                         maxLength = curCheck;
//                         maxStart = middle -(maxLength/2);
//                         maxEnd = middle + (maxLength/2);
//                     }
//                 }
//                 else{
// // with one char as a middle
//                     int curCheck = this.FindPalindrome(s, middle, middle);
//                     if(curCheck > maxLength){
//                         maxLength = curCheck;
//                         maxStart = middle -(maxLength/2);
//                         maxEnd = middle + (maxLength/2);
//                     }
//                 }
//             }
//             totalRounds++;
//             if(s.Length-maxLength > 0){
//                 char[] newS = new char[s.Length-maxLength];
//                 for(int i = 0; i<newS.Length;i++){
//                     if(i<maxStart){
//                         newS[i] = s[i];
//                     }
//                     else{
//                         newS[i] = s[i+maxLength];
//                     }
//                 }
//                 s = new string(newS);
//                 Console.WriteLine(s);
//             }
//             else{
//                 break;
//             }
//         }
//         return totalRounds;
//     }
//     public int FindPalindrome(string s, int left, int right) {
//         int ret = 0;
//         Console.WriteLine("left: " + left);
//         Console.WriteLine("right: " + right);

//         while(left >= 0 && right < s.Length && s[left] == s[right]){
//             if(left==right){
//                 ret++;
//             }
//             else{
//                 ret+=2;
//             }
//             left--;
//             right++;
//         }
//         Console.WriteLine("ret: " + ret);
//         return ret;
//     }
    
//     Runtime: 74 ms, faster than 72.22% of C# online submissions for Remove Palindromic Subsequences.
// Memory Usage: 34.2 MB, less than 100.00% of C# online submissions for Remove Palindromic Subsequences.
    public int FindPalindrome(string s, int left, int right) {
        int ret = 0;
        // Console.WriteLine("left: " + left);
        // Console.WriteLine("right: " + right);

        while(left >= 0 && right < s.Length && s[left] == s[right]){
            if(left==right){
                ret++;
            }
            else{
                ret+=2;
            }
            left--;
            right++;
        }
        // Console.WriteLine("ret: " + ret);
        return ret;
    }
    public int RemovePalindromeSub(string s) {
        int left = 0;
        int right = s.Length/2;
        if(s.Length%2==0){
            left = s.Length/2 -1;
        }
        else{
            left = s.Length/2;
        }
        if(this.FindPalindrome(s,left,right) == s.Length){
            return 1;
        }
        return 2;
    }
    
}
