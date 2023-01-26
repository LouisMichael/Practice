public class Solution {
    public int MinimumSemesters(int n, int[][] relations) {
        // in the first semeseter we will take all classes with no pre recs
        // in subsequant semesters we will take any class we have fufilled prereques for
        Node[] allNode = new Node[n];
        for(int i = 0; i<n;i++){
            allNode[i] = new Node();
        }
        bool[] notOpeningRound = new bool[n];
        List<int> nextRound = new List<int>();

        for(int i =0; i< relations.Length;i++){
            allNode[relations[i][0]-1].postrequisite.Add(relations[i][1]-1);
            allNode[relations[i][1]-1].prerequsite.Add(relations[i][0]-1);
            notOpeningRound[relations[i][1]-1] = true;
        }
        for(int i =0; i<notOpeningRound.Length;i++){
            if(!notOpeningRound[i]){
                nextRound.Add(i);
            }
        }
        int visited = 0;
        int round = 0;
        while(nextRound.Count > 0){
            Console.WriteLine(nextRound.Count);
            List<int> curRound = nextRound;
            nextRound = new List<int>();
            for(int i =0; i<curRound.Count; i++){
                visited++;
                foreach(int postreq in allNode[curRound[i]].postrequisite){
                    // check the RemoveAll
                    allNode[postreq].prerequsite.Remove(curRound[i]);
                    if(allNode[postreq].prerequsite.Count == 0){
                        nextRound.Add(postreq);
                    }
                }
            }
            round++;
        }
        return visited == n? round: -1;
    }
    public class Node{
        // we may care about repreates
        public List<int> postrequisite;
        public List<int> prerequsite;

        public Node(){
            this.postrequisite = new List<int>();
            this.prerequsite = new List<int>();
        }
    }
}
