public class Solution {
    public int MinDominoRotations(int[] tops, int[] bottoms) {
        int countGoal1Top = 0;
        int countGoal1Bottom = 0;

        int goal1 = tops[0];
        int countGoal2Top = 0;
        int countGoal2Bottom = 0;
        int goal2 = bottoms[0];
        for(int i = 0; i<tops.Length;i++){
            if(goal1 > 0){
                if(goal1 == tops[i] && goal1 != bottoms[i]){
                   countGoal1Bottom ++; 
                }
                if(goal1 == bottoms[i] && goal1 != tops[i]){
                    countGoal1Top ++;
                }
                if(goal1 != bottoms[i] && goal1 != tops[i]){
                    goal1 = 0;
                }
            }
            if(goal2 > 0){
                if(goal2 == tops[i] && goal2 != bottoms[i]){
                   countGoal2Bottom ++; 
                }
                if(goal2 == bottoms[i] && goal2 != tops[i]){
                    countGoal2Top ++;
                }
                if(goal2 != bottoms[i] && goal2 != tops[i]){
                    goal2 = 0;
                }
            }
        }
        int goal1Min = -1;
        if(goal1 > 0){
            goal1Min = Math.Min(countGoal1Bottom, countGoal1Top);
        }
        int goal2Min = -1;
        if(goal2 > 0){
            // Console.WriteLine(countGoal2Bottom);
            // Console.WriteLine(countGoal2Top);
            goal2Min = Math.Min(countGoal2Bottom, countGoal2Top);
        }
        if(goal1 > 0 && goal2 > 0){
            return Math.Min(goal1Min, goal2Min);
        }
        if(goal1 > 0){
            return goal1Min;
        }
        else if(goal2 > 0){
            return goal2Min;
        }
        else{
            return -1;
        }
    }
}
