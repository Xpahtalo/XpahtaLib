using ImGuiNET;

namespace XpahtaLib.UserInterface;

public class HelpMarker: ImGuiWidget
{
    private readonly string _text;

    public HelpMarker(string text, Guid id)
        : base(id)
    {
        _text = text;
    }
    
    public void Draw()
    {
        ImGui.SameLine();
        ImGui.TextDisabled("(?)");
        if (ImGui.IsItemHovered())
            ImGui.SetTooltip(_text);
    }
}
