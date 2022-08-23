// this had a clever other solve where you can use a striated mask like 101010101010 in combonation with the trick where anding with 10000000 -1 and itself will be 0 
public class Solution {
    public bool IsPowerOfFour(int n) {
        int mask = 1;
        if(n <= 0){
            return false;
        }
        for(int i = 0; i<32;i++){
            if((mask & n )== n){
                return i%2==0;
            }
            mask = mask << 1; 
        }
        return false;
    }
}
