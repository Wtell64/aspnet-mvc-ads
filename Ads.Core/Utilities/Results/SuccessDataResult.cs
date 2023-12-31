﻿namespace App.Core.Utilities.Results
{
  public class SuccessDataResult<T> : DataResult<T>
  {


    public SuccessDataResult(T data, string message) : base(data, true, message)
    {

    }

    public SuccessDataResult(T data) : base(data, true)
    {

    }

    public SuccessDataResult(string message) : base(default, true, message) //default data karsilik geliyor
    {

    }


    /*       public SuccessDataResult(FluentValidation.Results.ValidationResult validationResult) : base(default,true)
           {


           }*/

  }
}
