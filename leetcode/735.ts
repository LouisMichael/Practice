
function asteroidCollision(asteroids: number[]): number[] {
    let stack = [];
    for(let i = 0; i<asteroids.length;i++){
        if(asteroids[i] < 0){
            let colides = false;
            while(stack.length > 0 && stack[stack.length-1] > 0){
                let colision = stack.pop();
                if(colision > asteroids[i] * -1){
                    colides = true;
                    stack.push(colision);
                    break;   
                }
                else if(colision == asteroids[i] * -1){
                    colides = true;
                    break;
                }
            }
            if(!colides){
                stack.push(asteroids[i]);
            }
        }
        else{
            stack.push(asteroids[i]);
        }
    }
    return stack;
};
