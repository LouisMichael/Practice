/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public void DeleteNode(ListNode node) {
        ListNode cur = node;
        ListNode prev = null;
        while(cur.next != null){
            cur.val = cur.next.val;
            prev = cur;
            cur = cur.next;
        }
        prev.next = null;
    }
}
