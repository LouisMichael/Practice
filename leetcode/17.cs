
public class Solution {
//     I am going to start by doing it as top down recursion because that does not need many lines then I am going to think of maybe a way to work iteratevely
    public IList<string> LetterCombinations(string digits) {
        List<string> ret = new List<string>();
        string[][] digitsList = new string[9][]; 
        digitsList[0] = new string[] {};
        digitsList[1] = new string[] {"a","b","c"};
        digitsList[2] = new string[] {"d","e","f"};
        digitsList[3] = new string[] {"g","h","i"};
        digitsList[4] = new string[] {"j","k","l"};
        digitsList[5] = new string[] {"m","n","o"};
        digitsList[6] = new string[] {"p","q","r","s"};
        digitsList[7] = new string[] {"t","u","v"};
        digitsList[8] = new string[] {"w","x","y","z"};
        
        if(digits.Length == 0){
            return ret;
        }
        IList<string> tempList = this.LetterCombinations(digits.Substring(1));
        foreach(string temp in tempList){
            foreach(string letter in digitsList[digits[0]-'1']){
                ret.Add(letter+temp);
            }
        }
        if(ret.Count == 0){
            foreach(string letter in digitsList[digits[0]-'1']){
                ret.Add(letter);
            }
        }
        return ret;
    }
}
