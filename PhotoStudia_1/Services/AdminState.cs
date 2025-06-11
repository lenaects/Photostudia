namespace PhotoStudia_1.Services
{public class AdminState
{
    public int AdminId { get; private set; }
    public string AdminName { get; private set; } = string.Empty;
    public bool IsLoggedIn => AdminId > 0;

    public void SetAdmin(int adminId, string adminName)
    {
        AdminId = adminId;
        AdminName = adminName;
    }

    public void Logout()
    {
        AdminId = 0;
        AdminName = string.Empty;
    }
}

}

