class RandomizedSet {
    private array: number[];
    // the first value is the values we store the second value is the location in the array. 
    private map: Map<number,number>;
    constructor() {
        this.array = [];
        this.map = new Map<number,number>();
    }

    insert(val: number): boolean {
        if(this.map.has(val)){
            return false;
        } else {
            this.map.set(val,this.array.length);
            this.array.push(val);
            // console.log(this.array);
            return true;
        }
    }

    remove(val: number): boolean {
        if(this.map.has(val)){
            this.array[this.map.get(val)] = this.array[this.array.length-1];
            this.map.set(this.array[this.array.length-1],this.map.get(val));
            this.array.pop();
            this.map.delete(val);
            // console.log(this.array);
            return true;
        } else{
            return false;
        }
    }

    getRandom(): number {
        let randomLocation = Math.floor(Math.random() * this.array.length);
        return this.array[randomLocation];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * var obj = new RandomizedSet()
 * var param_1 = obj.insert(val)
 * var param_2 = obj.remove(val)
 * var param_3 = obj.getRandom()
 */
