// every time you pop you need to take one queue and flip it into the other?

// my version was cheating, you should not need the extra array
// The actual answers were about mostly every time you added a new element enque and deque to put that element into the first spot and maintain the ordder
public class MyStack {
    private Queue<int> inOrder;
    private Queue<int> reverseOrder;

    public MyStack() {
        this.inOrder = new Queue<int>();
        this.reverseOrder = new Queue<int>();
    }
    
    public void Push(int x) {
        this.inOrder.Enqueue(x);
    }
    
    public int Pop() {
        if(this.inOrder.Count > 0){
            this.Shift();
        }
        return this.reverseOrder.Dequeue();
    }
    
    public int Top() {
        if(this.inOrder.Count > 0){
            this.Shift();
        }
        return this.reverseOrder.Peek();
    }
    
    public bool Empty() {
        return this.inOrder.Count == 0 && this.reverseOrder.Count == 0;
    }
    
    private void Shift(){
        int totalRemaining = this.reverseOrder.Count + this.inOrder.Count;
        int[] temp = new int[totalRemaining];
        int reverseOrderSizeStart = this.reverseOrder.Count;
        for(int i = 0; i<reverseOrderSizeStart;i++){
            temp[this.inOrder.Count + i] = this.reverseOrder.Dequeue();
        }
        int inOrderSizeStart = this.inOrder.Count;
        for(int i = inOrderSizeStart-1; i>=0;i--){
            temp[i] = this.inOrder.Dequeue();
        }
        for(int i = 0; i< totalRemaining;i++){
            this.reverseOrder.Enqueue(temp[i]);
        }
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */
