class Vehicle{
    public string RegistrationNo { 
        get; 
        }
    public string Color { 
        get; 
        }
    public string Type { 
        get; 
    }

    public Vehicle(string registrationNo, string color, string type){
        RegistrationNo = registrationNo;
        Color = color;
        Type = type;
    }
}