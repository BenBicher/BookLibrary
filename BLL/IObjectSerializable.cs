using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public interface IObjectSerializable<T>
    {
        string Serializ();
        T DeSerializ(string str);

        void DeSerializ_2(string str);
    }
}