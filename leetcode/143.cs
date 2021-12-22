// Your runtime beats 71.03 % of csharp submissions.

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public void ReorderList(ListNode head) {
        ListNode cur = head;
        int count = 0;
        Stack<ListNode> myStack = new Stack<ListNode>();
        while(cur != null){
            // Console.WriteLine(cur.val);
            myStack.Push(cur);
            cur = cur.next;
            count++;
        }
        cur = head;
        ListNode temp = null;
        for(int i = 0; i < count/2; i++){
            temp = cur.next;
            ListNode last = myStack.Pop();
            
            if(temp == last){
                
                break;
            }
            // Console.WriteLine("cur: " + cur.val);
            // Console.WriteLine("temp: " + temp.val);

            cur.next = last;
            last.next = temp;
            
            cur = temp;
        }
        if(temp != null){
            temp.next = null;
        }
        
        cur = head;
        // while(cur != null){
        //     Console.WriteLine(cur.val);
        //     cur = cur.next;
        // }
    }
}
