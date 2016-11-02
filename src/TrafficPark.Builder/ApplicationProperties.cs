using Autofac;


namespace TrafficPark.Builder
{
    public static class ApplicationProperties
    {
        public static bool IsInTest { get; set; }

        public static IContainer Container { get; set; }
    }
}
