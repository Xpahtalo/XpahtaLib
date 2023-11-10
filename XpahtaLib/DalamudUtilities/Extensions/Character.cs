using Dalamud.Game.ClientState.Objects.Types;

namespace XpahtaLib.DalamudUtilities.Extensions;

public static class CharacterExtensions
{
    public static Job Job(this Character character)
    {
        var jobId = character.ClassJob.Id;
        if (jobId < JobExtensions.DefinedJobCount) {
            return (Job)jobId;
        }

        return DalamudUtilities.Job.Unknown;
    }

    public static bool IsJob(this Character character, Job job) => character.Job() == job;
}
