public class Solution {
    public int BagOfTokensScore(int[] tokens, int power) {
//         I think there is a good fast greedy way to play this game
//         sort the list, if you can score a disk from the low end do so
//         if you can not but you could score the next disk by trading in a top end disk do so,
//         repeat
        Array.Sort(tokens);
        int low = 0;
        int high = tokens.Length-1;
        int ret =0;
        while(low <= high && power >=0){
            if(tokens[low] <= power){
                power -= tokens[low];
                ret++;
                low++;
            }
            else{
                if(high!= low && ret > 0 && tokens[high] + power >= tokens[low]){
                    power+= tokens[high];
                    ret--;
                    high--;
                }
                else{
                    break;
                }
            }
        }
        return ret;
    }
}
