using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerManagerFramework
{
    /// <summary>
    /// EventHandler for handling changes of a server ServerManagerFramework.State.
    /// </summary>
    /// <param name="sender">The server that changed its ServerManagerFramework.State.</param>
    /// <param name="e">EventArgs with the new server ServerManagerFramework.State.</param>
    public delegate void StateChangedEventHandler(object sender, StateChangedEventArgs e);
}
