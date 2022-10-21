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
// I think I both understand and can use insertion sort in a linked list
function sortList(head: ListNode | null): ListNode | null {
    if(head == null){
        return head;
    }
    let firstUnsorted = head.next;
    let sortedHead = head;
    head.next = null;
    while(firstUnsorted != null){
        let insertNode = firstUnsorted;
        firstUnsorted = firstUnsorted.next;
        // console.log(insertNode.val);
        let prev = null;
        let cur = sortedHead;
        while(cur!=null && insertNode.val > cur.val){
            prev = cur;
            cur = cur.next;
        }
        
        if(prev == null){
            insertNode.next = sortedHead;
            sortedHead = insertNode;
        }
        else{
            prev.next = insertNode;
            insertNode.next = cur;
        }
    }
    return sortedHead;
};
