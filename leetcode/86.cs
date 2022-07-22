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
//     it is O(n) to build a second list and then stick it on the end so I think that is what I am going to try first 
    public ListNode Partition(ListNode head, int x) {
        ListNode prev = null;
        ListNode cur =  head;
        ListNode next = null;
        ListNode headOfNewList = null;
        ListNode tailOfNewList = null;
        while(cur != null){
            next = cur.next;
            if(cur.val >= x){
                if(prev != null){
                    prev.next = cur.next;
                }
                else{
                    head = next;
                }
                if(tailOfNewList != null){
                    tailOfNewList.next = cur;
                }
                else{
                    headOfNewList = cur;
                }
                cur.next = null;
                tailOfNewList = cur;
//                 prev will not change in this case
            }
            else{
                prev = cur;
            }
            cur = next;
        }
        if(prev == null){
            head = headOfNewList;
        }
        else{
            prev.next = headOfNewList;
        }
        return head;
    }
}
