# Validate API

This repository shows few implementations about how to validate your configurations in an ASP.NET Core 2.1 application.

## Approaches

The below branches show the approaches taken to validate configurations.

* feature/Config_Validation_At_Startup
  * Validation will not occur in the start up. Meaning the validation will happen only when the first request to the `NotificationsController` receives.
  
* feature/Config_Validation_Using_IStartupFilter
  * Depends on `System.ComponentModel.Annotations`
  * `IsValid` method is no longer required in the `IValidatableConfig` interface since all the validations can be done through the data annotations or even implementing `System.ComponentModel.**DataAnnotations.IValidatableObject` interface.
  * The validations are moved into a separate class `ValidateConfigurationFilter` (a startup filter) which implements `Microsoft.AspNetCore.Hosting.IStartupFilter` interface.

* feature/Config_Validation_Nuget
  * A separate nuget package has been created to register the validatable configurations and which will register the `ValidateConfigurationFilter` just by calling two extension methods.

I have created a nuget package with these findings and you can use it following the instructions below.

* Install the nuget package.

* Register your configurations.