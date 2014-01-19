using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEW.Core.Interfaces.ApplicationServices
{
    public interface ICryptoService
    {
        string CreateHash(int input);
        string CreateHash(string input);
        bool CompareHash(string input, string hash);
        bool CompareHash(int input, string hash);
        string Encrypt(string input);
        string Encrypt(int input);
        string Decrypt(string input);
        string Decrypt(int input);
        string GeneratePassword();
        string GeneratePassword(int minLength, int maxLength);
    }
}
