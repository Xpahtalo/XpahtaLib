using System.Diagnostics.CodeAnalysis;
using Dalamud.Interface.Windowing;
using XpahtaLib.DalamudUtilities.Interfaces;

namespace XpahtaLib.UserInterface;

[SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
public sealed class WindowManager : IDisposable
{
    private WindowSystem  WindowSystem { get; }
    private IPluginLogger Log          { get; }

    public WindowManager(string pluginName, IPluginLogger pluginLogger)
    {
        WindowSystem = new WindowSystem(pluginName);
        Log          = pluginLogger;
    }

    private bool GetWindowByName(string name, [NotNullWhen(true)] out Window? window)
    {
        var matching = from storedWindow in WindowSystem.Windows
                       where storedWindow.WindowName == name
                       select storedWindow;
        var enumerable = matching.ToList();
        switch (enumerable.Count) {
            case > 1:
                Log.Error("Found multiple windows with name {0}", name);
                window = null;
                return false;
            case 0:
                window = null;
                return false;
            default:
                window = enumerable.First();
                return true;
        }
    }

    public bool AddWindow(Window window)
    {
        if (GetWindowByName(window.WindowName, out _)) {
            Log.Error("Window with name {0} already exists. Cannot add.", window.WindowName);
            return false;
        }

        Log.Info("Adding window {0}", window.WindowName);
        WindowSystem.AddWindow(window);
        return true;
    }

    public bool RemoveWindow(string name)
    {
        if (!GetWindowByName(name, out var window)) {
            Log.Error("Unable to find window with name {0} to remove.", name);
            return false;
        }

        Log.Info("Removing window {0}", name);
        WindowSystem.RemoveWindow(window);
        var disposable = window as IDisposable;
        disposable?.Dispose();
        return true;
    }

    public bool RemoveWindow(Window window) => RemoveWindow(window.WindowName);

    public bool OpenWindow(string name)
    {
        if (!GetWindowByName(name, out var window)) {
            Log.Error("Unable to find window with name {0} to open.", name);
            return false;
        }

        Log.Info("Opening window {0}", name);
        window.IsOpen = true;
        window.BringToFront();
        return true;
    }

    public bool CloseWindow(string name)
    {
        if (!GetWindowByName(name, out var window)) {
            Log.Error("Unable to find window with name {0} to close.", name);
            return false;
        }

        Log.Info("Closing window {0}", name);
        window.IsOpen = false;
        return true;
    }

    public bool ToggleWindow(string name)
    {
        if (!GetWindowByName(name, out var window)) {
            Log.Error("Unable to find window with name {0} to toggle.", name);
            return false;
        }

        Log.Info("Toggling window {0}", name);
        window.IsOpen = !window.IsOpen;
        return true;
    }

    public void Draw() => WindowSystem.Draw();

    public void Dispose()
    {
        var toDispose =
            from window in WindowSystem.Windows
            where window is IDisposable
            select window as IDisposable;
        WindowSystem.RemoveAllWindows();
        toDispose.ToList().ForEach(disposable => disposable.Dispose());
    }
}
