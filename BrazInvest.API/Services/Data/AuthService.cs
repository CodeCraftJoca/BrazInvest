//using System;

//public class AuthService
//{
//     private readonly List<User> User;

//    public AuthService()
//    {
//        // Inicializa com alguns usuários de exemplo (isso pode ser substituído por uma fonte de dados real)
//        users = new List<User>
//        {
//        new User { UserId = 1, Username = "admin", PasswordHash = HashPassword("admin@123") },
//        new User { UserId = 2, Username = "user", PasswordHash = HashPassword("user@123") }
//        };
//    }

//    public List<User> User1 => User;

//    public User AuthenticateUser(string username, string password)
//        {
//            // Verifica se o usuário existe e a senha está correta
//            var user = users.FirstOrDefault(u => u.Username == username && VerifyPassword(password, u.PasswordHash));
//            return user;
//        }

//        // Métodos auxiliares para hash de senha (usando métodos de exemplo, em produção, use bibliotecas apropriadas)
//    private string HashPassword(string password)
//        {
//            // Lógica de hash de senha aqui (exemplo: não use esta implementação em produção)
//            return password.GetHashCode().ToString();
//        }

//        private bool VerifyPassword(string inputPassword, string storedHash)
//        {
//            // Lógica de verificação de senha aqui (exemplo: não use esta implementação em produção)
//            return storedHash == inputPassword.GetHashCode().ToString();
//        }
//    }


//}
