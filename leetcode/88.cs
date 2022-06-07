/**
 Do not return anything, modify nums1 in-place instead.
 */
function merge(nums1: number[], m: number, nums2: number[], n: number): void {
    let nums1RightIndex = m-1;
    let nums2RightIndex = n-1;
    let pos = n+m -1;
    while(nums1RightIndex >= 0 || nums2RightIndex >= 0){
        if(nums1RightIndex < 0){
            nums1[pos] = nums2[nums2RightIndex];
            nums2RightIndex--;
        }
        else if(nums2RightIndex < 0){
            nums1[pos] = nums1[nums1RightIndex];
            nums1RightIndex--;
        }
        else{
            if(nums1[nums1RightIndex] > nums2[nums2RightIndex]){
                nums1[pos] = nums1[nums1RightIndex];
                nums1RightIndex--;
            }
            else{
                nums1[pos] = nums2[nums2RightIndex];
                nums2RightIndex--;
            }
        }
        pos--;
    }
};
