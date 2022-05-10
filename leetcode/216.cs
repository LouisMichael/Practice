public class Solution {
    public IList<IList<int>> CombinationSum3(int k, int n) {
        return CombinationSum3Recur(k, n , 1);
        
    }
    public IList<IList<int>> CombinationSum3Recur(int k, int n, int pos) {
        List<IList<int>> ret = new List<IList<int>>();

        if(k == 1){
            if(n >= pos && n <= 9)
            {
                List<int> temp2 = new List<int>();
                temp2.Add(n);
                ret.Add(temp2);
                return ret;
            }
        }
        if(k <= 0 || n <= 0 || pos > 9){
            return null;
        }
        for(int i = pos; i<10;i++){
            IList<IList<int>> temp = CombinationSum3Recur(k-1,n-i,i+1);
            if(temp != null){
                foreach(IList<int> list in temp){
                    list.Add(i);
                    ret.Add(list);
                }
            }
        }
        return ret;
    }
}
