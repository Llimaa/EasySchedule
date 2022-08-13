using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace EasySchedule.Application.Core.Extensions
{
    public static class ValidationFailureExtensions
    {
        public static void Deconstruct(this ValidationFailure result, out string key, out string value) =>
       (key, value) = (result.ErrorCode, result.ErrorMessage);
    }
}