using System;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

[assembly: AssemblyCompany("TrafficPark contributors")]
[assembly: AssemblyProduct("TrafficPark")]
[assembly: AssemblyCopyright("Copyright © TrafficPark contributors. All Rights Reserved.")]
[assembly: AssemblyTrademark("TrafficPark contributors")]

[assembly: NeutralResourcesLanguage("en-US")]

//Whether this is a debug or a release build.
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
[assembly: AssemblyDescription("Build = Debug")]
#else
[assembly: AssemblyConfiguration("Production")]
[assembly: AssemblyDescription("Build = Production")]
#endif

[assembly: CLSCompliant(true)]

//This is the "product version".
[assembly: AssemblyInformationalVersion("1.0.0.0")]