using System;

namespace ValidateConfig.Exceptions
{
    public class InvalidConfigurationException : Exception
    {
        public InvalidConfigurationException(Type configurationType, string message) : base(message)
        {
            ConfigurationType = configurationType;
        }

        public Type ConfigurationType { get; }
    }
}