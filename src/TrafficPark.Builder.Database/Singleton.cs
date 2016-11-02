using System;


namespace WareSign.Core.ApiIntegrationTests
{
    /// <summary>
    /// A generic singleton.
    /// </summary>
    public sealed class Singleton<T> where T: class, new()
    {
        /// <summary>
        /// The singleton instance value.
        /// </summary>
        private static readonly Lazy<T> instance = new Lazy<T>(() => new T());

        /// <summary>
        /// The unique, singleton instance.
        /// </summary>
        public static T Instance
        {
            get { return instance.Value; }
        }

        /// <summary>
        /// A private constructor, this class cannot be constructed.
        /// </summary>
        private Singleton() { }
    }
}
