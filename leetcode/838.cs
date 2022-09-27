public class Solution {
//     I think the best way to do this is to just play the game?
//     no because it would be exponental since we would look at the whole board 
//     at each second for up to n seconds
//     instead we can do a pass from the left to the right, and say how far away any one domino was from falling right, 
//     then the same backwards for left and the disctance between a left and a right will give us our answers
    public string PushDominoes(string dominoes) {
        int fromRight = -1;
        int[] fromRightArray = new int[dominoes.Length];
        char[] ret = new char[dominoes.Length];
        for(int i = 0; i<dominoes.Length;i++){
            if(dominoes[i] == 'R'){
                fromRight = 1;
            } else if(dominoes[i] == 'L'){
                fromRight = -1;
            } else{
                if(fromRight > 0){
                    fromRight++;
                }
            }
            fromRightArray[i] = fromRight;
        }
        int fromLeft = -1;
        for(int i = dominoes.Length-1; i>=0;i--){
            if(dominoes[i] == 'L'){
                fromLeft = 1;
            } else if(dominoes[i] == 'R'){
                fromLeft = -1;
            } else{
                if(fromLeft > 0){
                    fromLeft++;
                }
            }
            if(fromLeft > 0 && (fromLeft < fromRightArray[i] || fromRightArray[i] < 0)){
                ret[i] = 'L';
            } else if(fromRightArray[i] > 0 && (fromRightArray[i] < fromLeft || fromLeft < 0)){
                ret[i] = 'R';
            } else{
                ret[i] = '.';
            }
        }
        return new string(ret);
    }
}
