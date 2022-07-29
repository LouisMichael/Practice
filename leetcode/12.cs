public class Solution {
    public string IntToRoman(int num) {
        if(num / 1000 > 0){
            return "M" + this.IntToRoman(num - 1000);
        }
        if(num / 100 > 0){
            if(num /100 == 9){
               return "CM" + this.IntToRoman(num - 900);
            }
            if(num /100 == 4){
               return "CD" + this.IntToRoman(num - 400);
            }
            if(num/500 >= 1){
                return "D" + this.IntToRoman(num - 500);
            }
            return "C" + this.IntToRoman(num - 100);
        }
        if(num / 10 > 0){
            if(num /10 == 9){
               return "XC" + this.IntToRoman(num - 90);
            }
            if(num /10 == 4){
               return "XL" + this.IntToRoman(num - 40);
            }
            if(num/50 >= 1){
                return "L" + this.IntToRoman(num - 50);
            }
            else{
                return "X" + this.IntToRoman(num - 10);
            }
        }
        if(num > 0){
            if(num == 9){
               return "IX";
            }
            if(num == 4){
               return "IV";
            }
            if(num/5 >= 1){
                return "V" + this.IntToRoman(num - 5);
            }
            return "I" + this.IntToRoman(num - 1);
        }
        else{
            return "";
        }
    }
}
