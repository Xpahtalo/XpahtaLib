using System.Numerics;
using ImGuiNET;

namespace XpahtaLib.UserInterface.Input;

public class MultiLineTextInput : ImGuiWidget
{
    private string              DefaultLabel   { get; }
    private uint                MaxLength      { get; }
    private Action<string>      OnTextChanged  { get; }
    private HelpMarker?         Marker         { get; }
    private ImGuiInputTextFlags Flags          { get; }
    private bool                CleanClipboard { get; }

    public MultiLineTextInput(
        string              defaultLabel,
        Action<string>      onTextChanged,
        uint                maxLength,
        string?             helpText       = null,
        ImGuiInputTextFlags flags          = ImGuiInputTextFlags.None,
        bool                cleanClipboard = false)
    {
        DefaultLabel   = defaultLabel;
        OnTextChanged  = onTextChanged;
        MaxLength      = maxLength;
        Marker         = helpText is null ? null : new HelpMarker(helpText);
        Flags          = flags;
        CleanClipboard = cleanClipboard;
    }

    public void Draw(string text) => Draw(text, DefaultLabel);

    public void Draw(string text, string label)
    {
        var size = new Vector2 {
            X = ImGui.GetContentRegionAvail().X,
            Y = ImGui.GetTextLineHeight() * GetLinesInString(text) + 7,
        };
        Draw(text, label, size);
    }

    public void Draw(string text, Vector2 size) => Draw(text, DefaultLabel, size);

    public void Draw(string text, string label, Vector2 size)
    {
        if (ImGui.InputTextMultiline($"{label}###{Id}", ref text, MaxLength, size, Flags)) {
            OnTextChanged.Invoke(text);
        }

        if (CleanClipboard
         && ImGui.IsItemActive()
         && (ImGui.IsKeyPressed(ImGuiKey.LeftCtrl) || ImGui.IsKeyPressed(ImGuiKey.RightCtrl))) {
            var clipboardText = ImGui.GetClipboardText();
            if ((clipboardText.Contains('\r') || clipboardText.Contains('\n')) && !clipboardText.Contains("\r\n")) {
                ImGui.SetClipboardText(clipboardText.ReplaceLineEndings("\r\n"));
            }
        }

        if (Marker is null) {
            return;
        }

        ImGui.SameLine();
        Marker.Draw();
    }

    private static int GetLinesInString(ReadOnlySpan<char> text)
    {
        var lines = 1;
        foreach (var c in text) {
            if (c == '\n') {
                lines++;
            }
        }

        return lines;
    }
}
