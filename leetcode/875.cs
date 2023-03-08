public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        // we can binary search for the goal speed?
        int min = 1;
        int max = 1;
        for(int i = 0; i<piles.Length;i++){
            max = Math.Max(max, piles[i]);
        } 
        while(min < max){
            int mid = (min+max)/2;
            if(this.checkSpeed(piles, h, mid)){
                max = mid;
            }
            else{
                min = mid +1;
            }
        }
        return min;
    }
    public bool checkSpeed(int[] piles, int h, int speed){
        int hours = 0;
        for(int i = 0; i<piles.Length;i++){
            hours += piles[i]/speed;
            if(piles[i]%speed != 0){
                hours++;
            } 
        }
        return hours <= h;
    }
}
