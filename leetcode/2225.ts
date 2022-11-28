function findWinners(matches: number[][]): number[][] {
    // we can keep three dictionaries one for no loss, one for one loss, one for more loss, if you are not in any you go to 1 or 0, if you are in one you move to the next one
    let zeroLoss = new Set<number>();
    let oneLoss = new Set<number>();
    let moreThanOneLoss = new Set<number>();
    for(let i = 0; i<matches.length;i++){
        let loss = matches[i][1];
        let win = matches[i][0];
        if(zeroLoss.has(loss)){
            zeroLoss.delete(loss);
            oneLoss.add(loss);
        } else if(oneLoss.has(loss)){
            oneLoss.delete(loss);
            moreThanOneLoss.add(loss);
        } else if(!moreThanOneLoss.has(loss)){
            oneLoss.add(loss);
        }
        if(!zeroLoss.has(win) && !oneLoss.has(win) && !moreThanOneLoss.has(win)){
            zeroLoss.add(win);
        }
    }
    let ret = [];
    ret[0] = Array.from(zeroLoss);
    ret[1] = Array.from(oneLoss);
    ret[0].sort((a, b) => {return a-b});
    ret[1].sort((a, b) => {return a-b});

    return ret;
};
