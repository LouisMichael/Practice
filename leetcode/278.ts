// Runtime: 104 ms, faster than 45.21% of TypeScript online submissions for First Bad Version.
// Memory Usage: 42.5 MB, less than 17.81% of TypeScript online submissions for First Bad Version.

/**
 * The knows API is defined in the parent class Relation.
 * isBadVersion(version: number): boolean {
 *     ...
 * };
 */

var solution = function(isBadVersion: any) {

    return function(n: number): number {
        let min = 1;
        let max = n;
        while(min < max){
            let midPos = Math.floor((max + min)/2);
            let isBad = isBadVersion(midPos);
            if(isBad){
                max = midPos;
            }
            else{
                min = midPos + 1;
            }
        }
        return max;
    };
};
