public class Solution {
    public int FirstUniqChar(string s) {
//         this is easy in 2n, one to count one to find the order it appeared
//         you could also keep a stack of the letters and if you saw a repeat you could pop it, that would be closer to n
        int[] letterCount = new int[26];
        Queue<LetterWrapper> queue = new Queue<LetterWrapper>();
        for(int i = 0; i< s.Length;i++){
            letterCount[s[i]-'a']++;
            if(letterCount[s[i]-'a'] == 1){
                LetterWrapper cur = new LetterWrapper();
                cur.val = s[i];
                cur.pos = i;
                queue.Enqueue(cur);
            }
            // Console.WriteLine(letterCount[queue.Peek().val-'a']);
            while(queue.Count > 0 && letterCount[queue.Peek().val-'a']>1){
                queue.Dequeue();
            }
        }
        if(queue.Count > 0){
            return queue.Peek().pos;
        }
        return -1;
    }
    public class LetterWrapper{
        public char val;
        public int pos;
    }
}
