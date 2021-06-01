using ServiceLayer.Models;

namespace ServiceLayer.Interface
{
    public interface IJWTToken
    {
        string GenerateJWTToken(UserDTO userDTO);
    }
}
