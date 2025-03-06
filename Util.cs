using System;
using System.Linq;

static class Util {
    public static bool IsOddRegNo(string registrationNo){
        var digits = new string(registrationNo.Where(char.IsDigit).ToArray());
        return digits.Length > 0 && int.Parse(digits.Last().ToString()) % 2 != 0;
    }

    public static int GetHoursDifference(string timestamp){
        DateTime dateTime = DateTime.Parse(timestamp);
        TimeSpan difference = DateTime.Now - dateTime;
        return (int)difference.TotalHours;
    }    
}