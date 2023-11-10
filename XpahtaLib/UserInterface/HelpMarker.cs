using ImGuiNET;

namespace XpahtaLib.UserInterface;

public class HelpMarker : ImGuiWidget
{
    private string Text { get; }

    public HelpMarker(string text) { Text = text; }

    public void Draw()
    {
        ImGui.SameLine();
        ImGui.TextDisabled("(?)");
        if (ImGui.IsItemHovered()) {
            ImGui.SetTooltip(Text);
        }
    }
}
