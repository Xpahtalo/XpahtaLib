using Dalamud.Interface.Utility.Raii;
using ImGuiNET;

namespace XpahtaLib.UserInterface;

public class SingleSelectionCombo<TItemType>: ImGuiWidget
{
    private Func<TItemType, string>           ItemToLabel           { get; }
    private Func<TItemType?, TItemType, bool> CompareItemToSelected { get; }

    public delegate void                   OnComboSelectionChanged(TItemType? selectedItem);
    private event OnComboSelectionChanged? SelectionChanged;

    public SingleSelectionCombo(
        Func<TItemType, string>           itemToLabel,
        Func<TItemType?, TItemType, bool> compareItemToSelected,
        OnComboSelectionChanged           onComboSelectionChanged)
    {
        ItemToLabel           =  itemToLabel;
        CompareItemToSelected =  compareItemToSelected;
        SelectionChanged      += onComboSelectionChanged;
    }

    public void Draw<T>(T selectedItem, IEnumerable<T> items)
        where T: TItemType
    {
        using var combo = ImRaii.Combo($"{Id}", $"{ItemToLabel(selectedItem)}", ImGuiComboFlags.None);
        if (!combo)
            return;
        var i = 0;
        foreach (var item in items){
            if (ImGui.Selectable($"{ItemToLabel(item)}##{i}", CompareItemToSelected(selectedItem, item)))
                SelectionChanged?.Invoke(item);
            i++;
        }
    }
}
