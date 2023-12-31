﻿using System.Numerics;
using Dalamud.Interface.Utility.Raii;
using ImGuiNET;

namespace XpahtaLib.UserInterface;

public class SingleSelectionList<TItemType> : ImGuiWidget
{
    private string                            DefaultLabel          { get; }
    private Func<TItemType, string>           ItemToString          { get; }
    private Func<TItemType?, TItemType, bool> CompareItemToSelected { get; }

    public delegate void                  OnListSelectionChanged(TItemType? selectedItem);
    private event OnListSelectionChanged? SelectionChanged;

    public SingleSelectionList(
        string                            defaultLabel,
        Func<TItemType, string>           itemToString,
        Func<TItemType?, TItemType, bool> compareItemToSelected,
        OnListSelectionChanged            onListSelectionChanged)
    {
        DefaultLabel          =  defaultLabel;
        ItemToString          =  itemToString;
        CompareItemToSelected =  compareItemToSelected;
        SelectionChanged      += onListSelectionChanged;
    }

    /// <summary>
    ///     Draws a ListBox that can be used to select a single item from a list.
    /// </summary>
    /// <param name="selectedItem">The currently selected item.</param>
    /// <param name="items">An IEnumerable of the items in the list.</param>
    /// <param name="size">The display size of the list box.</param>
    /// <typeparam name="T">The type of the item in the list.</typeparam>
    /// <returns>Item1: False if the list box was not drawn, otherwise true. Item2: The selected item.</returns>
    public void Draw<T>(T? selectedItem, IEnumerable<T> items, Vector2 size)
    where T : TItemType
    {
        using var list = ImRaii.ListBox($"{DefaultLabel}##{Id}", size);
        if (!list) {
            return;
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
