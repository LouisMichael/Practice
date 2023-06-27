public class Solution {
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k) {
        // we want to follow the order of lowest from left, next from right until next from left and first from right is smaller
        List<IList<int>> ret = new List<IList<int>>();
        int pairsAdded = 0;
        PriorityQueue<(int, int), int> queue = new PriorityQueue<(int, int), int>();
        // int[] used = new int[nums1.Length];
        queue.Enqueue((0,0), nums1[0] + nums2[0]);
        while(pairsAdded < k && queue.Count > 0){
            (int, int) pair = queue.Dequeue();
            List<int> nextPair = new List<int>();
            // Console.WriteLine(pair);

            nextPair.Add(nums1[pair.Item1]);
            nextPair.Add(nums2[pair.Item2]);
            ret.Add(nextPair);
            pairsAdded++;
            if(pair.Item2+1 < nums2.Length){
                queue.Enqueue((pair.Item1, pair.Item2 +1), nums1[pair.Item1] + nums2[pair.Item2 +1]);
            }
            if(pair.Item2 == 0 && pair.Item1+1 < nums1.Length){
                queue.Enqueue((pair.Item1+1, pair.Item2), nums1[pair.Item1+1] + nums2[pair.Item2]);
            }
        }
        return ret;
    }
}
