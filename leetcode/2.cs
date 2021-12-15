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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        return this.AddTowNumbersSolve(l1, l2, 0);
    }
    
    public ListNode AddTowNumbersSolve(ListNode l1, ListNode l2, int carry) {
        ListNode next = new ListNode();
        next.val += carry;
        if(l1 == null && l2 == null){
            if(next.val != 0)
                return next;
            return null;
        }
        if(l1 != null){
            next.val += l1.val;
            l1 = l1.next;
        }
        if(l2 != null){
            next.val += l2.val;
            l2 = l2.next;
        }
        int newCarry = next.val / 10;
        next.val %= 10;
        next.next = this.AddTowNumbersSolve(l1, l2, newCarry);
        return next;
    }
}
