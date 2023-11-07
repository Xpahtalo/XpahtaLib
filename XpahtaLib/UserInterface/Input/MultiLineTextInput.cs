using System.Numerics;
using ImGuiNET;

namespace XpahtaLib.UserInterface.Input;

public class MultiLineTextInput: ImGuiWidget
{
    private readonly string              _defaultLabel;
    private readonly uint                _maxLength;
    private readonly Action<string>      _onTextChanged;
    private readonly HelpMarker?         _helpMarker;
    private readonly ImGuiInputTextFlags _flags;
    private readonly bool                _cleanClipboard;

    public MultiLineTextInput(
        string              defaultLabel,
        Action<string>      onTextChanged,
        uint                maxLength,
        string?             helpText       = null,
        ImGuiInputTextFlags flags          = ImGuiInputTextFlags.None,
        bool                cleanClipboard = false)
    {
        _defaultLabel   = defaultLabel;
        _onTextChanged  = onTextChanged;
        _maxLength      = maxLength;
        _helpMarker     = helpText is null ? null : new HelpMarker(helpText);
        _flags          = flags;
        _cleanClipboard = cleanClipboard;
    }

    public void Draw(string text) => Draw(text, _defaultLabel);

    public void Draw(string text, string label)
    {
        var size = new Vector2 {
            X = ImGui.GetContentRegionAvail().X,
            Y = ImGui.GetTextLineHeight() * GetLinesInString(text) + 7,
        };
        Draw(text, label, size);
    }

    public void Draw(string text, Vector2 size) => Draw(text, _defaultLabel, size);

    public void Draw(string text, string label, Vector2 size)
    {
        if (ImGui.InputTextMultiline($"{label}###{Id}", ref text, _maxLength, size, _flags))
            _onTextChanged.Invoke(text);
        if (_cleanClipboard
         && ImGui.IsItemActive()
         && (ImGui.IsKeyPressed(ImGuiKey.LeftCtrl) || ImGui.IsKeyPressed(ImGuiKey.RightCtrl))){
            var clipboardText = ImGui.GetClipboardText();
            if ((clipboardText.Contains('\r') || clipboardText.Contains('\n')) && !clipboardText.Contains("\r\n"))
                ImGui.SetClipboardText(clipboardText.ReplaceLineEndings("\r\n"));
        }

        if (_helpMarker is null)
            return;
        ImGui.SameLine();
        _helpMarker.Draw();
    }

    private static int GetLinesInString(ReadOnlySpan<char> text)
    {
        var lines = 1;
        foreach (var c in text){
            if (c == '\n')
                lines++;
        }
        return lines;
    }
}
