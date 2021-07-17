using ServerManagerFramework.Servers;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ServerManagerFramework.Installing
{
    /// <summary>
    /// A list of all install functions.
    /// </summary>
    public static class Installables
    {
        private static readonly Dictionary<string, Installable> installables = new();

        /// <summary>
        /// Sets the value of an existing installable or adds a new one if none exists.
        /// </summary>
        /// <param name="name">The name of the installable.</param>
        /// <param name="installable">The installable to add.</param>
        public static void SetInstallable(string name, Installable installable)
        {
            Type serverType = installable.ServerType;

            if (!serverType.IsAssignableTo(typeof(IHasDirectory)))
            {
                return;
            }

            ConstructorInfo serverTypeConstructor = serverType.GetConstructor(Array.Empty<Type>());

            if (serverTypeConstructor == null)
            {
                return;
            }

            if (installables.ContainsKey(name))
            {
                installables[name] = installable;
            }
            else
            {
                installables.Add(name, installable);
            }
        }

        /// <summary>
        /// Gets a installable.
        /// </summary>
        /// <param name="name">The name of the installable.</param>
        /// <returns>The installable. Null if none is found.</returns>
        public static Installable GetInstallable(string name)
        {
            if (installables.ContainsKey(name))
            {
                return installables[name];
            }
            else
            {
                return null;
            }
        }
    }
}
