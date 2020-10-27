namespace SufferShopUI.Menus
{
    /// <summary>
    /// A basic menu interface.
    /// </summary>
    public interface IMenu
    {

        /// <summary>
        /// Starting point of menus
        /// </summary>
        abstract void Start();

        /// <summary>
        /// This method generates a list of user prompts using a list of strings input as a parameter.
        /// </summary>
        abstract void QueryUserChoice();

        public void Run();

        abstract void ExecuteUserChoice();

    }
}