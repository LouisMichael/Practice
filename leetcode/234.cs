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
    public bool IsPalindrome(ListNode head) {
        List<int> list =  new List<int>();
        ListNode cur = head;
        while(cur != null){
            list.Add(cur.val);
            cur = cur.next;
        }
        for(int i = 0; i<list.Count; i++){
            if(list[i] != list[list.Count-1-i]){
                return false;
            }
        }
        return true;
    }
}
