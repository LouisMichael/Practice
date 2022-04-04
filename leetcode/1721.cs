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
// Runtime: 474 ms, faster than 19.50% of C# online submissions for Swapping Nodes in a Linked List.
// Memory Usage: 49.6 MB, less than 73.00% of C# online submissions for Swapping Nodes in a Linked List.

// The sovle I used felt like cheating since it does a value swap reather then a object swap, but the hits also suggest you translate into an array so I guess it was a "cleaver" solution rather then cheating
public class Solution {
//     is the empty list a case?
//     is switchning the same node a case?
//     is switching behind each other a case?
//     getting to all these points we will need 3 pointers, one that knows where it is going
//     plus two one with a head start to get to the end offset
    public ListNode SwapNodes(ListNode head, int k) {
        ListNode headStart = head;
        ListNode offset = head;
        ListNode prev1 = null;
        ListNode prev2 = null;
        for(int i = 0; i<k-1;i++){
            prev1 = headStart;
            headStart = headStart.next;
        }
        ListNode first = headStart;
        headStart = headStart.next;
        while(headStart != null){
            headStart = headStart.next;
            prev2 = offset;
            offset = offset.next;
        }
        int temp = first.val;
        first.val = offset.val;
        offset.val = temp;
        // // Console.WriteLine("offset: " + offset.val);
        // // Console.WriteLine("first: " + first.val);
        // // Console.WriteLine("prev1: " + prev1.val);
        // // Console.WriteLine("prev2: " + prev2.val);
        // ListNode tempNext = first.next;
        // first.next = offset.next;
        // offset.next = tempNext;
        // if(prev1 != null){
        //     prev1.next = offset;
        // }
        // if(prev2 != null){
        //     prev2.next = first;
        // }
        // // ListNode test = head;
        // // while(test != null){
        // //     Console.WriteLine(test.val);
        // //     test = test.next;
        // // }
        // return (head==first)? offset : (offset==head)? first : head;
        return head;
    }
}
