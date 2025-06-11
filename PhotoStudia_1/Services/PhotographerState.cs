namespace PhotoStudia_1.Services
{
    public class PhotographerState
    {
        public int PhotographerId { get; private set; }
        public string PhotographerName { get; private set; } = string.Empty;
        public bool IsLoggedIn => PhotographerId > 0;

        public void SetPhotographer(int photographerId, string photographerName)
        {
            PhotographerId = photographerId;
            PhotographerName = photographerName;
        }

        public void Logout()
        {
            PhotographerId = 0;
            PhotographerName = string.Empty;
        }
    }
}
