using Dalamud.Interface.Utility.Raii;
using ImGuiNET;

namespace XpahtaLib.UserInterface.Tabs;

public abstract class TabBase : IDisposable
{
    public abstract string Name { get; }
    
    public virtual void Draw()
    {
        using var tab = ImRaii.TabItem(Name);
        if (!tab)
            return;
        DrawTab();
    }

    protected virtual void DrawTab() { ImGui.Text("Not implemented yet."); }

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
