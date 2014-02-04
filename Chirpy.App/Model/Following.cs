namespace Chirpy.App.Model
{
    public class Following
    {
        public string User { get; set; }
        public string Follows { get; set; }

        public Following(string user, string follows)
        {
            User = user;
            Follows = follows;
        }
    }
}