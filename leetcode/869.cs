public class Solution {
//     we want to get to a spot where we can run a simiple check of the diget count 
//     what is our key going to be? We can do a simple array as our dictionary where the array is 0-9 and then counts
//     some other intersteting ideas would be to use the total length of the number and then use that to narrow down the total valid sets
    public bool ReorderedPowerOf2(int n) {
        int cur = 1;
        HashSet<string> hashSet = new HashSet<string>();
        for(int i = 0; i < 31; i++){
            int temp = cur;
            int[] digitCount1 = new int[10];
            while(temp > 0){
                digitCount1[temp % 10]++;
                temp /= 10;
            }
            string key = "";
            for(int j = 0; j<10;j++){
                key = key + digitCount1[j] + ',';
            }
            // Console.WriteLine(key);
            hashSet.Add(key);
            cur = cur << 1;
        }
        int temp2 = n;
        int[] digitCount = new int[10];
        while(temp2 > 0){
            digitCount[temp2 % 10]++;
            temp2 /= 10;
        }
        string key1 = "";
        for(int j = 0; j<10;j++){
            key1 = key1 + digitCount[j] + ',';
        }
        // Console.WriteLine(key1);
        return hashSet.Contains(key1);
    }
}
