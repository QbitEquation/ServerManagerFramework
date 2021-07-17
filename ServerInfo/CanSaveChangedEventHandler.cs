namespace ServerManagerFramework.ServerInfo
{
    /// <summary>
    /// EventHandler for handling changes of savability of ServerInfoItems.
    /// </summary>
    /// <param name="sender">The item that changed its state.</param>
    /// <param name="e">EventArgs with the new server savability state.</param>
    public delegate void CanSaveChangedEventHandler(object sender, CanSaveChangedEventArgs e);
}
