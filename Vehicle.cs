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

    public string Timestamp { 
        get; 
        } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

    public Vehicle(string registrationNo, string color, string type){
        RegistrationNo = registrationNo;
        Color = color;
        Type = type;
    }
}