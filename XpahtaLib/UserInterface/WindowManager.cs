using System.Diagnostics.CodeAnalysis;
using Dalamud.Interface.Windowing;
using XpahtaLib.DalamudUtilities.Interfaces;

namespace XpahtaLib.UserInterface;

[SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
public class WindowManager : IDisposable
{
    private readonly bool                       _disposed = false;
    protected        Dictionary<string, Window> Windows      { get; } = new();
    protected        WindowSystem               WindowSystem { get; }
    protected        IPluginLogger              Log          { get; }

    public WindowManager(string pluginName, IPluginLogger pluginLogger)
    {
        WindowSystem = new WindowSystem(pluginName);
        Log          = pluginLogger;
    }

    public bool GetWindowByName(string name, [NotNullWhen(true)] out Window? window) => Windows.TryGetValue(name, out window);

    public bool AddWindow(Window window)
    {
        if (GetWindowByName(window.WindowName, out _)) {
            Log.Error("Window with name {0} already exists. Cannot add.", window.WindowName);
            return false;
        }

        Log.Info("Adding window {0}", window.WindowName);
        Windows.Add(window.WindowName, window);
        WindowSystem.AddWindow(window);
        return true;
    }

    public bool RemoveWindow(string name)
    {
        if (!GetWindowByName(name, out var window)) {
            throw new ArgumentOutOfRangeException(nameof(name), name, "Unable to find window with given name to remove.") {
                Source = "XpahtaLib.WindowManager.RemoveWindow",
                Data = {
                    { "WindowNames", Windows.Keys },
                },
            };
        }

        return RemoveWindow(window);
    }

    public bool RemoveWindow(Window window)
    {
        Log.Info("Removing window {0}", window.WindowName);
        WindowSystem.RemoveWindow(window);
        Windows.Remove(window.WindowName);
        var disposable = window as IDisposable;
        disposable?.Dispose();
        return true;
    }

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

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed) {
            if (disposing) {
                WindowSystem.RemoveAllWindows();

                foreach (var disposable in Windows.Values.OfType<IDisposable>()) {
                    disposable.Dispose();
                }
            }
        }
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
