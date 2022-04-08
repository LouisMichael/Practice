public class KthLargest {
// a naive approch is to run sort after every add. Maybe you also just want to track the number of items larger then current and only sort if you susupect a change
    
    
//     make a max heap but only update it when I am adding values under the current largest k
    public int curKLargest;
    public int totalCount;
    public int k;
    public PriorityQueue<int,int>  heap;
    public KthLargest(int k, int[] nums) {
        this.totalCount = nums.Length;
        this.k = k;
        this.heap = new PriorityQueue<int,int>();
        
            Array.Sort(nums, new DescendingComparer<int>());
        for(int i =0; i< nums.Length;i++){
            this.heap.Enqueue(nums[i],nums[i]);
        }    
        while(this.heap.Count > k){
               this.heap.Dequeue();
            }
    
    }
    
    public int Add(int val) {
        this.heap.Enqueue(val,val);
        if(this.heap.Count>k){
            this.heap.Dequeue();
        }
        return this.heap.Peek();
    }
    
    class DescendingComparer<T> : IComparer<T> where T : IComparable<T> {
        public int Compare(T x, T y) {
            return y.CompareTo(x);
        }
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */
