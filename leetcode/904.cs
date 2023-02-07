public class Solution {
    public int TotalFruit(int[] fruits) {
        // we want to find the lognest section of the array that is only two numbers
        // we could do a dynamic programing approch but it does not seem right
        // I think maybe two pointer is okay?
        // you can try every spot as a start, then go as far as you can until you can't get any more and return the best?
        // we can simplfy some by tracking the next start location that could give a better answer, it will be the first place we could start and use a new set of numbers
        int max = 0;
        if(fruits.Length <= 2){
            return fruits.Length;
        }
        for(int i =0;i<fruits.Length;i++){
            int cur1 = fruits[i];
            int cur2 = -1;
            int next = fruits.Length;
            int last = i;
            for(int j = i; j<fruits.Length;j++){
                if(fruits[j]==cur1){
                     last = j;
                    continue;
                }
                if(cur2 == -1){
                    cur2 = fruits[j];
                }
                if(cur2 == fruits[j]){
                    last = j;
                    continue;
                }
                int k = j-1;
                int cur3 = fruits[k];
                while(fruits[k] == cur3){
                    k--;
                }
                next = k;
                // Console.WriteLine("next: " +next);
                break;
            }
            // Console.WriteLine("i: " + i);
            // Console.WriteLine("last: " +last);
            max = Math.Max(max, last-i+1);
            i = next;
        }
        return max;
        // it is better thought of as a sliding window problem
    }
}
