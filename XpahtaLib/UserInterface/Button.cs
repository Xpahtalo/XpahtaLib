using ImGuiNET;

namespace XpahtaLib.UserInterface;

public class Button: ImGuiWidget
{
    private readonly string _defaultLabel;

    public delegate void         ButtonPressed();
    private event ButtonPressed? Pressed;

    public Button(string defaultLabel, ButtonPressed buttonPressed)
    {
        _defaultLabel =  defaultLabel;
        Pressed       += buttonPressed;
    }

    public void Draw() => Draw(_defaultLabel);

    public void Draw(string label)
    {
        if (ImGui.Button($"{label}##{Id}"))
            Pressed?.Invoke();
    }
}
