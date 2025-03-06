class ParkingLotService {
    private int totalVacant;
    private Dictionary<int, Vehicle> parkingLots;

    public ParkingLotService(int vacant){
        totalVacant = vacant;
        parkingLots = new Dictionary<int, Vehicle>();
        Console.WriteLine($"Created parking of {vacant} spots");
    }

    public void Park(string registrationNo, string color, string type){
        if(parkingLots.Count >= totalVacant){
            Console.WriteLine("Sorry, parking lot is full");
            return;
        }
        int vacantSlot = Enumerable.Range(1, totalVacant).First(i => !parkingLots.ContainsKey(i));
        parkingLots[vacantSlot] = new Vehicle(registrationNo, color, type);
        Console.WriteLine($"Allocated slot number: {vacantSlot}");
    }

    public void Leave(int parkingLot){
        if(parkingLots.ContainsKey(parkingLot)){
            parkingLots.Remove(parkingLot);
            Console.WriteLine($"Slot number {parkingLot} is free");
            return;
        }
    }

    public void Status(){
        Console.WriteLine("Slot\tRegistration No\tType\tColor");
        foreach(var parkingLot in parkingLots.OrderBy(s => s.Key)){
            var vehicle = parkingLot.Value;
            Console.WriteLine($"{parkingLot.Key}\t{vehicle.RegistrationNo}\t{vehicle.Type}\t{vehicle.Color}");
        }
    }

    public void VehicleType(string type) {
        Console.WriteLine(parkingLots.Values.Count(i => i.Type.Equals(type, StringComparison.OrdinalIgnoreCase)));
    }

    public void OddNumberVehicle(){
        var result = parkingLots.Values.Where(i => Util.IsOddRegNo(i.RegistrationNo)).Select(i => i.RegistrationNo);
        Console.WriteLine(string.Join(", ", result));
    }

    public void EvenNumberVehicle(){
        var result = parkingLots.Values.Where(i => !Util.IsOddRegNo(i.RegistrationNo)).Select(i => i.RegistrationNo);
        Console.WriteLine(string.Join(", ", result));
    }

    public void VehiclesWithColor(string color){
        var result = parkingLots.Values.Where(i => i.Color.Equals(color, StringComparison.OrdinalIgnoreCase)).Select(i => i.RegistrationNo);
        Console.WriteLine(string.Join(", ", result));
    }

    public void SlotNumbersWithColor (string color){
        var result = parkingLots.Where(i => i.Value.Color.Equals(color, StringComparison.OrdinalIgnoreCase)).Select(i => i.Key);
        Console.WriteLine(string.Join(", ", result));
    }

    public void SlotNumberWithRegistrationNo(string registrationNo){
        var result = parkingLots.FirstOrDefault(i => i.Value.RegistrationNo.Equals(registrationNo, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine(result.Key != 0 ? result.Key.ToString() : "Not found");
    }
}