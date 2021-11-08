using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace CodersLinkAssignment.Aplication.Exeptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; }
        public ValidationException() : base("Se producieron uno o mas errores de validación.")
        {
            Errors = new List<string>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
}
