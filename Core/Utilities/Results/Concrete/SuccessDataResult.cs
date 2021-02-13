using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessDataResult<TEntity> : DataResult<TEntity>
    {
        public SuccessDataResult(TEntity data,string message) :  base(data,true,message)
        {
                
        }
        public SuccessDataResult(TEntity data) : base(data,true)
        {

        }
        public SuccessDataResult(string message) : base(default,true,message)
        {

        }
        public SuccessDataResult() : base(default,true)
        {

        }
    }
}
