public class Solution {
    public long MinimumHealth(int[] damage, int armor) {
        // this is a pretty simple greedy problem, we want to find the spot where we can best use armor, so the max singe instance of damage
        long ret = 1;
        long max = 0;
        for(int i = 0; i<damage.Length;i++){
            ret += damage[i];
            max = Math.Max(damage[i], max);
        }
        ret -= Math.Min(max, armor);
        return ret;
    }
}
