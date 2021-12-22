// 128 ms, faster than 64.69% of C# online submissions for Insertion Sort List.

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
    public ListNode sortedEnd;
    public ListNode InsertionSortList(ListNode head) {
        if(sortedEnd == null){
            sortedEnd = head;
        }
        while(sortedEnd.next != null){
            ListNode curInsert = sortedEnd.next;
            ListNode index = head;
            ListNode prev = null;
            while(prev != sortedEnd){
                if(index.val > curInsert.val){
                    // Console.WriteLine("moving " + curInsert.val + " to before " + index.val);
                    sortedEnd.next = curInsert.next;
                    curInsert.next = index;
                    if(index == head){
                        head = curInsert;
                    }else{
                        prev.next = curInsert;
                    }
                    break;
                }
                prev = index;
                index = index.next;
            }
            if(sortedEnd.next == curInsert){
                sortedEnd = curInsert;
            }
        }
        return head;
    }
}
