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

function oddEvenList(head: ListNode | null): ListNode | null {
    let cur = head;
    let oddHead = null;
    let oddTail = null;
    while(cur!=null && cur.next != null && cur.next.next != null){
        // console.log(cur.val);
        if(oddHead == null){
            oddHead = cur.next;
            oddTail = cur.next;
        }
        else{
            oddTail.next = cur.next;
        }
        oddTail = cur.next;
        cur.next = cur.next.next;
        cur = cur.next;
    }
    if(cur == null){
        return head;
    }
    else if(cur.next == null){
        cur.next = oddHead;
        if(oddTail){
            oddTail.next = null;
        }
    }
    else{
        if(!oddHead){
            oddHead = cur.next;
            oddTail = cur.next;
        }
        else{
            oddTail.next = cur.next;
            oddTail = cur.next;
        }
        oddTail.next = null;
        cur.next = oddHead;
    }
    return head;
};
