public class Solution {
    public bool CanMakeArithmeticProgression(int[] arr) {
        // we can sort it and then check the diffs, this nlogn I wonder if there is a linear solve. 
        // I thought about tracking more than one diff or the two lowest elments and I think I just got to sorting
        Array.Sort(arr);
        int diff = arr[1]-arr[0];
        for(int i = 2; i<arr.Length; i++){
            Console.WriteLine(arr[i]);
            if(arr[i]-arr[i-1] != diff){
                return false;
            }
        }
        return true;
    }
    // there is a cool trick that builds on the idea that we can find the setep size as a function of the min and max divided by the lenght of the arr
}
