function validMountainArray(arr: number[]): boolean {
    let increasing = true;
    if(arr.length < 3){
        return false;
    }
    if(arr[0]>=arr[1]){
        return false;
    }
    for(let i = 2; i < arr.length; i++){
        if(increasing){
            if(arr[i]<arr[i-1]){
                increasing = false;
            }
            if(arr[i]==arr[i-1]){
                return false;
            }
        }
        else{
            if(arr[i]>=arr[i-1]){
                return false;
            }
        }
    }
    return !increasing;
};
