// setting up a dictionary and then doing a look ahead for a value that maps higher was a good solution I saw as well
// Runtime: 98 ms, faster than 60.14% of C# online submissions for Roman to Integer.
// Memory Usage: 36.6 MB, less than 82.41% of C# online submissions for Roman to Integer.
public class Solution {
    public int RomanToInt(string s) {
        int cur = 0;
        for(int i = 0; i< s.Length;i++){
            if(s[i] == 'I'){
                if(i+1<s.Length && s[i+1] == 'V'){
                    i++;
                    cur += 4;
                }
                else if(i+1<s.Length && s[i+1] == 'X'){
                    i++;
                    cur += 9;
                }
                else{
                    cur += 1;
                }
            }
            else if(s[i] == 'V'){
                cur += 5;
            }
            else if(s[i] == 'X'){
                if(i+1<s.Length && s[i+1] == 'L'){
                    i++;
                    cur += 40;
                }
                else if(i+1<s.Length && s[i+1] == 'C'){
                    i++;
                    cur += 90;
                }
                else{
                    cur += 10;
                }
            }
            
            else if(s[i] == 'L'){
                cur += 50;
            }
            else if(s[i] == 'C'){
                if(i+1<s.Length && s[i+1] == 'D'){
                    i++;
                    cur += 400;
                }
                else if(i+1<s.Length && s[i+1] == 'M'){
                    i++;
                    cur += 900;
                }
                else{
                    cur += 100;
                }
            }
            
            else if(s[i] == 'D'){
                cur += 500;
            }
            
            else if(s[i] == 'M'){
                cur += 1000;
            }
        }
        return cur;
    }
}
