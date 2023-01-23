public class Solution {
    public string MostCommonWord(string paragraph, string[] banned) {
        paragraph = paragraph.Replace('!', ' ');
        paragraph = paragraph.Replace('?', ' ');
        paragraph = paragraph.Replace('\'', ' ');
        paragraph = paragraph.Replace(',', ' ');
        paragraph = paragraph.Replace(';', ' ');
        paragraph = paragraph.Replace('.', ' ');
        paragraph = paragraph.ToLower();
        string[] words = paragraph.Split(' ');
        HashSet<string> bannedWordsSet = new HashSet<string>();
        foreach(string word in banned){
            bannedWordsSet.Add(word);
        }
        string ret = "";
        int maxCount = 0;
        Dictionary<string, int> wordCount = new Dictionary<string, int>();
        for(int i = 0; i<words.Length;i++){
            // Console.WriteLine(words[i]);
            if(bannedWordsSet.Contains(words[i]) || words[i] == ""){
                continue;
            }
            if(!wordCount.ContainsKey(words[i])){
                wordCount[words[i]] = 0;
            }
            wordCount[words[i]]++;
            if(wordCount[words[i]] > maxCount){
                ret = words[i];
                maxCount = wordCount[words[i]];
            }
        }
        return ret;
    }
}
