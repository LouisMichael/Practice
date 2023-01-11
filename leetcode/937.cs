public class Solution {
    public string[] ReorderLogFiles(string[] logs) {
        List<string> digetLogs =  new List<string>();
        List<LetterLog> letterLogs = new List<LetterLog>();
        foreach(string s in logs){
            string[] parts = s.Split(' ');
            if(parts[1][0] - 'a' < 0){
                digetLogs.Add(s);
            }
            else{
                LetterLog newLetterLog = new LetterLog();
                newLetterLog.identifier = parts[0];
                newLetterLog.contents = s.Substring(parts[0].Length);
                letterLogs.Add(newLetterLog);
            }
        }
        string[] ret = new string[logs.Length];
        letterLogs.Sort((a,b)=>a.contents.Equals(b.contents)? a.identifier.CompareTo(b.identifier): a.contents.CompareTo(b.contents));
        for(int i = 0; i<letterLogs.Count;i++){
            ret[i] = letterLogs[i].identifier + letterLogs[i].contents;
        }
        for(int j = 0; j<digetLogs.Count;j++){
            ret[letterLogs.Count+j] = digetLogs[j];
        }
        return ret;
    }
    public class LetterLog{
        public string identifier;
        public string contents;
    }
}
