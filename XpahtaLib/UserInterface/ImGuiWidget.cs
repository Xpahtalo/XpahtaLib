using ImGuiNET;

namespace XpahtaLib.UserInterface;

public class ImGuiWidget
{
    public Guid Id { get; private set; }

    protected ImGuiWidget()
        : this(new Guid()) { }

    internal ImGuiWidget(Guid id) { Id = id; }
}
