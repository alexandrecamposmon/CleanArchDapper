namespace CleanCodeDapper.ApplicationCore.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
    }
    public static class SecretSettings
    {
        public static string Secret = "SEGREDO_DE_ESTADO";
    }
}
