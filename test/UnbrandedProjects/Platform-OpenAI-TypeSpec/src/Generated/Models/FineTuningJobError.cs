// <auto-generated/>

#nullable disable

namespace OpenAI.Models
{
    /// <summary> The FineTuningJobError. </summary>
    public partial class FineTuningJobError
    {
        /// <summary> Initializes a new instance of <see cref="FineTuningJobError"/>. </summary>
        internal FineTuningJobError()
        {
        }

        /// <summary> Initializes a new instance of <see cref="FineTuningJobError"/>. </summary>
        /// <param name="message"> A human-readable error message. </param>
        /// <param name="code"> A machine-readable error code. </param>
        /// <param name="param">
        /// The parameter that was invalid, usually `training_file` or `validation_file`. This field
        /// will be null if the failure was not parameter-specific.
        /// </param>
        internal FineTuningJobError(string message, string code, string param)
        {
            Message = message;
            Code = code;
            Param = param;
        }

        /// <summary> A human-readable error message. </summary>
        public string Message { get; }
        /// <summary> A machine-readable error code. </summary>
        public string Code { get; }
        /// <summary>
        /// The parameter that was invalid, usually `training_file` or `validation_file`. This field
        /// will be null if the failure was not parameter-specific.
        /// </summary>
        public string Param { get; }
    }
}
