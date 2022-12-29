// I worked in Java because JS does not have a built in heap structure, I guess I also could just write a heap but that seemed more error prone

class Solution {
    public int[] getOrder(int[][] tasks) {
        int[] ret = new int[tasks.length];
        int retPos = 0;
        PriorityQueue<Task> availabelProcessHeap = new PriorityQueue<>((a, b) -> a.processTime == b.processTime? a.name - b.name : a.processTime - b.processTime);
        Task[] taskList = new Task[tasks.length];
        for(int i =0; i<tasks.length;i++){
            Task newTask = new Task();
            newTask.name = i;
            newTask.startAfterTime = tasks[i][0];
            newTask.processTime = tasks[i][1];
            taskList[i] = newTask;
        }
        Arrays.sort(taskList, (a,b) -> a.startAfterTime - b.startAfterTime);
        // for(int i = 0; i<taskList.length;i++){
        //     System.out.println(taskList[i].startAfterTime);
        // }
        int curPos = 0;
        int time = 0;
        while(curPos < tasks.length){
            if(taskList[curPos].startAfterTime <= time){
                availabelProcessHeap.add(taskList[curPos]);
                curPos++;
            }
            else if(availabelProcessHeap.size() > 0){
                Task curTask = availabelProcessHeap.remove();
                time += curTask.processTime;
                ret[retPos] = curTask.name;
                retPos++;
            }
            else{
                time = taskList[curPos].startAfterTime;
            }
        }
        while(availabelProcessHeap.size() > 0){
            ret[retPos] = availabelProcessHeap.remove().name;
            retPos++;
        }
        return ret;
    }
}
class Task{
        public int name;
        public int startAfterTime;
        public int processTime;
}
