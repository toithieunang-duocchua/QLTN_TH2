namespace QLTN.Forms
{
    /// <summary>
    /// Provides a hook for cached authentication views to reset their state
    /// right before they are displayed inside the shared shell.
    /// </summary>
    internal interface IAuthView
    {
        void PrepareForDisplay();
    }
}

