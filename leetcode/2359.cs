public class Solution {
    public int ClosestMeetingNode(int[] edges, int node1, int node2) {
        // I think we can run meet in the middle for this pretty well, you do one step of Dykstra on each side until you hit a node you have both seen
        // We could have cycles so we want to keep a visted graph for both sides so we don't just run infinatly
        int leftCur = node1;
        int rightCur = node2;
        HashSet<int> leftVisted = new HashSet<int>();
        HashSet<int> rightVisted = new HashSet<int>();
        while(leftCur != -1 || rightCur != -1){
            int leftSolve = -1;
            int rightSolve = -1;
            if(leftVisted.Contains(leftCur)){
                leftCur = -1;
            }
            if(leftCur != -1 ){
                if(rightVisted.Contains(leftCur)){
                    leftSolve = leftCur;
                }
                leftVisted.Add(leftCur);
                leftCur = edges[leftCur];
            }
            if(rightVisted.Contains(rightCur)){
                rightCur = -1;
            }
            if(rightCur != -1){
                if(leftVisted.Contains(rightCur)){
                    rightSolve = rightCur;
                }
                rightVisted.Add(rightCur);
                rightCur = edges[rightCur];
            }
            if(leftSolve > -1 && rightSolve > -1){
                return Math.Min(leftSolve,rightSolve);
            }
            if(leftSolve > -1 || rightSolve > -1){
                return Math.Max(leftSolve,rightSolve);
            }
        }
        return -1;
    }
}
