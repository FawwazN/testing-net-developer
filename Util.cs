static class Util {
    public static bool IsOddRegNo(string registrationNo){
        var digits = new string(registrationNo.Where(char.IsDigit).ToArray());
        return digits.Length > 0 && int.Parse(digits.Last().ToString()) % 2 != 0;
    }
}