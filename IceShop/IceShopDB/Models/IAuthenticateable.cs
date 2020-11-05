namespace IceShopDB.Models
{
    interface IAuthenticateable
    {


        string Email { get; set; }

        string Password { get; set; }
    }
}
