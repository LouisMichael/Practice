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
// Runtime: 112 ms, faster than 46.33% of TypeScript online submissions for Remove Nth Node From End of List.
// Memory Usage: 44.8 MB, less than 14.18% of TypeScript online submissions for Remove Nth Node From End of List.
function removeNthFromEnd(head: ListNode | null, n: number): ListNode | null {
let prev = null;
    let slow = head;
    let fast = head;
    for(let i = 0; i < n; i++){
        fast = fast.next;
    }
    while(fast != null){
        prev = slow;
        slow = slow.next;
        fast = fast.next;
    }
    if(prev == null){
//         we want to remove the first item which may also be the last item
        return slow.next; 
    }
    prev.next = slow.next;
    return head;
};
