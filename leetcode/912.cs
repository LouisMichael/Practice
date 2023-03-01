public class Solution {
    // I think I know how to write merge sort?
    // I guess I should learn better how to run quck and insertion

    // I should maybe still learn quick sort since it is a good one but I did counting sort since the values were bounded, it made sense and it was discussed in the editorial
    public int[] SortArray(int[] nums) {
        int min = nums[0];
        int max = nums[0];
        Dictionary<int,int> hashMap = new Dictionary<int,int>();
        for(int i =0; i<nums.Length;i++){
            if(nums[i]>max){
                max = nums[i];
            }
            if(nums[i]<min){
                min = nums[i];
            }
            if(hashMap.ContainsKey(nums[i])){
                hashMap[nums[i]]++;
            }
            else{
                hashMap[nums[i]] = 1;
            }
        }
        int pos = 0;
        for(int val = min; val <= max; val++){
            if(hashMap.ContainsKey(val)){
                for(int i = 0; i<hashMap[val];i++){
                    nums[pos] = val;
                    pos++;
                }
            }
        }
        return nums;
    }
    
}
