public class Solution {
    public IList<IList<int>> PacificAtlantic(int[][] heights) {
//         so the way this is layed out I think we can work our way through all the cells and connect them one by one directionaly
//         then on the edges we can color in the connections that flow into that cell
//         we want to return the cells that got both colors
//         I think maybe if we start on the edges and run the problem backwards we will not have to keep track of as many connectinos or do a coloring step, 
//         intested any time we make a connection it will be as connected as posible at that time 
//         nvm I don't think that is true, since you can get long vallies that give answers from across the board. 
//         maybe we can do some memoizing, at each edge we walk all of the connections from the edge, if we hit a square that already had the ocen flow type we can 
//         stop since it will not add anything more
        List<IList<int>> ret = new List<IList<int>>();
        bool[][] atlantic = new bool[heights.Length][];
        bool[][] pacific = new bool[heights.Length][];
        for(int i = 0; i<heights.Length;i++){
            atlantic[i] = new bool[heights[i].Length];
            pacific[i] = new bool[heights[i].Length];
        }
//         run the north edge
        for(int i = 0; i<heights[0].Length;i++){
            this.PacificAtlanticRecur(heights, 0, i, atlantic, pacific, true, ret);
        }
//         run the west edge
        for(int i = 0; i<heights.Length;i++){
            this.PacificAtlanticRecur(heights, i, 0, atlantic, pacific, true, ret);
        }
//         run the east edge
        for(int i = 0; i<heights.Length;i++){
            this.PacificAtlanticRecur(heights, i, heights[i].Length-1, atlantic, pacific, false, ret);
        }
//         run the south edge
        for(int i = 0; i<heights[heights.Length-1].Length;i++){
            this.PacificAtlanticRecur(heights, heights.Length-1, i, atlantic, pacific, false, ret);
        }
         return ret;
    }
    public void PacificAtlanticRecur(int[][] heights, int x, int y, bool[][] atlantic, bool[][] pacific, bool pacificFlow, IList<IList<int>> ret){
        if(pacificFlow){
            if(pacific[x][y]){
//                 we do not want to repeat any work
                return;
            }
            pacific[x][y] = true;
        }
        else{
            if(atlantic[x][y]){
                return;
            }
            atlantic[x][y] = true;
        }
        if(pacific[x][y] && atlantic[x][y]){
            List<int> newPair = new List<int>();
            newPair.Add(x);
            newPair.Add(y);
            ret.Add(newPair);
        }
//         look north
        if(y-1 >= 0 && heights[x][y] <= heights[x][y-1]){
            this.PacificAtlanticRecur(heights, x, y - 1, atlantic, pacific, pacificFlow, ret);
        }
//         look south
        if(y+1 < heights[x].Length && heights[x][y] <= heights[x][y+1]){
            this.PacificAtlanticRecur(heights, x, y + 1, atlantic, pacific, pacificFlow, ret);
        }
//         look east
        if(x+1 < heights.Length && heights[x][y] <= heights[x+1][y]){
            this.PacificAtlanticRecur(heights, x+1, y , atlantic, pacific, pacificFlow, ret);
        }
//         look west
        if(x-1 >= 0 && heights[x][y] <= heights[x-1][y]){
            this.PacificAtlanticRecur(heights, x-1, y, atlantic, pacific, pacificFlow, ret);
        }
    }
}
