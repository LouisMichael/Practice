// 1342
// Runtime: 0 ms, faster than 100.00% of Java online submissions for Number of Steps to Reduce a Number to Zero.
// Memory Usage: 41 MB, less than 42.25% of Java online submissions for Number of Steps to Reduce a Number to Zero.
class Solution {
    public int numberOfSteps(int num) {
        int count = 0;
        while(num != 0){
            if(num % 2 == 0){
            num = num/2;
            }
            else{
                num = num-1;
            }
            count ++;
        }
        return count;
    }
}
