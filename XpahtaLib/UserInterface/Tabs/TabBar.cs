using Dalamud.Interface.Utility.Raii;

namespace XpahtaLib.UserInterface.Tabs;

public class TabBar: IDisposable
{
    public required string Name { get; set; }
    // ReSharper disable once CollectionNeverUpdated.Global
    public required List<TabBase> Tabs { get; set; }

    public void Draw()
    {
        using var tabBar = ImRaii.TabBar(Name);
        if (!tabBar)
            return;
        for (var i = 0; i < Tabs.Count; i++){
            using var id = ImRaii.PushId(i);
            Tabs[i].Draw();
        }
    }



    protected virtual void Dispose(bool disposing)
    {
        if (!disposing)
            return;
        foreach (var tab in Tabs){
            tab.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
