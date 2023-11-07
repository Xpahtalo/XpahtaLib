using ImGuiNET;

namespace XpahtaLib.UserInterface.Input;

public class TextInput: ImGuiWidget
{
    private readonly string              _defaultLabel;
    private readonly uint                _bufferSize;
    private readonly Action<string>      _onTextChanged;
    private readonly HelpMarker?         _helpMarker;
    private readonly ImGuiInputTextFlags _flags;

    public TextInput(
        string              defaultLabel,
        uint                bufferSize,
        Action<string>      onTextChanged,
        string?             helpText = null,
        ImGuiInputTextFlags flags    = ImGuiInputTextFlags.None)
    {
        _defaultLabel  = defaultLabel;
        _bufferSize    = bufferSize;
        _onTextChanged = onTextChanged;
        _helpMarker    = helpText is null ? null : new HelpMarker(helpText);
        _flags         = flags;
    }

    public void Draw(string text) => Draw(text, _defaultLabel);

    public void Draw(string text, string label)
    {
        if (ImGui.InputText($"{label}##{Id}", ref text, _bufferSize, _flags))
            _onTextChanged(text);

        if (_helpMarker is null)
            return;
        ImGui.SameLine();
        _helpMarker.Draw();
    }
}
