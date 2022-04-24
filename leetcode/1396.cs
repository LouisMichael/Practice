// Runtime: 777 ms, faster than 5.13% of C# online submissions for Design Underground System.
// Memory Usage: 58 MB, less than 74.36% of C# online submissions for Design Underground System.
// FIRST TRY NO COMPILE ISSUES!!!!!!! FIRST TRY SUBMISSION NO ERRORS!!!!!!!

// A good speedup I saw on looking at other solves is that we only need to do the math for the averge when we ask for the average time not every check in and because division is expensive this is important. 
// Applying this got me to:
// Runtime: 431 ms, faster than 60.26% of C# online submissions for Design Underground System.
// Memory Usage: 60.6 MB, less than 42.31% of C# online submissions for Design Underground System.
public class UndergroundSystem {
// I think we want two datastructures
//     one will be tasked with keeping track of who is currently riding so we can get a amount of time they are on board.
// I think this strucutre would make snense as a hash map of id as key and of start station start time as a tuple as contens since we will need both peices of information on exit. 
//     one will be tasked with keeping track of the avgs, when a rider exits we have an opertuity to update this strucutre. 
// I think this will make sense as a map with the station pair as the key (entry station, exit station) and the number of people who have ridden and the current mean as a touple contents, this will let us update the mean easily
//     new mean = ((old mean * old mean riders) + new rider time)/(old mean riders + 1[the new rider])
    private Dictionary<int, (string, int)> riderCheckins;
    private Dictionary<(string, string), (int, int)> meanRideTimes;
    public UndergroundSystem() {
        riderCheckins = new Dictionary<int, (string, int)>();
        meanRideTimes = new Dictionary<(string, string), (int, int)>();
    }
    
    public void CheckIn(int id, string stationName, int t) {
        this.riderCheckins[id] = (stationName, t);
//         I could add some defense here on rider checkin of a already checked in rider but the problem seemed to constain against this.
    }
    
    public void CheckOut(int id, string stationName, int t) {
//         update mean ride times
        (string, string) key = (this.riderCheckins[id].Item1, stationName);
        int recentRideTime = t - this.riderCheckins[id].Item2;
        if(this.meanRideTimes.ContainsKey(key)){
            this.meanRideTimes[key] = (this.meanRideTimes[key].Item1 + recentRideTime, this.meanRideTimes[key].Item2+1);
        }
        else{
            this.meanRideTimes[key] = (recentRideTime, 1);
        }
    }
    
    public double GetAverageTime(string startStation, string endStation) {
        (string, string) key = (startStation, endStation);
        return ((double)this.meanRideTimes[key].Item1 / (double)this.meanRideTimes[key].Item2);
    }
}

/**
 * Your UndergroundSystem object will be instantiated and called as such:
 * UndergroundSystem obj = new UndergroundSystem();
 * obj.CheckIn(id,stationName,t);
 * obj.CheckOut(id,stationName,t);
 * double param_3 = obj.GetAverageTime(startStation,endStation);
 */
