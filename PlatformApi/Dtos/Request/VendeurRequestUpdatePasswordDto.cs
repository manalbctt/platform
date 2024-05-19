namespace PlatformApi.Dtos.Request
{
    public class VendeurRequestUpdatePasswordDto
    {
        public string password { get; set; }

        public string newPassword { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
