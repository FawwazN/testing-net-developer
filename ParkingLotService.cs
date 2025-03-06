using System;
using System.Collections.Generic;
using System.Linq;

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
        if (parkingLots.Values.Any(i => i.RegistrationNo.Equals(registrationNo, StringComparison.OrdinalIgnoreCase))){
            Console.WriteLine($"Vehicle with registration number {registrationNo} is already parked");
            return;
        }
        if (!type.Equals("motor", StringComparison.OrdinalIgnoreCase) && 
            !type.Equals("mobil", StringComparison.OrdinalIgnoreCase)){
            Console.WriteLine("Invalid vehicle type. Only 'motor' and 'mobil' are allowed.");
            return;
        }        
        int vacantSlot = Enumerable.Range(1, totalVacant).First(i => !parkingLots.ContainsKey(i));
        parkingLots[vacantSlot] = new Vehicle(registrationNo, color, type);
        Console.WriteLine($"Allocated slot number: {vacantSlot}");
    }

    public void Leave(int parkingLot){
        if(parkingLots.ContainsKey(parkingLot)){
            if (Util.GetHoursDifference(parkingLots[parkingLot].Timestamp) <= 1){
                if (parkingLots[parkingLot].Type.Equals("motor", StringComparison.OrdinalIgnoreCase)){
                    Console.WriteLine(
                        $"Vehicle with registration number {parkingLots[parkingLot].RegistrationNo} has already left the parking lot.\nStay duration: 1 hour\nParking fee: Rp{1 * 3000}"
                    );
                } else
                {
                    Console.WriteLine(
                        $"Vehicle with registration number {parkingLots[parkingLot].RegistrationNo} has already left the parking lot.\nStay duration: 1 hour\nParking fee: Rp{1 * 10000}"
                    );
                }
                parkingLots.Remove(parkingLot);
            } else{
                if (parkingLots[parkingLot].Type.Equals("motor", StringComparison.OrdinalIgnoreCase)){
                    Console.WriteLine(
                        $"Vehicle with registration number {parkingLots[parkingLot].RegistrationNo} has already left the parking lot.\nStay duration: {Util.GetHoursDifference(parkingLots[parkingLot].Timestamp)} hours\nParking fee: Rp{Util.GetHoursDifference(parkingLots[parkingLot].Timestamp) * 3000}"
                    );
                } else
                {
                    Console.WriteLine(
                        $"Vehicle with registration number {parkingLots[parkingLot].RegistrationNo} has already left the parking lot.\nStay duration: {Util.GetHoursDifference(parkingLots[parkingLot].Timestamp)} hours\nParking fee: Rp{Util.GetHoursDifference(parkingLots[parkingLot].Timestamp) * 10000}"
                    );
                }
                parkingLots.Remove(parkingLot);
            }
            Console.WriteLine($"Slot number {parkingLot} is free");
            return;
        }
    }

    public void Status(){
        Console.WriteLine("Slot\tRegistration No\tType\tColor\tTimestamp");
        foreach(var parkingLot in parkingLots.OrderBy(s => s.Key)){
            var vehicle = parkingLot.Value;
            Console.WriteLine($"{parkingLot.Key}\t{vehicle.RegistrationNo}\t{vehicle.Type}\t{vehicle.Color}\t{vehicle.Timestamp}");
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