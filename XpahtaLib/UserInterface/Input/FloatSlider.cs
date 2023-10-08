using ImGuiNET;

namespace XpahtaLib.UserInterface.Input;

public class FloatSlider: ImGuiWidget
{
    private readonly string        _defaultLabel;
    private readonly float         _min;
    private readonly float         _max;
    private readonly string        _format;
    private readonly Action<float> _onValueChanged;

    public FloatSlider(
        string        defaultLabel,
        float         min,
        float         max,
        string        format,
        Action<float> onValueChanged)
    {
        _defaultLabel   = defaultLabel;
        _min            = min;
        _max            = max;
        _format         = format;
        _onValueChanged = onValueChanged;
    }

    public void Draw(float value) => Draw(value, _defaultLabel);

    public void Draw(float value, string label)
    {
        if (ImGui.SliderFloat($"{label}###{Id}", ref value, _min, _max, _format))
            _onValueChanged(value);
    }
}
