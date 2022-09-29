public class Solution {
    public IList<int> FindClosestElements(int[] arr, int k, int x) {
//         binary search for the location of the value x, -or use the built in- I think the built in only works if the value is in the list, I don't think it will give a closest index
//         then use two pointers one to the right one to the left and a deque to push values from the left pointer
//         and queue values from the right pointer
        int xLocation = this.BinarySearchClosest(arr, x);
        // Console.WriteLine(xLocation);
        int left = xLocation-1;
        int right = xLocation;
        List<int> retList = new List<int>();
        for(int i = 0; i<k;i++){
            if(left >= 0 && right < arr.Length){
                if(x-arr[left] <= arr[right]-x){
                    retList.Insert(0,arr[left]);
                    left--;
                } else{
                    retList.Insert(retList.Count,arr[right]);
                    right++;
                }
            }
            else if(left >= 0){
                retList.Insert(0,arr[left]);
                left--;
            }
            else if(right < arr.Length){
                retList.Insert(retList.Count,arr[right]);
                right++;
            } else{
                break;
            }
        }
        return retList;
    }
    
    public int BinarySearchClosest(int[] arr, int x){
        int left = 0;
        int right = arr.Length - 1;
        while(left < right){
            int mid = (left + right)/2;
            if(arr[mid]<x){
                left = mid+1;
            }
            else{
                right = mid;
            }
        }
        return left;
    }
    
}
