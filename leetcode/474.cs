public class Solution {
//     I think this fits well for dp I don't know if it fits better for greedy or math
//     start with a processing step since our fundemental problem is diffrent then our dp map
    // does our dp map want to be 3d, 1s,0s, pos?
    
//     Runtime: 414 ms, faster than 18.18% of C# online submissions for Ones and Zeroes.
// Memory Usage: 72.8 MB, less than 24.24% of C# online submissions for Ones and Zeroes.
//     I think my big issue is in not understanding bottom up vs top down dp well enough
    public int m;
    public int n;
    public string[] s;
    public int[][] simpleForm; 
    public int[][][] memo;
    public int FindMaxForm(string[] strs, int m, int n) {
        this.m = m;
        this.n = n;
        this.s = strs;
        this.memo = new int[strs.Length][][];
        this.simpleForm = new int[strs.Length][];
        for(int i = 0; i<strs.Length;i++){
            memo[i] = new int[m+1][];
            this.simpleForm[i] = new int[2];
            for(int j = 0; j < s[i].Length; j++){
                if(s[i][j] == '0'){
                    this.simpleForm[i][0]++;                    
                } else{
                    this.simpleForm[i][1]++; 
                }
            }
            for(int j = 0; j<m+1; j++){
                memo[i][j] = new int[n+1];
            }
        }
        return this.FindMaxFormRecur(0,0,0);
    }
    public int FindMaxFormRecur(int ones, int zeros, int pos) {
        // Console.WriteLine(pos);
        if(pos >= this.simpleForm.Length){
            return 0;
        }
        if(this.memo[pos][zeros][ones] > 0){
            return this.memo[pos][zeros][ones]; 
        }
        if(ones + this.simpleForm[pos][1] > this.n || zeros + this.simpleForm[pos][0] > this.m){
            this.memo[pos][zeros][ones] = this.FindMaxFormRecur(ones, zeros, pos+1);
            return this.memo[pos][zeros][ones];
        }
        else{
             this.memo[pos][zeros][ones] = Math.Max(1+ this.FindMaxFormRecur(ones + this.simpleForm[pos][1], zeros + this.simpleForm[pos][0], pos+1), this.FindMaxFormRecur(ones, zeros, pos+1));
            return this.memo[pos][zeros][ones];
        }
        
    }
}
