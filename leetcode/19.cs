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
//     O(2N) + O(1) memory is run down the whole list to see how long and then go again to do the remove
//     O(N) + O(N) memory is to just keep track of the whole list by index and then go back to that spot
//     I wonder if there is a trick that is even better
//     there is the gap between the nodes should be of size n! That is the amount of a head start you need to give
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        Dictionary<int, ListNode> index = new Dictionary<int, ListNode>();
        int count = 0;
        ListNode cur =  head;
        while(cur != null){
            index[count] = cur;
            count++;
            cur = cur.next;
        }
        if(count - n < 0){
            return null;
        }
        if(count - n == 0){
            if(count > 1){
                return index[1];
            }
            else{
                return null;
            }
        }
        index[count-n-1].next = index[count-n].next;
        return head;
    }
}
