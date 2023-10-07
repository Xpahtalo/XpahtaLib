using Dalamud.Interface.Utility.Raii;
using ImGuiNET;

namespace XpahtaLib.UserInterface;

public class Button: ImGuiWidget
{
    private string _label;

    public delegate void         ButtonPressed();
    private event ButtonPressed? Pressed;

    public Button(string label, ButtonPressed buttonPressed)
    {
        _label  =  label;
        Pressed += buttonPressed;
    }

    public void Draw()
    {
        if (ImGui.Button($"{_label}##{Id}"))
            Pressed?.Invoke();
    }
}