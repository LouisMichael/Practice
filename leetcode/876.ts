/**
 * Definition for singly-linked list.
 * class ListNode {
 *     val: number
 *     next: ListNode | null
 *     constructor(val?: number, next?: ListNode | null) {
 *         this.val = (val===undefined ? 0 : val)
 *         this.next = (next===undefined ? null : next)
 *     }
 * }
 */

// Runtime: 80 ms, faster than 50.75% of TypeScript online submissions for Middle of the Linked List.
// Memory Usage: 40.5 MB, less than 67.27% of TypeScript online submissions for Middle of the Linked List.

function middleNode(head: ListNode | null): ListNode | null {
    let fast: ListNode = head;
    let slow: ListNode = head;
    while(fast.next != null && fast.next.next != null){
        fast = fast.next.next;
        slow = slow.next;
    }
    if(fast.next != null){
        slow = slow.next;
    }
    return slow;

};
