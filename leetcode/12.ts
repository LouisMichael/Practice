function intToRoman(num: number): string {
    if(Math.floor(num/1) <= 0){
        return "";
    }
    else if(Math.floor(num/1000) > 0){
        return "M" + intToRoman(num - 1000);
    }
    else if(Math.floor(num/900) > 0){
        return "CM" + intToRoman(num - 900);
    }
    else if(Math.floor(num/500) > 0){
        return "D" + intToRoman(num - 500);
    }
    else if(Math.floor(num/400) > 0){
        return "CD" + intToRoman(num - 400);
    }
    else if(Math.floor(num/100) > 0){
        return "C" + intToRoman(num - 100);
    }
    else if(Math.floor(num/90) > 0){
        return "XC" + intToRoman(num - 90);
    }
    else if(Math.floor(num/50) > 0){
        return "L" + intToRoman(num - 50);
    }
    else if(Math.floor(num/40) > 0){
        return "XL" + intToRoman(num - 40);
    }
    else if(Math.floor(num/10) > 0){
        return "X" + intToRoman(num - 10);
    }
    else if(Math.floor(num/9) > 0){
        return "IX" + intToRoman(num - 9);
    }
    else if(Math.floor(num/5) > 0){
        return "V" + intToRoman(num - 5);
    }
    else if(Math.floor(num/4) > 0){
        return "IV" + intToRoman(num - 4);
    }
    else {
        return "I" + intToRoman(num - 1);
    }
};
