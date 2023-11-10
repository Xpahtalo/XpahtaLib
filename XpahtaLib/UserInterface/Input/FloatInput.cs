using ImGuiNET;

namespace XpahtaLib.UserInterface.Input;

public class FloatInput : ImGuiWidget
{
    private string        DefaultLabel   { get; }
    private float         Min            { get; }
    private float         Max            { get; }
    private Action<float> OnValueChanged { get; }

    public FloatInput(
        string        defaultLabel,
        float         min,
        float         max,
        Action<float> onValueChanged)
    {
        DefaultLabel   = defaultLabel;
        Min            = min;
        Max            = max;
        OnValueChanged = onValueChanged;
    }

    public void Draw(float value) => Draw(value, DefaultLabel);

    public void Draw(float value, string label)
    {
        if (ImGui.SliderFloat($"{label}##{Id}", ref value, Min, Max)) {
            OnValueChanged(value);
        }
    }
}
