namespace PetShopQa.Messages
{
    public static class AssertMsg
    {
        public static string ResponseIsSuccessful() => "Result code isn't Success";
        public static string ResponseIsUnsuccessful() => "Result code isn't BadRequest";
        public static string ParameterIsEmpty(string parameter) => $"{parameter} is empty";
        public static string ParameterIsWrong(string parameter) => $"{parameter} is wrong";
    }
}