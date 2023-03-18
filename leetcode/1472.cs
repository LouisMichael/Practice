public class BrowserHistory {
    public Stack<string> backHistory;
    public Stack<string> forwardHistory;

    public BrowserHistory(string homepage) {
        this.backHistory = new Stack<string>();
        this.backHistory.Push(homepage);
    }
    
    public void Visit(string url) {
        if(this.forwardHistory != null){
            this.forwardHistory = null;
        }
        this.backHistory.Push(url);
    }
    
    public string Back(int steps) {
        if(this.forwardHistory == null){
            this.forwardHistory = new Stack<string>();
        }
        while(this.backHistory.Count > 1 && steps > 0){
            this.forwardHistory.Push(this.backHistory.Pop());
            steps--;
        }
        return this.backHistory.Peek();
    }
    
    public string Forward(int steps) {
        if(this.forwardHistory == null){
            return this.backHistory.Peek();
        }
        while(this.forwardHistory.Count > 0 && steps > 0){
            this.backHistory.Push(this.forwardHistory.Pop());
            steps--;
        }
        return this.backHistory.Peek();
    }
}
