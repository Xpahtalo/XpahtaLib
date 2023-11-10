using Dalamud.Interface.Utility.Raii;

namespace XpahtaLib.UserInterface.Tabs;

public abstract class TabBase : IDisposable
{
    protected abstract string TabName { get; }

    public virtual void Draw()
    {
        using var tab = ImRaii.TabItem(TabName);
        if (!tab) {
            return;
        }

        DrawTab();
    }

    protected abstract void DrawTab();

    public virtual void OnOpen() { }

    public virtual void OnClose() { }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing) { }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
