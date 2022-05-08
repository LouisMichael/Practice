/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public class NestedIterator {
    private Queue<int> queue;
    private int cur;
    private IList<NestedInteger> nestedList;
    public NestedIterator(IList<NestedInteger> nestedList) {
        this.queue = new Queue<int>();
        for(int i = 0; i<nestedList.Count;i++){
            if(nestedList[i].IsInteger()){
                this.queue.Enqueue(nestedList[i].GetInteger());
            }
            else{
                NestedIterator temp = new NestedIterator(nestedList[i].GetList());
                while(temp.HasNext()){
                    this.queue.Enqueue(temp.Next());
                }
            }
        }
        
    }

    public bool HasNext() {
        return this.queue.Count > 0;
    }

    public int Next() {
        return this.queue.Dequeue();
    }
//     I think this would have been good except that [[]] is valid input which I thought felt deceptive given the constaint on [] not being a valid starting input.
//     public NestedIterator(IList<NestedInteger> nestedList) {
//         this.cur = -1;
//         this.nestedList = nestedList;
        
//     }

//     public bool HasNext() {
//         if(this.next != null && this.next.HasNext()){
//             return true;
//         }
//         return this.cur < this.nestedList.Count-1;
//     }

//     public int Next() {
//         if(this.next!=null && this.next.HasNext()){
//             return this.next.Next();
//         }
//         else{
//             this.cur++;
//             if(!this.nestedList[cur].IsInteger()){
//                 if(this.nestedList[cur].GetList().Count > 0){
//                     this.next = new NestedIterator(this.nestedList[cur].GetList());
//                 }
//                 else{
//                     this.next = null;
//                 }
//             }
//             else{
//                 this.next = null;
//             }
//             if(this.next != null){
//                 return this.next.Next();
//             }
//             return this.nestedList[cur].GetInteger();
//         }
        
//     }
}

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */
