Error:
DependencyResolutionException: No scope with a tag matching 'AutofacWebRequest' is visible from the scope in which the instance was requested. If you see this during execution of a web application, it generally indicates that a component registered as per-HTTP request is being requested by a SingleInstance() component (or a similar scenario). Under the web integration always request dependencies from the dependency resolver or the request lifetime scope, never from the container itself.




An unhandled exception occurred while processing the request.
DependencyResolutionException: No scope with a tag matching 'AutofacWebRequest' is visible from the scope in which the instance was requested.

If you see this during execution of a web application, it generally indicates that a component registered as per-HTTP request is being requested by a SingleInstance() component (or a similar scenario). Under the web integration always request dependencies from the dependency resolver or the request lifetime scope, never from the container itself.
Autofac.Core.Lifetime.MatchingScopeLifetime.FindScope(ISharingLifetimeScope mostNestedVisibleScope)

DependencyResolutionException: Unable to resolve the type 'SampleArch.Repository.UnitOfWork' because the lifetime scope it belongs in can't be located. The following services are exposed by this registration:
- SampleArch.Repository.Interface.IUnitOfW