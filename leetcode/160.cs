/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
//     I think a set is the fastest way to do it, since you don't know the diff in starting spaces before the intersection 
//     we can run to the end of each and then the diff in length will tell us how much the offset is.
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        int aLength = 0;
        ListNode temp = headA;
        while(temp != null){
            aLength++;
            temp = temp.next;
        }
        int bLength = 0;
        temp = headB;
        while(temp != null){
            bLength++;
            temp = temp.next;
        }
        ListNode temp2 = null;
        if(aLength > bLength){
            temp = headA;
            temp2 = headB;
            for(int i = 0; i < aLength-bLength; i++){
                temp = temp.next;
            }
            while(temp != null && temp2 != null){
                if(temp == temp2){
                    return temp;
                }
                temp = temp.next;
                temp2 = temp2.next;
            }
        }
        else{
            temp = headB;
            temp2 = headA;
            for(int i = 0; i < bLength-aLength; i++){
                temp = temp.next;
            }
            while(temp != null && temp2 != null){
                
                if(temp == temp2){
                    return temp;
                }
                temp = temp.next;
                temp2 = temp2.next;
            }
        }
        return null;
        
    }
}
