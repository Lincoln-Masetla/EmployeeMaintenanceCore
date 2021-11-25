using EmployeeMaintenance.Domain.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMaintenance.Domain.Commands
{
    public abstract class DomainCommand<T>
    {

        protected DomainContext Context { get; private set; }

        public bool IsVerified { get; private set; }



        protected DomainCommand(DomainContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<T> ExecuteAsync()
        {
            return Task.Run(async () =>
            {
                try
                {
                    VerifyCommandState();


                    return await ExecuteInternal();
                }
                catch (CommandStateVerificationException ex)
                {
                    throw ex;
                }

                catch (Exception ex)
                {
                    throw new CommandExecutionException(ex);
                }
            });
        }


        private void VerifyCommandState()
        {
            if (!IsVerified)
            {
                if (!VerifyStateInternal())
                {
                    throw new CommandStateVerificationException($"An error occurred verifying the {GetType()} state.");
                }

                IsVerified = true;
            }
        }

        protected abstract bool VerifyStateInternal();

        protected abstract Task<T> ExecuteInternal();
    }

    /// <summary>
    /// Represents an exception that is thrown by a domain command when encountering an exception within the scope of execution
    /// </summary>
    public class CommandExecutionException : Exception
    {
        public CommandExecutionException( Exception innerException)
          : this($"An error occurred executing the command", innerException)
        {

        }

        public CommandExecutionException(string message, Exception innerException)
            : base($"{message}", innerException)
        {
        }

        public CommandExecutionException( string message)
          : base(message)
        {
        }
    }

    public class CommandStateVerificationException : Exception
    {
        public CommandStateVerificationException(string message)
        : base($"{message})")
        {
        }
    }
}
