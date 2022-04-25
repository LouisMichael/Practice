// C# IEnumerator interface reference:
// https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerator?view=netframework-4.8
// since we only support MoveNext return false when we run off the end has next is our tricky get
// I think we just store top and we move one ahead all the time to keep off the end in check

// I did not spend enough time reframing the problem after I read the docs and wasted several submissions as well as making a slow approch
// Runtime: 221 ms, faster than 16.07% of C# online submissions for Peeking Iterator.
// Memory Usage: 40.3 MB, less than 82.14% of C# online submissions for Peeking Iterator.
class PeekingIterator {
    // iterators refers to the first element of the array.
    private bool isPeekStored;
    private int curTop;
    private IEnumerator<int> iterator;
    private bool offEnd;
    public PeekingIterator(IEnumerator<int> iterator) {
        // initialize any member here.
        this.iterator = iterator;
        this.isPeekStored = false;
        this.offEnd = false;
    }
    
    // Returns the next element in the iteration without advancing the iterator.
    public int Peek() {
        if(this.isPeekStored){
            return curTop;
        }
        else{
            return this.iterator.Current;
        }
    }
    
    // Returns the next element in the iteration and advances the iterator.
    public int Next() {
        if(this.isPeekStored){
            this.isPeekStored = false;
            return this.curTop;
        }
        else{
            int temp = this.iterator.Current;
            this.offEnd = !this.iterator.MoveNext();
            return temp;
        }
    }
    
    // Returns false if the iterator is refering to the end of the array of true otherwise.
    public bool HasNext() {
		if(this.isPeekStored){
            return true;
        }
        else{
            if(this.offEnd){
                return false;
            }
            else{
                this.isPeekStored = true;
                this.curTop = this.iterator.Current;
                this.offEnd = !this.iterator.MoveNext();
                return true;
            }
        }
    }

// I did not read the docs for the IEnumerator class at first and thought it would only support Next and HasNext but this is not the case, it only supports MoveNext and Current 
// class PeekingIterator {
//     // iterators refers to the first element of the array.
//     private bool isPeekTop;
//     private int curPeek;
//     private IEnumerator<int> iterator;
//     public PeekingIterator(IEnumerator<int> iterator) {
//         // initialize any member here.
//         this.isPeekTop = false;
//         this.iterator = iterator;
//     }
    
//     // Returns the next element in the iteration without advancing the iterator.
//     public int Peek() {
//         if(this.isPeekTop){
//             return this.curPeek;
//         }
//         else{
//             this.curPeek = this.iterator.Next();
//             this.isPeekTop = true;
//             return this.curPeek;
//         }
//     }
    
//     // Returns the next element in the iteration and advances the iterator.
//     public int Next() {
//         if(this.isPeekTop){
//             return this.curPeek;
//             this.isPeekTop = false;
//         }
//         else{
//             return this.iterator.Next();
//         }
//     }
    
//     // Returns false if the iterator is refering to the end of the array of true otherwise.
//     public bool HasNext() {
// 		if(this.isPeekTop){
//             return true;
//         }
//         else{
//             return this.iterator.HasNext();
//         }
//     }
}
