using System.ComponentModel;

namespace bca.api.Enums
{
    public enum EmployeeType
    {
        [Description("Full-time Employee")]
        FullTime,

        [Description("Part-time Employee")]
        PartTime,

        [Description("Contract Employee")]
        Contract,

        [Description("Temporary Employee")]
        Temporary,

        [Description("Confirmed Employee")]
        Confirmed,

        [Description("Fixed-term Contract Employee")]
        FixedTermContract,

        [Description("Professional Service Contract Employee")]
        ProfessionalServiceContract,
    }
}
