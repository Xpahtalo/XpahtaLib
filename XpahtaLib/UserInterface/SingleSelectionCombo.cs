using Dalamud.Interface.Utility.Raii;
using ImGuiNET;

namespace XpahtaLib.UserInterface;

public class SingleSelectionCombo<TItemType> : ImGuiWidget
{
    private string                            DefaultLabel          { get; }
    private Func<TItemType, string>           ItemToString          { get; }
    private Func<TItemType?, TItemType, bool> CompareItemToSelected { get; }
    private HelpMarker?                       Marker                { get; }

    public delegate void                   OnComboSelectionChanged(TItemType? selectedItem);
    private event OnComboSelectionChanged? SelectionChanged;

    public SingleSelectionCombo(
        string                            label,
        Func<TItemType, string>           itemToString,
        Func<TItemType?, TItemType, bool> compareItemToSelected,
        OnComboSelectionChanged           onComboSelectionChanged,
        string?                           helpText = null)
    {
        DefaultLabel          =  label;
        ItemToString          =  itemToString;
        CompareItemToSelected =  compareItemToSelected;
        SelectionChanged      += onComboSelectionChanged;
        Marker                =  helpText is null ? null : new HelpMarker(helpText);
    }

    public void Draw<T>(T? selectedItem, IEnumerable<T> items)
    where T : TItemType
    {
        using var combo = selectedItem is not null
                              ? ImRaii.Combo($"{DefaultLabel}##{Id}", $"{ItemToString(selectedItem)}", ImGuiComboFlags.None)
                              : ImRaii.Combo($"{DefaultLabel}##{Id}", "",                              ImGuiComboFlags.None);
        if (!combo) {
            return;
        }

        if (Marker is not null) {
            ImGui.SameLine();
            Marker.Draw();
        }

        var i = 0;
        foreach (var item in items) {
            if (ImGui.Selectable($"{ItemToString(item)}##{i}", CompareItemToSelected(selectedItem, item))) {
                SelectionChanged?.Invoke(item);
            }

            i++;
        }
    }
}
