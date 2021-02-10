using System;
using System.Security.Cryptography;
using System.Text;

namespace Api.Domain.Models
{
    public class UserModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string senha;
        public string Senha
        {
            get { return senha; }
            set
            {
                MD5 md5Hash = MD5.Create();
                byte[] data = md5Hash.ComputeHash(buffer: Encoding.UTF8.GetBytes(value));
                // Cria-se um StringBuilder para recompôr a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop para formatar cada byte como uma String em hexadecimal
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                senha = sBuilder.ToString();
            }
        }


    }
}
