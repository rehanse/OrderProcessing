using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.DataAccess.Application.Contracts.Persistence
{
    public interface IUserAuthenticationService
    {
        Task<ResponseStatus> LoginAsync(LoginModel model);
        Task<ResponseStatus> LogoutAsync();
        Task<ResponseStatus> RegisterAsync(RegisterModel model);
    }
}
