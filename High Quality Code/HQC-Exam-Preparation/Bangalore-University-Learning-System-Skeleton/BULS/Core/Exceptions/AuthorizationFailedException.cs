namespace BangaloreUniversityLearningSystem.Core.Exceptions
{
    using System;

    public class AuthorizationFailedException: Exception
    {
        public AuthorizationFailedException()
        {
        }

        public AuthorizationFailedException(string message)
        {           
        }
    }
}