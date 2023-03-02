public class Solution {
    public int Compress(char[] chars) {
        int startLetterPos = 0;
        int totalLength = -1;
        int curLetterCount = 1;
        for(int i = 1;i<chars.Length;i++){
            if(chars[i]==chars[startLetterPos]){
                // Console.WriteLine("char[i] = " + chars[i]);
                curLetterCount++;
            }
            else{
                // Console.WriteLine("chars = " + new String(chars));
                totalLength += this.updateLength(curLetterCount, startLetterPos, chars, totalLength);
                // Console.WriteLine("chars = " + new String(chars));
                curLetterCount = 1;
                startLetterPos = i;
                // Console.WriteLine("startLetterPos = " + i);
            }
        }
        totalLength += updateLength(curLetterCount, startLetterPos, chars, totalLength);
        // Console.WriteLine("chars = " + new String(chars));
        // Console.WriteLine("totalLength = " + (totalLength+1));
        return totalLength+1;
    }
    public int updateLength(int curLetterCount, int startLetterPos, char[] chars, int totalLength){
        // Console.WriteLine("totalLength = " + totalLength);
        chars[totalLength+1] = chars[startLetterPos];
        if(curLetterCount > 1){
            Stack<int> digetsToWrite = new Stack<int>();
            int numberDigets = 0;
            while(curLetterCount > 0){
                digetsToWrite.Push(curLetterCount %10);
                numberDigets++;
                curLetterCount /= 10;
            }
            int count = 1;
            while(digetsToWrite.Count > 0){
                chars[totalLength+count+1] = (char)((int)'0' + digetsToWrite.Pop());
                count++;
            }
            return numberDigets + 1;
        }
        else{
            return 1;
        }
    } 
}
