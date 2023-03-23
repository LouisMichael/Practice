public class Solution {
    public int MakeConnected(int n, int[][] connections) {
        // I think we can modify union find a little to get us some of the values we care about
        // if you add a connection to a set that is already connected that represnts a wire we can move
        // then we need to use all our extra wires to connect to our total number of distinct sections
        UnionFind unionFind = new UnionFind(n);
        for(int i = 0; i<connections.Length; i++){
            unionFind.union_set(connections[i][0], connections[i][1]);
        }
        if(unionFind.extraWire < unionFind.totalSections - 1){
            return -1;
        }
        return unionFind.totalSections - 1;
    }

    class UnionFind {
        int[] parent;
        int[] rank;
        public int extraWire;
        public int totalSections;
        public UnionFind(int size) {
            parent = new int[size];
            for (int i = 0; i < size; i++)
                parent[i] = i;
            rank = new int[size];
            extraWire = 0;
            totalSections = size;
        }

        public int find(int x) {
            if (parent[x] != x)
                parent[x] = find(parent[x]);
            return parent[x];
        }

        public void union_set(int x, int y) {
            int xset = find(x), yset = find(y);
            if (xset == yset) {
                extraWire++;
                return;
            } else if (rank[xset] < rank[yset]) {
                parent[xset] = yset;
            } else if (rank[xset] > rank[yset]) {
                parent[yset] = xset;
            } else {
                parent[yset] = xset;
                rank[xset]++;
            }
            totalSections--;
        }
    }
}
