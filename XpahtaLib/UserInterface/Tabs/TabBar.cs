using Dalamud.Interface.Utility.Raii;
using FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

namespace XpahtaLib.UserInterface.Tabs;

public class TabBar : IDisposable
{
    // ReSharper disable once CollectionNeverUpdated.Global
    public required List<TabBase> Tabs { get; set; }

    public void Draw()
    {
        using var tabBar = ImRaii.TabBar("Main Window Tab Bar");
        if (!tabBar)
            return;
        for (var i = 0; i < Tabs.Count; i++) {
            using var id = ImRaii.PushId(i);
            Tabs[i].Draw();
        }
    }
    
    

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
