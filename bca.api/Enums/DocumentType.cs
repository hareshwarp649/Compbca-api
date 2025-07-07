using System.ComponentModel;

namespace bca.api.Enums
{
    public enum DocumentType
    {
        [Description("Photograph")]
        Photo,

        [Description("Signature")]
        Signature,

        [Description("Aadhar Card")]
        AadharCard,

        [Description("PAN Card")]
        PANCard,

        [Description("Education Certificate")]
        EducationCertificate,

        [Description("CIBIL Report")]
        CIBILReport,

        [Description("IIBF Certificate")]
        IIBFCertificate,

        [Description("PV Certificate/Receipt")]
        PVCertificateReceipt,

        [Description("BC Outlet Model")]
        BCOutletModel,

        [Description("DRA Certificate")]
        DRACertificate,

        [Description("Passbook Or Cancelled Cheque Photo")]
        PassbookOrChequePhoto,

        [Description("Affidavit")]
        Affidavit,

        [Description("Pan Aadhar Link Photo")]
        PanAadharLinkPhoto
    }
}
