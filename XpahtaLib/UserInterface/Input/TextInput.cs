using ImGuiNET;

namespace XpahtaLib.UserInterface.Input;

public class TextInput : ImGuiWidget
{
    private string              DefaultLabel  { get; }
    private uint                BufferSize    { get; }
    private Action<string>      OnTextChanged { get; }
    private HelpMarker?         Marker        { get; }
    private ImGuiInputTextFlags Flags         { get; }

    public TextInput(
        string              defaultLabel,
        uint                bufferSize,
        Action<string>      onTextChanged,
        string?             helpText = null,
        ImGuiInputTextFlags flags    = ImGuiInputTextFlags.None)
    {
        DefaultLabel  = defaultLabel;
        BufferSize    = bufferSize;
        OnTextChanged = onTextChanged;
        Marker        = helpText is null ? null : new HelpMarker(helpText);
        Flags         = flags;
    }

    public void Draw(string text) => Draw(text, DefaultLabel);

    public void Draw(string text, string label)
    {
        if (ImGui.InputText($"{label}##{Id}", ref text, BufferSize, Flags)) {
            OnTextChanged(text);
        }

        if (Marker is null) {
            return;
        }

        ImGui.SameLine();
        Marker.Draw();
    }
}
