// Runtime: 94 ms, faster than 68.28% of TypeScript online submissions for Linked List Cycle II.
// Memory Usage: 41.9 MB, less than 55.17% of TypeScript online submissions for Linked List Cycle II.

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

function detectCycle(head: ListNode | null): ListNode | null {
    let fast:ListNode = head;
    let visited:Set<ListNode> = new Set<ListNode>();
    while(fast != null){
        if(visited.has(fast)){
            return fast;
        }
        visited.add(fast);
        fast = fast.next;
    }
    return null;
};
