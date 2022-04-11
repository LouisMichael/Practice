// Runtime: 112 ms, faster than 61.59% of C# online submissions for Multiply Strings.
// Memory Usage: 37.6 MB, less than 54.72% of C# online submissions for Multiply Strings.
// Mistakes I made were not doing multiply by 0 as a test case
// I also ran into an issue where 
public class Solution {
    public string Multiply(string num1, string num2) {
//         multiply each diget as a string
//         add the ouptputs as a string
//         large numbers being sotred as ints may cause issues
//         check for which is longer and make a swap at the top
        if(num1.Length < num2.Length){
            string temp = num1;
            num1 = num2;
            num2 = temp;
        }
        string[] results = new string[num2.Length];
        for(int i = num2.Length-1; i >=0 ; i--){
            int curRel = num2[i] - '0';
            // Console.WriteLine(curRel);
            string curResut = "";
            for(int j = 0 ; j < num2.Length-i-1; j++){
                curResut+='0';               
            }
            int carry = 0;
            for(int j = num1.Length-1 ; j >=0 ; j--){
                int curSpecific = curRel * (num1[j]-'0');
                // Console.WriteLine(curSpecific);
                curSpecific += carry;
                carry = curSpecific/10;
                curResut = (curSpecific%10) + curResut;
            }
            if(carry > 0){
                curResut = carry + curResut;
            }
            
            results[i]=curResut;
            // Console.WriteLine(curResut);
        }
        string cur = "";
        for(int i = results.Length-1; i>=0 ;i--){
            cur = this.Add(cur,results[i]);
            // Console.WriteLine(cur);
        }
        if(cur[0]=='0'){
            return "0";        
        }
        return cur;
    }
    
    public string Add(string num1, string num2) {
        string result = "";
//         check for which is longer
        if(num1.Length < num2.Length){
            string temp = num1;
            num1 = num2;
            num2 = temp;
        }
        int carry = 0;
        // Console.WriteLine(num1);
        // Console.WriteLine(num2);
        for(int i = 0; i<num2.Length ; i++){
            int temp = (num1[num1.Length-1-i] - '0') + (num2[num2.Length-1-i] - '0');
            temp += carry;
            carry = temp/10;
            result = (temp%10) + result;
            // Console.WriteLine(result);
        }
        for(int i = num1.Length - num2.Length-1; i>=0 ; i--){
            int temp = (num1[i] - '0');
            temp += carry;
            carry = temp/10;
            result = (temp%10) + result;
        }
        // Console.WriteLine(result);
        if(carry > 0){
            result = carry + result;
        }
        // Console.WriteLine(result);
        return result;
    }
}
