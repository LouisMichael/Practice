public class Solution {
    public int NumSimilarGroups(string[] strs) {
        // union find is a good data structure for problems of adding to groups
        // since they are all anagrams we just need to check that they are wrong by exactly two letters
        // I think we end up needing to do a n^2 step to build connections
        UnionFind<string> unionFind = new UnionFind<string>();
        for(int i = 0; i<strs.Length;i++){
            unionFind.Add(strs[i]);
        }
        for(int i = 0; i<strs.Length;i++){
            for(int j = 0; j<strs.Length;j++){
                int diff = 0;
                for(int k = 0; k<strs[i].Length;k++){
                    if(diff > 2){
                        break;
                    }
                    if(strs[i][k] != strs[j][k]){
                        diff++;
                    }
                }
                if(diff == 2){
                    unionFind.Union(strs[i], strs[j]);
                }
            }
        }
        return unionFind.groupCount;
    }

    public class UnionFind<T>{
        public Dictionary<T, UnionFindNode<T>> dict;
        public int groupCount;
        public UnionFind(){
            this.dict = new  Dictionary<T, UnionFindNode<T>>();
            this.groupCount = 0;
        }
        public void Add(T value){
            if(this.dict.ContainsKey(value)){
                return;
            }
            UnionFindNode<T> node = new UnionFindNode<T>(value);
            this.dict[value] = node;
            this.groupCount++;
        }
        public void Union(T value, T value2){
            UnionFindNode<T> node1 = this.dict[value];
            while(node1.parent != node1){
                node1 = node1.parent;
            }
            UnionFindNode<T> node2 = this.dict[value2];
            while(node2.parent != node2){
                node2 = node2.parent;
            }
            if(node1 == node2){
                return;
            }
            if(node2.depth > node1.depth){
                UnionFindNode<T> temp = node1;
                node1 = node2;
                node2 = temp;
            }
            node2.parent = node1;
            node1.depth++;
            this.groupCount--;
        }
        public class UnionFindNode<T>{
            public T value;
            public int depth;
            public UnionFindNode<T> parent;
            public UnionFindNode(T value)
            {
                this.parent = this;
                this.value = value;
                this.depth = 0;
            }
        }
    }
}
