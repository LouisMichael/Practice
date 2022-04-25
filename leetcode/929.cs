public class Solution {
    public int NumUniqueEmails(string[] emails) {
//         the net goal is to get unique local + domain combos. Since we know we only get one @ and none of the 
//         special rules apply to the domian our first goal can be to split on the @ and just get the domain
//         next we can apply rules to the local
//         then we can use these pairs in a set to get a number
        HashSet<(string, string)> hashSetForCountOfUnique = new  HashSet<(string, string)>();
        for(int i = 0; i < emails.Length; i++){
            string[] emailParts = emails[i].Split('@'); // this is not very defensive
            string[] beforeAfterPlusLocal = emailParts[0].Split('+');
            
            // string finalLocal = "";
            // for(int j = 0; j < beforeAfterPlusLocal[0].Length; j++){
            //     if(beforeAfterPlusLocal[0][j] != '.'){
            //         finalLocal += beforeAfterPlusLocal[0][j];
            //     }
            // }
            // Console.WriteLine(finalLocal + '@' + emailParts[1]);
            hashSetForCountOfUnique.Add((beforeAfterPlusLocal[0].Replace(".",""), emailParts[1]));
        }
        return hashSetForCountOfUnique.Count;
    }
}
