﻿using System.Numerics;
using Dalamud.Interface.Utility.Raii;
using ImGuiNET;

namespace XpahtaLib.UserInterface;

public class SingleSelectionList<TItemType>: ImGuiWidget
{
    private Func<TItemType, string>           ItemToLabel           { get; }
    private Func<TItemType?, TItemType, bool> CompareItemToSelected { get; }

    public delegate void              OnSelectionChanged(TItemType? selectedItem);
    private event OnSelectionChanged? SelectionChanged;

    public SingleSelectionList(Func<TItemType, string> itemToLabel, Func<TItemType?, TItemType, bool> compareItemToSelected, OnSelectionChanged onSelectionChanged)
    {
        ItemToLabel           =  itemToLabel;
        CompareItemToSelected =  compareItemToSelected;
        SelectionChanged      += onSelectionChanged;
    }

    /// <summary>
    ///     Draws a ListBox that can be used to select a single item from a list.
    /// </summary>
    /// <param name="selectedItem">The currently selected item.</param>
    /// <param name="items">An IEnumerable of the items in the list.</param>
    /// <param name="size">The display size of the list box.</param>
    /// <param name="itemToLabel">A function to get a label from the item.</param>
    /// <param name="compareItemToSelected">A function to compare items.</param>
    /// <typeparam name="T">The type of the item in the list.</typeparam>
    /// <returns>Item1: False if the list box was not drawn, otherwise true. Item2: The selected item.</returns>
    public void Draw<T>(T? selectedItem, IEnumerable<T> items, Vector2 size)
        where T: TItemType
    {
        var list = ImRaii.ListBox($"{Id}", size);
        if (!list)
            return;
        var i = 0;
        foreach (var item in items){
            if (ImGui.Selectable($"{ItemToLabel(item)}##{i}", CompareItemToSelected(selectedItem, item)))
                SelectionChanged?.Invoke(item);
            i++;
        }
    }
}
