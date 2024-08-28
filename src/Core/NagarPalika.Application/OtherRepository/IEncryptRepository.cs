using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.OtherRepository
{
    public interface IEncryptRepository
    {
        string Encrypt(string str);
        string Decrypt(string encrypted);
    }
}
