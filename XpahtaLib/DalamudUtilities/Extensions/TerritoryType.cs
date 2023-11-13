using XpahtaLib.DalamudUtilities.UsefulEnums;
using Old = Lumina.Excel.GeneratedSheets;
using New = Lumina.Excel.GeneratedSheets2;

namespace XpahtaLib.DalamudUtilities.Extensions;

public static class TerritoryTypeExtensions
{
    public static bool HasAlliance(this Old.TerritoryType territoryType) => ((TerritoryIntendedUseEnum)territoryType.TerritoryIntendedUse).HasAlliance();

    public static bool UsesBothGroupManagers(this Old.TerritoryType territoryType) => ((TerritoryIntendedUseEnum)territoryType.TerritoryIntendedUse).UsesBothGroupManagers();

    public static bool IsRaidOrTrial(this Old.TerritoryType territoryType) => ((TerritoryIntendedUseEnum)territoryType.TerritoryIntendedUse).IsRaidOrTrial();

    public static AllianceType GetAllianceType(this Old.TerritoryType territoryType) => ((TerritoryIntendedUseEnum)territoryType.TerritoryIntendedUse).GetAllianceType();
}

public static class TerritoryType2Extensions
{
    public static bool HasAlliance(this New.TerritoryType territoryType) => ((TerritoryIntendedUseEnum)territoryType.TerritoryIntendedUse).HasAlliance();

    public static bool UsesBothGroupManagers(this New.TerritoryType territoryType) => ((TerritoryIntendedUseEnum)territoryType.TerritoryIntendedUse).UsesBothGroupManagers();

    public static bool IsRaidOrTrial(this New.TerritoryType territoryType) => ((TerritoryIntendedUseEnum)territoryType.TerritoryIntendedUse).IsRaidOrTrial();

    public static AllianceType GetAllianceType(this New.TerritoryType territoryType) => ((TerritoryIntendedUseEnum)territoryType.TerritoryIntendedUse).GetAllianceType();
}
