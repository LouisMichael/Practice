public class Solution {
//     this problem is mostly straight forward to understand but will be heavy on implmentation
//     the central tracking will just be a data structure of a dictionary where the key is the contents
//     and the value is a list of all the paths that have that value, then we will loop over this strucrture at the end and for any key
//     with more then one value we put it in the output
    public IList<IList<string>> FindDuplicate(string[] paths) {
        Dictionary<string, IList<string>> fileNameToContentsDictionary = new Dictionary<string, IList<string>>();
        foreach(string path in paths){
//             it is not super clear if you can have ' ' as part of a path or just as the seperator, it will be the seperateor
//             it is also not crazy clear if you can have ' ' in a file name
            
            string[] splitString = path.Split(' ');
            if(splitString.Length < 2){
                continue;
            }
            for(int i = 1; i<splitString.Length; i++){
                string[] fileNameAndContentsSlipt = splitString[i].Split('(');
                if(!fileNameToContentsDictionary.ContainsKey(fileNameAndContentsSlipt[1])){
                    fileNameToContentsDictionary[fileNameAndContentsSlipt[1]] = new List<string>();
                }
                fileNameToContentsDictionary[fileNameAndContentsSlipt[1]].Add(splitString[0] + '/' + fileNameAndContentsSlipt[0]);
            }
        }
        List<IList<string>> ret = new List<IList<string>>();
        foreach(string key in fileNameToContentsDictionary.Keys){
            if(fileNameToContentsDictionary[key].Count > 1){
                ret.Add(fileNameToContentsDictionary[key]);
            }
        }
        return ret;
    }
}
