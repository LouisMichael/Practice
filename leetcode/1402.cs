public class Solution {
    public int MaxSatisfaction(int[] satisfaction) {
        // I think if we sort them we can then decide if we remove any 
        // We fundamentlay just want to pick the number of negative value dishes we are going to serve
        // We always serve 0 and higher
        // we want to add negative value dishes as long as they are increasing the total
        // score with the greatest value ones being added first
        // we will keep adding until adding the next will decrease the score
        // how do we do this quickly?
        // adding the next item will increase the score by the current positve sum, add itself to the negative sum and then decrease the score by to the current negative sum
        // we add dishes as long as the increase is larger then the decrease
        Array.Sort(satisfaction);
        int posSum = 0;
        int negSum = 0;
        int score = 0;
        for(int i = satisfaction.Length-1; i>= 0; i--){
            // Console.WriteLine(satisfaction[i]);
            if(satisfaction[i] >= 0){
                posSum += satisfaction[i];
                score += posSum;
            }
            else {
                negSum += satisfaction[i];
                if(posSum + negSum > 0){
                    score += (posSum+negSum);
                }
                else{
                    break;
                }
            }
            // Console.WriteLine(score);
        } 
        return score;
    }
}
