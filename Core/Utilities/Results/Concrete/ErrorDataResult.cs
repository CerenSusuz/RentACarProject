using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class ErrorDataResult<TEntity>: DataResult<TEntity>
    {
        // result has data so return this data
        public ErrorDataResult(TEntity data, string message): base(data,false,message)
        {
                
        }
        public ErrorDataResult(TEntity data): base(data,false)
        {
                
        }

        // result has NOT data so return default
        public ErrorDataResult(string message) : base(default,false,message)
        {

        }
        public ErrorDataResult() :  base(default,false)
        {

        }
    }
}
