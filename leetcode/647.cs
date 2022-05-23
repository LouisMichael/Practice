public class Solution {
//     to find one you could use two pointer really well
//     to find more then one you have to check every location to see if it is a pivot?
//     I think you just try every section as a pivot and try to expand
//     there seems to be a way to use dp to go over diffrent areas by length and see if you can expand into a size at a given position
    public int CountSubstrings(string s) {
        int total = 0;
        for(int i = 0; i< s.Length;i++){
            total += this.CheckPalindromeAt(s, i);
            total += CheckPalindromeAfter(s, i);
        }
        return total;
    }
    public int CheckPalindromeAt(string s, int i){
        int ret = 1;
        if(i >= s.Length-1 || i-1 < 0){
            return 1;
        }
        int left = i-1;
        int right = i+1;
        while(left >= 0 && right < s.Length && s[left] == s[right]){
            ret++;
            left --;
            right ++;
        }
        return ret;
    }
    public int CheckPalindromeAfter(string s, int i){
        int ret = 0;
        if(i >= s.Length-1){
            return 0;
        }
        int left = i;
        int right = i+1;
        while( left >= 0 && right < s.Length && s[left] == s[right]){
            ret++;
            left --;
            right ++;
        }
        return ret;
    }
}

// aaa
// a|a|a
// aa|a..
// a|aa|...
