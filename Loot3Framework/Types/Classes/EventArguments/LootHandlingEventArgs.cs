using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Loot3Framework.Interfaces;

namespace Loot3Framework.Types.Classes.EventArguments
{
    /// <summary>
    /// Enum zum unterscheiden zwischen Änderungen am Loot-Pool
    /// </summary>
    public enum EditType
    {
        /// <summary>
        /// Items hinzugefügt
        /// </summary>
        ItemsAdded,
        /// <summary>
        /// Items gelöscht
        /// </summary>
        ItemsRemoved,
        /// <summary>
        /// Items initialisiert
        /// </summary>
        ItemsInitialized
    }
    /// <summary>
    /// Eventargs für Events in <see cref="Loot3Framework.Interfaces.IItemHolder{T}"/> Subklassen
    /// </summary>
    public class LootChangedEventArgs<T> : EventArgs
    {
        private EditType change;
        private IEnumerable<ILootable<T>> loot;

        /// <summary>
        /// Konstruktor, der das geänderte Loot und den Änderungstyp setzt
        /// </summary>
        /// <param name="changedloot">Das geänderte Loot</param>
        /// <param name="changeType">Der Änderungstyp</param>
        public LootChangedEventArgs(ILootable<T> changedloot, EditType changeType)
        {
            loot = new ILootable<T>[] { changedloot };
            change = changeType;
        }
        /// <summary>
        /// Konstruktor, der das geänderte Loot und den Änderungstyp setzt
        /// </summary>
        /// <param name="changedloot">Das geänderte Loot</param>
        /// <param name="changeType">Der Änderungstyp</param>
        public LootChangedEventArgs(IEnumerable<ILootable<T>> changedloot, EditType changeType)
        {
            loot = changedloot;
            change = changeType;
        }
        /// <summary>
        /// Accessor für den Änderungstyp
        /// </summary>
        public EditType ChangeType => change;
        /// <summary>
        /// Accessor für das geänderte Loot
        /// </summary>
        public IEnumerable<ILootable<T>> ChangedLoot => loot;
    }
    /// <summary>
    /// Eventargs für Events in <see cref="Loot3Framework.Types.Classes.BaseClasses.BaseSplitItemHandler{T}"/> Subklassen
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SplitLootChangedEventArgs<T> : LootChangedEventArgs<T>
    {
        private string lootKey;
        /// <summary>
        /// Konstruktor, der das geänderte Loot, den Änderungstyp und den momentanen Loot-Pool-Key setzt
        /// </summary>
        /// <param name="changedloot">Das geänderte Loot</param>
        /// <param name="changeType">Der Änderungstyp</param>
        /// <param name="key">Der Loot-Pool-Key</param>
        public SplitLootChangedEventArgs(ILootable<T> changedloot, EditType changeType, string key) : base(changedloot, changeType)
        {
            lootKey = key;
        }
        /// <summary>
        /// Konstruktor, der das geänderte Loot, den Änderungstyp und den momentanen Loot-Pool-Key setzt
        /// </summary>
        /// <param name="changedloot">Das geänderte Loot</param>
        /// <param name="changeType">Der Änderungstyp</param>
        /// <param name="key">Der Loot-Pool-Key</param>
        public SplitLootChangedEventArgs(IEnumerable<ILootable<T>> changedloot, EditType changeType, string key) : base(changedloot, changeType)
        {
            lootKey = key;
        }
        /// <summary>
        /// Der momentane Loot-Pool-Key
        /// </summary>
        public string CurrentKey => lootKey;
    }
}
