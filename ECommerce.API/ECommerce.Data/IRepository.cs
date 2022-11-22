using Models;

namespace Data
{
    public interface IRepository
    {
        /* Create */
        void RegisterNewUser(User userInfo);

        /* Read */
        bool EmailTaken(string email);
        User? VerifyCredentials(string email, string password);

        /* Update */

        /* Destroy */
    }
}