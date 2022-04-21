// Runtime: 392 ms, faster than 30.65% of C# online submissions for Design HashSet.
// Memory Usage: 63.5 MB, less than 29.89% of C# online submissions for Design HashSet.
// IDK why my version of this is slow, other subissions are exactly the same, some do more work with binning as you would expect of a better solution
public class MyHashSet {
    private bool[] store;
    public MyHashSet() {
        this.store = new bool[1000001];
    }
    
    public void Add(int key) {
        this.store[key] = true;
    }
    
    public void Remove(int key) {
        this.store[key] = false;
    }
    
    public bool Contains(int key) {
        return this.store[key];
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */
