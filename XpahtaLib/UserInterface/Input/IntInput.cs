using ImGuiNET;

namespace XpahtaLib.UserInterface.Input;

public class IntInput: ImGuiWidget
{
    private readonly string      _defaultLabel;
    private readonly int         _steps;
    private readonly Action<int> _onValueChanged;

    public IntInput(
        string      defaultLabel,
        Action<int> onValueChanged,
        int         steps = 1)
    {
        _defaultLabel   = defaultLabel;
        _onValueChanged = onValueChanged;
        _steps          = steps;
    }

    public void Draw(int value) => Draw(value, _defaultLabel);

    public void Draw(int value, string label)
    {
        if (ImGui.InputInt($"{label}###{Id}", ref value, _steps))
            _onValueChanged(value);
    }
}
