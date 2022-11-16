/** 
 * Forward declaration of guess API.
 * @param {number} num   your guess
 * @return 	     -1 if num is higher than the picked number
 *			      1 if num is lower than the picked number
 *               otherwise return 0
 * var guess = function(num) {}
 */


function guessNumber(n: number): number {
    let left = 1;
    let right = n;
    while(left<right){
        let mid = Math.floor((left+right)/2);
        let guessResult = guess(mid);
        if(guessResult > 0){
            left = mid+1;
        }
        else if(guessResult < 0){
            right = mid -1;
        }
        else{
            return mid;
        }
    }
    return left;
};
