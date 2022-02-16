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

function swapPairs(head: ListNode | null): ListNode | null {
    let cur = head;
    let prev = null;
    let prevPrev = null;
    while(cur != null){
        
        if(prev != null){
            if(prevPrev == null){
                head = cur;
            }
            else{
                prevPrev.next = cur;
            }
            prev.next = cur.next;
            cur.next = prev;
            prevPrev = prev;
            cur = prev.next;
            prev = null;
            
        }
        else{
            prev = cur;
            cur = cur.next;
        }
        
    }
    return head;
};
