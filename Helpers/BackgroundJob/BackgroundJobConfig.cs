using Hangfire;

public static class BackgroundJobConfig
{
    public static void Register()
    {
        RecurringJobOptions options = new RecurringJobOptions
        {
            TimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time")
        };

        RecurringJob.AddOrUpdate<BackgroundJobService>(
            "mass-update-id-position",
            job => job.MassUpdateIdPosition(),
            "0 2 * * *",
            options
        );
    }
}