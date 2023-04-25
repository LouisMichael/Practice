public class SmallestInfiniteSet {
    int min;
    PriorityQueue<int,int> gaps;
    HashSet<int> set;
    public SmallestInfiniteSet() {
        this.min = 1;
        this.gaps =  new PriorityQueue<int,int>();
        this.set = new HashSet<int>();
    }
    
    public int PopSmallest() {
        if(this.gaps.Count == 0){
            int curMin = this.min;
            this.min++;
            return curMin;
        }
        else{
            int smallest = this.gaps.Dequeue();
            this.set.Remove(smallest);
            return smallest;
        }
    }
    
    public void AddBack(int num) {
        if(num >= min){
            return;
        }
        if(this.set.Contains(num)){
            return;
        }
        this.set.Add(num);
        this.gaps.Enqueue(num,num);
    }
}

/**
 * Your SmallestInfiniteSet object will be instantiated and called as such:
 * SmallestInfiniteSet obj = new SmallestInfiniteSet();
 * int param_1 = obj.PopSmallest();
 * obj.AddBack(num);
 */
