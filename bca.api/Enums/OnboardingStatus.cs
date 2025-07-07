using System.ComponentModel;

namespace bca.api.Enums
{
    public enum OnboardingStatus
    {
        [Description("New Request")]
        NewRequest,

        [Description("Rejected")]
        Rejected,

        [Description("OD Account Request Letter Generated")]
        ODAccountRequestLetterGenerated,

        [Description("OD Account Created")]
        ODAccountCreated,

        [Description("KO Code Request Generated")]
        KOCodeRequestGenerated,

        [Description("KO Code Assigned")]
        KOCodeAssigned,
    }
}
