public class Solution {
    public IList<string> InvalidTransactions(string[] transactions) {
        Dictionary<string, List<Transaction>> nameToTransactionInCity = new Dictionary<string,List<Transaction>>();
        List<Transaction> transactionList = new List<Transaction>();
        for(int i = 0; i< transactions.Length;i++){
            string[] parts = transactions[i].Split(',');

            if(parts.Length < 4){
                Console.WriteLine("split did not find a good transaction");
                continue;
            }
            Transaction newTransaction = new Transaction(parts[0], Int32.Parse(parts[1]), Int32.Parse(parts[2]), parts[3], i);
            transactionList.Add(newTransaction);
        }
        transactionList.Sort((a,b) => a.time - b.time);
        List<string> ret = new List<string>();
        HashSet<int> invalid = new HashSet<int>();

        for(int i = 0; i<transactionList.Count; i++){
            // Console.WriteLine(transactionList[i].name);
            if(transactionList[i].ammount > 1000){
                invalid.Add(transactionList[i].baseListLocation);
                
            }
            if(nameToTransactionInCity.ContainsKey(transactionList[i].name)){
                foreach(var transaction in nameToTransactionInCity[transactionList[i].name]){
                    // Console.WriteLine(transaction.city);
                    if(transaction.city == transactionList[i].city){
                        continue;
                    }
                    if(transactionList[i].time - transaction.time <= 60){
                        invalid.Add(transactionList[i].baseListLocation);
                        invalid.Add(transaction.baseListLocation);
                    }
                }
            }
            if(!nameToTransactionInCity.ContainsKey(transactionList[i].name)){
                nameToTransactionInCity[transactionList[i].name] = new List<Transaction>();
            }
            nameToTransactionInCity[transactionList[i].name].Add(transactionList[i]);
        }
        foreach(int i in invalid){
            ret.Add(transactions[i]);
        }
        return ret;
    }
    
    public class Transaction{
        public string name;
        public int time;
        public int ammount;
        public string city;
        public int baseListLocation;
        public Transaction(string name, int time, int ammount, string city, int baseListLocation){
            this.name = name;
            this.time = time;
            this.ammount = ammount;
            this.city = city;
            this.baseListLocation = baseListLocation;
        }
    }
}
