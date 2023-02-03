public class Solution {
    public string Convert(string s, int numRows) {
        // I don't think there will be a faster then O(n) way to do this so I will just pick some O(n) way, I will go with tracking the current row 
        // that I am adding to, adding one char at a time and then ajusting the zigzag, then at the end I will merge my rows for my return value
        
        string[] rowChars = new string[numRows];
        if(numRows == 1){
            return s;
        }
        for(int i = 0; i<s.Length;i++){
            // Console.WriteLine("i: " + i);
            if((i%(numRows*2-2))/numRows == 0){
                // Console.WriteLine(i%(numRows*2-2));
                rowChars[i%(numRows*2-2)]+=s[i];
            }
            else {
                // Console.WriteLine((2*numRows-2)-(i%(numRows*2-2)));

                rowChars[((2*numRows-2)-(i%(numRows*2-2)))]+=s[i];
            }
        }
        string ret = "";
        for(int i =0; i<rowChars.Length;i++){
            ret += rowChars[i];
        }
        return ret;
    }
}
