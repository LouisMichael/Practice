public class Solution {
//     first read 12:11
//     inital idea is that we would want to sort the list of people O(nlogn)
//     then we work from the heaviest person and the litest person to see if they pair
//     Runtime: 191 ms, faster than 71.43% of C# online submissions for Boats to Save People.
// Memory Usage: 45.8 MB, less than 40.48% of C# online submissions for Boats to Save People.
//     12:26 finished updated version
    public int NumRescueBoats(int[] people, int limit) {
        Array.Sort(people);
        int leftPointer = 0;
        int rightPointer = people.Length-1;
        int totalUsed = 0;
        while(leftPointer <= rightPointer){
            if(people[rightPointer] > limit){
                Console.WriteLine("one person is too big to fit: error");
                return -1;
            }
//             check on tie for limit
            if(people[rightPointer] + people[leftPointer] <= limit){
                leftPointer++;
                // Console.WriteLine("got a double");
            }
            totalUsed ++;
            rightPointer --;
        }
        return totalUsed;
    }
}
