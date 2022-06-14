// I think this will be n^2 dp 
// I think a good approch will be to consider deleting any one of the total set of available characters, and then 
// there may be a more linear time approch to try to find largest matching subsequence
// maybe something like a backtracking approch would make more sense?
// at each letter you could either deleter or not delete, if you don't delete you have to add the number of deletes needed to get to a matching position in the other word
public class Solution {
    public int[][] mem;
    public int MinDistance(string word1, string word2) {
        this.mem = new int[word1.Length][];
        for(int i = 0; i<word1.Length;i++){
            this.mem[i] = new int[word2.Length];
        }
        return this.MinDistanceRecur(word1,0,word2,0);
        
    }
    public int MinDistanceRecur(string word1, int word1Pos, string word2, int word2Pos) {
        if(word1Pos >= word1.Length && word2Pos >= word2.Length){
            return 0;
        }
        if(word1Pos >= word1.Length){
            return word2.Length - word2Pos; 
        }
        if(word2Pos >= word2.Length){
            return word1.Length - word1Pos; 
        }
        if(this.mem[word1Pos][word2Pos] > 0){
            return this.mem[word1Pos][word2Pos];
        }
        int temp = Int32.MaxValue;
        if(word1[word1Pos] == word2[word2Pos]){
            temp = this.MinDistanceRecur(word1, word1Pos+1, word2, word2Pos+1);
        }
        int deleteWord1 = this.MinDistanceRecur(word1, word1Pos+1, word2, word2Pos)+1;
        temp = Math.Min(temp, deleteWord1);
        int deleteWord2 = this.MinDistanceRecur(word1, word1Pos, word2, word2Pos+1)+1;
        temp = Math.Min(temp, deleteWord2);
        this.mem[word1Pos][word2Pos] = temp;
        return temp;
        
    }
    
//     This version will TLE
    // public int MinDistanceRecur(string word1, string word2) {
    //     if(word1.Equals(word2)){
    //         return 0;
    //     }
    //     string key = word1 + "," + word2;
    //     // Console.WriteLine(key);
    //     if(this.mem.ContainsKey(key)){
    //         return this.mem[key];
    //     }
    //     int min = Int32.MaxValue;
    //     for(int i = 0; i<word1.Length;i++){
    //         int temp = this.MinDistanceRecur(word1.Remove(i,1), word2) +1;
    //         if(temp < min){
    //             min = temp;
    //         }
    //     }
    //     for(int i = 0; i<word2.Length;i++){
    //         int temp = this.MinDistanceRecur(word1, word2.Remove(i,1))+1;
    //         if(temp < min){
    //             min = temp;
    //         }
    //     }
    //     this.mem[key] = min;
    //     return min;
    // }
}
