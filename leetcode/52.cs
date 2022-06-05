public class Solution {
//     I suspect there is a mathy way to solve this but IDK, given that n has a max on 9 maybe it is just a modified version of the backtracking problem
//     I will start with a version of backtracking and see if a pattern shows up
//     geeks for geeks about the basic problem points out that you can get a optomized version of fit for diaganals with some math. 
    // Runtime: 53 ms, faster than 18.18% of C# online submissions for N-Queens II.
// Memory Usage: 25.2 MB, less than 89.26% of C# online submissions for N-Queens II.
    public int TotalNQueens(int n) {
        bool[] colUsed = new bool[n];
        bool[] rowUsed = new bool[n];
        bool[] interseptAdd = new bool[(n*2)-1];
        bool[] interseptSubtract = new bool[(n*2)-1];
        return(this.TotalNQueensRecur(0, colUsed, rowUsed, interseptAdd, interseptSubtract, n));
    }
    
    public int TotalNQueensRecur(int x, bool[] colUsed, bool[] rowUsed, bool[] interseptAdd, bool[] interseptSubtract, int n) {
        if(x>=n){
            return 1;
        }
        int ret = 0;
        for(int y = 0; y<n;y++){
            if(!colUsed[x] && !rowUsed[y] && !interseptAdd[x+y] && !interseptSubtract[(x-y)+n-1]){
                colUsed[x] = true;
                rowUsed[y] = true;
                interseptAdd[x+y] = true;
                interseptSubtract[(x-y)+n-1] = true;
                ret += this.TotalNQueensRecur(x+1, colUsed, rowUsed, interseptAdd, interseptSubtract, n);
                colUsed[x] = false;
                rowUsed[y] = false;
                interseptAdd[x+y] = false;
                interseptSubtract[(x-y)+n-1] = false;
            }
        }
        return ret;
    }
    
//     on a nxn board there are n col, n row, (n*2)-1 diagnals one way and (n*2)-1 diagnals the other way
    public bool isCurValid(int x, int y, bool[] colUsed, bool[] rowUsed, bool[] interseptAdd, bool[] interseptSubtract, int n){
        if(!colUsed[x] && !rowUsed[y] && !interseptAdd[x+y] && !interseptSubtract[(x-y)+n-1]){
            return true;
        }
        return false;
    }
}
