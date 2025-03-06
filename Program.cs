#nullable enable
using System;

namespace ConsoleApp1{
    class Program{

    static void Main(){
        ParkingLotService? parkingLot = null;
        while(true){
            var input = Console.ReadLine();
            if(input == "exit") break;
            if (input == null) continue;
            var command = input.Split(' ');
            switch(command[0]){
                case "create_parking_lot":
                    parkingLot = new ParkingLotService(int.Parse(command[1]));
                    break;
                case "park":
                    if (parkingLot == null) {
                        Console.WriteLine("Parking lot is not created yet");
                        continue;
                    }
                    parkingLot.Park(command[1], command[2], command[3]);
                    break;
                case "leave":
                    if (parkingLot == null) {
                        Console.WriteLine("Parking lot is not created yet");
                        continue;
                    }
                    parkingLot.Leave(int.Parse(command[1]));
                    break;
                case "status":
                    if (parkingLot == null) {
                        Console.WriteLine("Parking lot is not created yet");
                        continue;
                    }
                    parkingLot.Status();
                    break;
                case "type_of_vehicles":
                    if (parkingLot == null) {
                        Console.WriteLine("Parking lot is not created yet");
                        continue;
                    }
                    parkingLot.VehicleType(command[1]);
                    break;
                case "registration_numbers_for_vehicles_with_odd_plate":
                    if (parkingLot == null) {
                        Console.WriteLine("Parking lot is not created yet");
                        continue;
                    }
                    parkingLot.OddNumberVehicle();
                    break;
                case "registration_numbers_for_vehicles_with_even_plate":
                    if (parkingLot == null) {
                        Console.WriteLine("Parking lot is not created yet");
                        continue;
                    }
                    parkingLot.EvenNumberVehicle();
                    break;
                case "registration_numbers_for_vehicles_with_colour":
                    if (parkingLot == null) {
                        Console.WriteLine("Parking lot is not created yet");
                        continue;
                    }
                    parkingLot.VehiclesWithColor(command[1]);
                    break;
                case "slot_number_for_registration_number":
                    if (parkingLot == null) {
                        Console.WriteLine("Parking lot is not created yet");
                        continue;
                    }
                    parkingLot.SlotNumberWithRegistrationNo(command[1]);
                    break;
                case "slot_numbers_for_vehicles_with_colour":
                    if (parkingLot == null) {
                        Console.WriteLine("Parking lot is not created yet");
                        continue;
                    }
                    parkingLot.SlotNumbersWithColor(command[1]);
                    break;
            }
        }
    }
}

}
