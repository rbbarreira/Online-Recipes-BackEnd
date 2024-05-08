namespace Online_Recipes_Domain.Account
{
    public class UserToken
    {
        // Recebe e guarda o Token do LOGIN
        public string Token { get; set; }

        public string UserName { get; set; }

        public string Role { get; set; }
    }
}
