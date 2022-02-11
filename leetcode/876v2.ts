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
// I could have done this better by not using a counter but instead actually having fast move twice
function middleNode(head: ListNode | null): ListNode | null {
    let fast = head;
    let slow = head;
    let count = 0;
    while(fast != null){
        fast = fast.next;
        if(count % 2){
            slow = slow.next;
        }
        count ++;
    }
    return slow;
};
