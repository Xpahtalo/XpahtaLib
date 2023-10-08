using ImGuiNET;

namespace XpahtaLib.UserInterface.Input;

public class TextInput: ImGuiWidget
{
    private readonly string         _defaultLabel;
    private readonly uint           _bufferSize;
    private readonly Action<string> _onTextChanged;

    public TextInput(
        string         defaultLabel,
        uint           bufferSize,
        Action<string> onTextChanged)
    {
        _defaultLabel  = defaultLabel;
        _bufferSize    = bufferSize;
        _onTextChanged = onTextChanged;
    }

    public void Draw(string text) => Draw(text, _defaultLabel);

    public void Draw(string text, string label)
    {
        if (ImGui.InputText($"{label}##{Id}", ref text, _bufferSize))
            _onTextChanged(text);
    }
}
