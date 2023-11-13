using FFXIVClientStructs.FFXIV.Client.Game.Group;
using XpahtaLib.DalamudUtilities.UsefulEnums;

namespace XpahtaLib.DalamudUtilities.Extensions;

public static class GroupManagerExtensions
{
    public static AllianceType GetAllianceType(this GroupManager groupManager) => (AllianceType)groupManager.AllianceFlags;
}
