using ImGuiNET;

namespace XpahtaLib.UserInterface.Input;

public class FloatSlider : ImGuiWidget
{
    private string        DefaultLabel   { get; }
    private float         Min            { get; }
    private float         Max            { get; }
    private string        Format         { get; }
    private Action<float> OnValueChanged { get; }

    public FloatSlider(
        string        defaultLabel,
        float         min,
        float         max,
        string        format,
        Action<float> onValueChanged)
    {
        DefaultLabel   = defaultLabel;
        Min            = min;
        Max            = max;
        Format         = format;
        OnValueChanged = onValueChanged;
    }

    public void Draw(float value) => Draw(value, DefaultLabel);

    public void Draw(float value, string label)
    {
        if (ImGui.SliderFloat($"{label}###{Id}", ref value, Min, Max, Format)) {
            OnValueChanged(value);
        }
    }
}
