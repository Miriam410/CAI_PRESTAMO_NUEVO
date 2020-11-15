using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Entidades
{
    public class TransactionResult
    {
        private bool _isOk;
        private string _error;
        private int _id;

        public bool IsOk
        {
            get { return _isOk; }
            set { _isOk = value; }
        }

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
