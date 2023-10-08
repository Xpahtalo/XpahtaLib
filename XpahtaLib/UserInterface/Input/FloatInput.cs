using ImGuiNET;

namespace XpahtaLib.UserInterface.Input;

public class FloatInput: ImGuiWidget
{
    private readonly string        _defaultLabel;
    private readonly float         _min;
    private readonly float         _max;
    private readonly Action<float> _onValueChanged;

    public FloatInput(
        string        defaultLabel,
        float         min,
        float         max,
        Action<float> onValueChanged)
    {
        _defaultLabel   = defaultLabel;
        _min            = min;
        _max            = max;
        _onValueChanged = onValueChanged;
    }

    public void Draw(float value) => Draw(value, _defaultLabel);

    public void Draw(float value, string label)
    {
        if (ImGui.SliderFloat($"{label}##{Id}", ref value, _min, _max))
            _onValueChanged(value);
    }
}
