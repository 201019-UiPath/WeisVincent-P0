namespace SufferShopUI.Menus
{
    /// <summary>
    /// A basic menu interface.
    /// </summary>
    public interface IMenu
    {

        public abstract void SetStartingMessage();
        public abstract void SetUserChoices();

        /// <summary>
        /// Starting point of menus
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// This method generates a list of user prompts using a list of strings input as a parameter.
        /// </summary>
        public abstract void QueryUserChoice();

        public void Run();

        public abstract void ExecuteUserChoice();

    }
}