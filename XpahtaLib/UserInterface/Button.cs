using ImGuiNET;

namespace XpahtaLib.UserInterface;

public class Button : ImGuiWidget
{
    private string DefaultLabel { get; }

    public delegate void         ButtonPressed();
    private event ButtonPressed? Pressed;

    public Button(string defaultLabel, ButtonPressed buttonPressed)
    {
        DefaultLabel =  defaultLabel;
        Pressed      += buttonPressed;
    }

    public void Draw() => Draw(DefaultLabel);

    public void Draw(string label)
    {
        if (ImGui.Button($"{label}##{Id}")) {
            Pressed?.Invoke();
        }
    }
}
