function containsNearbyDuplicate(nums: number[], k: number): boolean {
//  we can use some mem to do this by having a list of the most recent index of a value k ahead
    let fast = 0;
    let lastIndexMap = new Map<number, number>();
    while (fast < k){
        lastIndexMap[nums[fast]] = fast;
        fast++;
    }
    let slow = 0;
    while(slow < nums.length){
        if(fast != nums.length){
            lastIndexMap[nums[fast]] = fast;
            fast++;
        }
        // console.log(lastIndexMap);
        let lastSeen = lastIndexMap[nums[slow]];
        if(lastSeen != null && lastSeen - slow > 0 && lastSeen - slow <= k){
            return true;
        }
        slow++;
    }
    return false;
};
