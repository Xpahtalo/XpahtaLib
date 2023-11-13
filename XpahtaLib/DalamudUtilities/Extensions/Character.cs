using Dalamud.Game.ClientState.Objects.Types;
using XpahtaLib.DalamudUtilities.UsefulEnums;

namespace XpahtaLib.DalamudUtilities.Extensions;

public static class CharacterExtensions
{
    public static Job GetJob(this Character character)
    {
        var jobId = character.ClassJob.Id;
        if (jobId < JobExtensions.DefinedJobCount) {
            return (Job)jobId;
        }

        return Job.Unknown;
    }

    public static bool IsJob(this Character character, Job job) => character.GetJob() == job;
}
