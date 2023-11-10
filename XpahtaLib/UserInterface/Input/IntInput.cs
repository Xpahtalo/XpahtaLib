using ImGuiNET;

namespace XpahtaLib.UserInterface.Input;

public class IntInput : ImGuiWidget
{
    private string      DefaultLabel   { get; }
    private int         Steps          { get; }
    private Action<int> OnValueChanged { get; }

    public IntInput(
        string      defaultLabel,
        Action<int> onValueChanged,
        int         steps = 1)
    {
        DefaultLabel   = defaultLabel;
        OnValueChanged = onValueChanged;
        Steps          = steps;
    }

    public void Draw(int value) => Draw(value, DefaultLabel);

    public void Draw(int value, string label)
    {
        if (ImGui.InputInt($"{label}###{Id}", ref value, Steps)) {
            OnValueChanged(value);
        }
    }
}
