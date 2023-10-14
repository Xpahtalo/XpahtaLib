﻿using Dalamud.Interface.Utility.Raii;
using ImGuiNET;

namespace XpahtaLib.UserInterface;

public class SingleSelectionCombo<TItemType>: ImGuiWidget
{
    private readonly string                            _label;
    private          Func<TItemType, string>           ItemToLabel           { get; }
    private          Func<TItemType?, TItemType, bool> CompareItemToSelected { get; }
    private readonly HelpMarker?                       _helpMarker;

    public delegate void                   OnComboSelectionChanged(TItemType? selectedItem);
    private event OnComboSelectionChanged? SelectionChanged;

    public SingleSelectionCombo(
        string                            label,
        Func<TItemType, string>           itemToLabel,
        Func<TItemType?, TItemType, bool> compareItemToSelected,
        OnComboSelectionChanged           onComboSelectionChanged,
        string?                           helpText = null)
    {
        _label                =  label;
        ItemToLabel           =  itemToLabel;
        CompareItemToSelected =  compareItemToSelected;
        SelectionChanged      += onComboSelectionChanged;
        _helpMarker           =  helpText is null ? null : new HelpMarker(helpText);
    }

    public void Draw<T>(T? selectedItem, IEnumerable<T> items)
        where T: TItemType
    {
        using var combo = selectedItem is not null
                              ? ImRaii.Combo($"{_label}##{Id}", $"{ItemToLabel(selectedItem)}", ImGuiComboFlags.None)
                              : ImRaii.Combo($"{_label}##{Id}", "",                             ImGuiComboFlags.None);
        if (!combo)
            return;
        var i = 0;
        foreach (var item in items){
            if (ImGui.Selectable($"{ItemToLabel(item)}##{i}", CompareItemToSelected(selectedItem, item)))
                SelectionChanged?.Invoke(item);
            i++;
        }

        if (_helpMarker is null)
            return;
        ImGui.SameLine();
        _helpMarker.Draw();
    }
}
