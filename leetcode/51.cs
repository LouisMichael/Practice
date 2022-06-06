// Runtime: 239 ms, faster than 23.51% of C# online submissions for N-Queens.
// Memory Usage: 46.4 MB, less than 66.03% of C# online submissions for N-Queens.

public class Solution {
//     I did n-queens II recently so I am reusing that backtracking approch and just moving around the output approch
    public IList<IList<string>> solve;
    public IList<IList<string>> SolveNQueens(int n) {
        bool[] colUsed = new bool[n];
        bool[] rowUsed = new bool[n];
        bool[] interseptAdd = new bool[(n*2)-1];
        bool[] interseptSubtract = new bool[(n*2)-1];
        this.solve = new List<IList<string>>();
        bool[][] used = new bool[n][];
        for(int i = 0; i < n; i++){
            used[i] = new bool[n];
        }
        this.TotalNQueensRecur(0, colUsed, rowUsed, interseptAdd, interseptSubtract, n, used);
        return solve;
        
    }
    
//     I am not relizing we can't give an answer we need to give all answer, hence the list of list of strings, the top level list is multiple solutions
    public IList<string> boardToString(bool[][] used){
        IList<string> ret = new List<string>();
        for(int i = 0; i < used.Length; i++){
            char[] newCharArray = new char[used.Length];
            for(int j = 0; j<used[i].Length; j++){
                if(used[i][j]){
                    newCharArray[j] = 'Q';
                }
                else{
                    newCharArray[j] = '.';
                }
            }
            ret.Add(new string(newCharArray));
        }
        return ret;
    }
//     when do we merge the lists? we know we have a new solve at the end but we may get more then one solve out of once placement. 
    public void TotalNQueensRecur(int x, bool[] colUsed, bool[] rowUsed, bool[] interseptAdd, bool[] interseptSubtract, int n, bool[][] used) {
        if(x>=n){
            this.solve.Add(this.boardToString(used));
            return;
        }
        for(int y = 0; y<n;y++){
            if(!colUsed[x] && !rowUsed[y] && !interseptAdd[x+y] && !interseptSubtract[(x-y)+n-1]){
                colUsed[x] = true;
                rowUsed[y] = true;
                interseptAdd[x+y] = true;
                interseptSubtract[(x-y)+n-1] = true;
                used[x][y] = true;
                this.TotalNQueensRecur(x+1, colUsed, rowUsed, interseptAdd, interseptSubtract, n, used);
                used[x][y] = false;
                colUsed[x] = false;
                rowUsed[y] = false;
                interseptAdd[x+y] = false;
                interseptSubtract[(x-y)+n-1] = false;
            }
        }
    }
    
    
}
