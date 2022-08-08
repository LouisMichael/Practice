public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        return this.GenerateParenthesisRecur(n, "", 0);
    }
    public IList<string> GenerateParenthesisRecur(int n, string cur, int open){
        
        if(cur.Length >= n*2){
            List<string> ret = new List<string>();
            ret.Add(cur);
            return ret;
        }
        else{
            if(open >= (n *2) - cur.Length){
                return this.GenerateParenthesisRecur(n, cur + ")", open -1); 
            }
            if(open == 0){
                return this.GenerateParenthesisRecur(n, cur + "(", open + 1);
            }
            IList<string> openAddList = this.GenerateParenthesisRecur(n, cur + ")", open -1); 
            IList<string> closeAddList = this.GenerateParenthesisRecur(n, cur + "(", open + 1);
            for(int i = 0; i<openAddList.Count; i++){
                closeAddList.Add(openAddList[i]);
            }
            return closeAddList;
        }
    }
}
