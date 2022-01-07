// Runtime: 217 ms, faster than 14.29% of TypeScript online submissions for Linked List Random Node.
// Memory Usage: 45.7 MB, less than 100.00% of TypeScript online submissions for Linked List Random Node.
// These values seem way off, I used an approch that should have been on the high end for memory and the low
// end of execution time, and checking on solutions listed that lines up. 
// After looking at the solution it turns out there is a fancy way to do this called Reservoir Sampling which
// I still don't fully get but it still runs in O(N) time

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

class Solution {
    private arrayList: number[];
    constructor(head: ListNode | null) {
        this.arrayList = [];
        let cur: ListNode = head;
        while(cur !== null){
            this.arrayList.push(cur.val);
            cur = cur.next;
        }
    }

    getRandom(): number {
        let seed = Math.floor(Math.random() * this.arrayList.length);
        return this.arrayList[seed];
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * var obj = new Solution(head)
 * var param_1 = obj.getRandom()
 */
