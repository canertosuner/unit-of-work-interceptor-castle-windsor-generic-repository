using UoW_Sample.Request;

namespace UoW_Sample.Services
{
    public interface IUserService : IApiService
    {
        void AddNewUser(AddNewUserRequest reqModel);
    }
}