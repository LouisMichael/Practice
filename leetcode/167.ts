function twoSum(numbers: number[], target: number): number[] {
    let pos1 = 0;
    let pos2 = 1;
    while(pos1 < numbers.length){
        if(numbers[pos1] + numbers[pos2] == target){
            return [pos1+1,pos2+1];
        }
        if(numbers[pos1] + numbers[pos2] < target){
            pos2++;
        }
        else{
            pos1++;
            pos2 = pos1 + 1;
        }
    }

};
