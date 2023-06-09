using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace SFM.VehicleBuilder.Application.Exceptions
{
    /// <summary>
    ///   The exception that is thrown when a command or query is invalid.
    /// </summary>
    [Serializable]
    public class InvalidCommandOrQueryException : BaseApplicationException
    {
        [NonSerialized]
        private const string DefaultMessage = "The command or query is invalid.";

        [NonSerialized]
        private const int DefaultStatusCode = 400;

        [NonSerialized]
        private static readonly string ValidationErrorsKey = $"{typeof(InvalidCommandOrQueryException).FullName}.ValidationMessages";

        /// <summary>
        ///   Initializes a new instance of the <see cref="InvalidCommandOrQueryException"/> class.
        /// </summary>
        public InvalidCommandOrQueryException()
            : base(DefaultStatusCode, DefaultMessage, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="InvalidCommandOrQueryException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains why the exception occurred.</param>
        public InvalidCommandOrQueryException(string message)
            : base(DefaultStatusCode, message ?? DefaultMessage, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="InvalidCommandOrQueryException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains why the exception occurred.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public InvalidCommandOrQueryException(string message, Exception innerException)
            : base(DefaultStatusCode, message ?? DefaultMessage, innerException)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="InvalidCommandOrQueryException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains why the exception occurred.</param>
        /// <param name="validationErrors">A collection of validation error messages.</param>
        public InvalidCommandOrQueryException(string message, IEnumerable<string> validationErrors)
            : base(DefaultStatusCode, message ?? DefaultMessage, null)
        {
            ValidationErrors = validationErrors?.ToList() ?? new List<string>();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="InvalidCommandOrQueryException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains why the exception occurred.</param>
        /// <param name="validationErrors">A collection of validation error messages.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public InvalidCommandOrQueryException(string message, IEnumerable<string> validationErrors, Exception innerException)
            : base(DefaultStatusCode, message ?? DefaultMessage, innerException)
        {
            ValidationErrors = validationErrors?.ToList() ?? new List<string>();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="InvalidCommandOrQueryException"/> class.
        /// </summary>
        /// <param name="info">Holds the serialized object data.</param>
        /// <param name="context">Contains contextual information about the serialization.</param>
        protected InvalidCommandOrQueryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        ///   Gets or sets the validation error messagess.
        /// </summary>
        public IEnumerable<string> ValidationErrors
        {
            get
            {
                return Data.Contains(ValidationErrorsKey)
                    ? (IEnumerable<string>)Data[ValidationErrorsKey]
                    : Enumerable.Empty<string>();
            }

            protected internal set
            {
                Data[ValidationErrorsKey] = value;
            }
        }
    }
}