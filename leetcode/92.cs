public class Solution {
    public ListNode ReverseBetween(ListNode head, int left, int right) {
        ListNode leftCur = head;
        ListNode rightCur = head;
        
        for(int i = 0 ; i < right-1; i++) {
            rightCur = rightCur.next;
            Console.WriteLine(rightCur.val);
        }
        if(left == 1){
            head = rightCur;
        }
        else{
            for(int i = 0 ; i < left-2; i++) {
                leftCur = leftCur.next;
                Console.WriteLine(leftCur.val);
            }
            ListNode temp = leftCur.next;
            leftCur.next = rightCur;
            leftCur = temp;
        }
        
        ListNode cur = leftCur;
        ListNode next = leftCur.next;
        cur.next = rightCur.next;
        ListNode last = cur;
        for(int i = 0; i<right - left;i++){
            cur = next;
            next = cur.next;
            cur.next = last;
            last = cur;
        }
        return head;
    }
}
