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
    public ListNode OddEvenList(ListNode head) {
        if(head == null){
            return null;
        }
        if(head.next == null){
            return head;
        }
        ListNode oddHead = head;
        ListNode evenHead = head.next;
        ListNode oddTail = head;
        ListNode evenTail = head.next;
        ListNode cur = evenTail.next;
        while(cur != null && cur.next != null){
            oddTail.next = cur;
            oddTail = cur;
            evenTail.next = cur.next;
            evenTail = cur.next;
            cur = cur.next.next;
        }
        if(cur != null){
            oddTail.next = cur;
            oddTail = cur;
        }
        oddTail.next = evenHead;
        evenTail.next = null;
        return oddHead;
    }
}
