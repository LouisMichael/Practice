class Solution {
    // I think we can write in java because we can use some nice Tree Map built in functions
    // we can set up offsets at diffrent spacing based on our odds then we can run a search for the lower index of the value
    // we roll on a d(sum(w)) and this can give back our value, this has the same effect as adding copies to a bag but with
    // fewer operations because we leverage the map to large ranges we then search over, we could also do this with binary search of the map?
    private TreeMap<Integer,Integer> treeMap ;
    private int wSum;
    public Solution(int[] w) {
        this.treeMap = new TreeMap<Integer,Integer>();
        this.wSum = 0;
        for(int i = 0; i<w.length;i++){
            this.treeMap.put(this.wSum, i);
            wSum += w[i];
        }
    }
    
    public int pickIndex() {
        Random rand = new Random(); 
        int next = rand.nextInt(wSum);
        return this.treeMap.get(this.treeMap.floorKey(next));
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(w);
 * int param_1 = obj.pickIndex();
 */
