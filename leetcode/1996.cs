public class Solution {
    public int NumberOfWeakCharacters(int[][] properties) {
//         a pretty fast version would be to have a sorted array by attack
//         then walk from top attack to least attack and have a running tally of the smallest defense seen
        Array.Sort(properties, new PowerCompair());
        int minDefense = 0;
        int curAttack = properties[0][0];
        int nextMinDefense = 0;
        int ret = 0;
        for(int i =0; i<properties.Length;i++){
            if(curAttack != properties[i][0]){
                curAttack = properties[i][0];
                minDefense = nextMinDefense;
                nextMinDefense = minDefense;
            }
            
            if(properties[i][1] < minDefense){
                ret++;
            }
            if(properties[i][1] > nextMinDefense){
                // Console.WriteLine("next min defense will now be: " + properties[i][1] );
                
                nextMinDefense = properties[i][1];
            }
        }
        return ret;

    }
    
}
public class PowerCompair : IComparer {
    public int Compare(object a, object b){
        return ((int[])b)[0]-((int[])a)[0];
    }
}
