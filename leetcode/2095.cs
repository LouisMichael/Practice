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
    public ListNode DeleteMiddle(ListNode head) {
        ListNode fast = head;
        ListNode slow = head;
        ListNode prevSlow = null;
        while(fast!= null && fast.next != null){
            fast =  fast.next.next;
            prevSlow = slow;
            slow = slow.next;
        }
        if(prevSlow == null){
            return null;
        }
        prevSlow.next = slow.next;
        return head;
    }
}
