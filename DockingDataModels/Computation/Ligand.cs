using CommonTools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DockingDataModels;

/// <summary>
/// The structure to store information about the ligand.
/// </summary>
[DataContract(IsReference = true)]
public class Ligand
{
    /// <summary>
    /// The 64bit integral identifier of the ligand. Typically serialized in 16-bit hexadecimal numbers.
    /// </summary>
    /// <example>564317086151593180</example>
    [Key]
    [DataMember]
    public long Id { get; set; }


    /// <summary>
    /// The date and time when the ligand was created.
    /// </summary>
    [Required]
    [DataMember]
    public DateTime Created { get; set; }

    /// <summary>
    /// The date and time when the ligand was last updated.
    /// </summary>
    [DataMember]
    public DateTime Updated { get; set; }


    /// <summary>
    /// The SMILES depiction of the ligand.
    /// </summary>
    /// <example>O=C(C)Oc1ccccc1C(=O)O</example>
    [Required]
    [DataMember]
    public string Smiles { get; set; }

    /// <summary>
    /// The 2D molecular depiction in SVG format.
    /// </summary>
    [DataMember]
    public string DepictionSvg { get; set; }

    /// <summary>
    /// The 3D molecular depiction in SVG format.
    /// </summary>
    [DataMember]
    public string DepictionSvg3D { get; set; }

    #region BBB Scores

    /// <summary>
    /// The predicted BBB score using AdaBoost algorithm and MACCS molecular fingerprint.
    /// </summary>
    [DataMember]
    public float? BbbAdaBoostMACCS { get; set; }

    /// <summary>
    /// The predicted BBB score using AdaBoost algorithm and PubChem molecular fingerprint.
    /// </summary>
    [DataMember]
    public float? BbbAdaBoostPubChem { get; set; }

    /// <summary>
    /// The predicted BBB score using AdaBoost algorithm and Molprint 2D molecular fingerprint.
    /// </summary>
    [DataMember]
    public float? BbbAdaBoostMolprint2D { get; set; }

    /// <summary>
    /// The predicted BBB score using AdaBoost algorithm and DayLight FP2 molecular fingerprint.
    /// </summary>
    [DataMember]
    public float? BbbAdaboostFP2 { get; set; }

    /// <summary>
    /// The predicted BBB score using support vector machine (SVM) algorithm and MACCS molecular fingerprint.
    /// </summary>
    [DataMember]
    public float? BbbSvmMACCS { get; set; }

    /// <summary>
    /// The predicted BBB score using support vector machine (SVM) algorithm and PubChem molecular fingerprint.
    /// </summary>
    [DataMember]
    public float? BbbSvmPubChem { get; set; }

    /// <summary>
    /// The predicted BBB score using support vector machine (SVM) algorithm and Molprint 2D molecular fingerprint.
    /// </summary>
    [DataMember]
    public float? BbbSvmMolprint2D { get; set; }

    /// <summary>
    /// The predicted BBB score using support vector machine (SVM) algorithm and DayLight FP2 molecular fingerprint.
    /// </summary>
    [DataMember]
    public float? BbbSvmFP2 { get; set; }

    #endregion

    #region Fingerprints

    /// <summary>
    /// The MACCS molecular fingerprint of the ligand.
    /// </summary>
    [DataMember]
    public byte[] FingerprintMACCS { get; set; }

    /// <summary>
    /// The FP2 molecular fingerprint of the ligand.
    /// </summary>
    [DataMember]
    public byte[] FingerprintFP2 { get; set; }

    /// <summary>
    /// The FP3 molecular fingerprint of the ligand.
    /// </summary>
    [DataMember]
    public byte[] FingerprintFP3 { get; set; }

    /// <summary>
    /// The FP4 molecular fingerprint of the ligand.
    /// </summary>
    [DataMember]
    public byte[] FingerprintFP4 { get; set; }

    /// <summary>
    /// The ECFP0 molecular fingerprint of the ligand.
    /// </summary>
    [DataMember]
    public byte[] FingerprintECFP0 { get; set; }

    /// <summary>
    /// The ECFP2 molecular fingerprint of the ligand.
    /// </summary>
    [DataMember]
    public byte[] FingerprintECFP2 { get; set; }

    /// <summary>
    /// The ECFP4 molecular fingerprint of the ligand.
    /// </summary>
    [DataMember]
    public byte[] FingerprintECFP4 { get; set; }

    /// <summary>
    /// The ECFP6 molecular fingerprint of the ligand.
    /// </summary>
    [DataMember]
    public byte[] FingerprintECFP6 { get; set; }

    /// <summary>
    /// The ECFP8 molecular fingerprint of the ligand.
    /// </summary>
    [DataMember]
    public byte[] FingerprintECFP8 { get; set; }

    /// <summary>
    /// The ECFP10 molecular fingerprint of the ligand.
    /// </summary>
    [DataMember]
    public byte[] FingerprintECFP10 { get; set; }

    #endregion

    #region Navigation Properties

    /// <summary>
    /// The list of computation jobs that use this ligand. Could be empty if the API doesn't make use of it.
    /// </summary>
    [DataMember]
    public List<JobLigand> LigandJobs { get; set; }

    /// <summary>
    /// The computation results for this ligand. Could be empty if the API doesn't make use of it.
    /// </summary>
    [DataMember]
    public List<Result> Results { get; set; }

    #endregion

    #region Indexers

    [JsonIgnore]
    public Indexer<string, string> DepictionSvgs { get; }

    [JsonIgnore]
    public Indexer<BbbAlgorithm, BbbFingerprint, float?> BbbScores { get; }

    [JsonIgnore]
    public Indexer<Fingerprint, byte[]> Fingerprints { get; }

    #endregion

    #region Constructors

    public Ligand()
    {
        DepictionSvgs = new Indexer<string, string>
        {
            Getter = type => type switch
            {
                "2d" => DepictionSvg,
                "3d" => DepictionSvg3D,
                _ => throw new IndexOutOfRangeException($"Index {type} for type not exist"),
            },
            Setter = (type, value) =>
            {
                switch (type)
                {
                    case "2d": DepictionSvg = value; return;
                    case "3d": DepictionSvg3D = value; return;
                }
                throw new IndexOutOfRangeException($"Index {type} for type not exist");
            },
        };

        BbbScores = new Indexer<BbbAlgorithm, BbbFingerprint, float?>
        {
            Getter = (algorithm, fingerprint) => algorithm switch
            {
                BbbAlgorithm.AdaBoost => fingerprint switch
                {
                    BbbFingerprint.MACCS => BbbAdaBoostMACCS,
                    BbbFingerprint.PubChem => BbbAdaBoostPubChem,
                    BbbFingerprint.Molprint2D => BbbAdaBoostMolprint2D,
                    BbbFingerprint.FP2 => BbbAdaboostFP2,
                    _ => throw new IndexOutOfRangeException($"Index fingerprint type {fingerprint} not exist"),
                },
                BbbAlgorithm.SVM => fingerprint switch
                {
                    BbbFingerprint.MACCS => BbbSvmMACCS,
                    BbbFingerprint.PubChem => BbbSvmPubChem,
                    BbbFingerprint.Molprint2D => BbbSvmMolprint2D,
                    BbbFingerprint.FP2 => BbbSvmFP2,
                    _ => throw new IndexOutOfRangeException($"Index fingerprint type {fingerprint} not exist"),
                },
                _ => throw new IndexOutOfRangeException($"Index algorithm type {algorithm} not exist"),
            },
            Setter = (algorithm, fingerprint, value) =>
            {
                if (algorithm == BbbAlgorithm.AdaBoost)
                {
                    switch (fingerprint)
                    {
                        case BbbFingerprint.MACCS: BbbAdaBoostMACCS = value; return;
                        case BbbFingerprint.PubChem: BbbAdaBoostPubChem = value; return;
                        case BbbFingerprint.Molprint2D: BbbAdaBoostMolprint2D = value; return;
                        case BbbFingerprint.FP2: BbbAdaboostFP2 = value; return;
                    }
                }
                else if (algorithm == BbbAlgorithm.SVM)
                {
                    switch (fingerprint)
                    {
                        case BbbFingerprint.MACCS: BbbSvmMACCS = value; return;
                        case BbbFingerprint.PubChem: BbbSvmPubChem = value; return;
                        case BbbFingerprint.Molprint2D: BbbSvmMolprint2D = value; return;
                        case BbbFingerprint.FP2: BbbSvmFP2 = value; return;
                    }
                }
                throw new IndexOutOfRangeException($"Index combination {algorithm} and {fingerprint} not exist");
            },
        };

        Fingerprints = new Indexer<Fingerprint, byte[]>
        {
            Getter = fptype => fptype switch
            {
                Fingerprint.MACCS => FingerprintMACCS,
                Fingerprint.FP2 => FingerprintFP2,
                Fingerprint.FP3 => FingerprintFP3,
                Fingerprint.FP4 => FingerprintFP4,
                Fingerprint.ECFP0 => FingerprintECFP0,
                Fingerprint.ECFP2 => FingerprintECFP2,
                Fingerprint.ECFP4 => FingerprintECFP4,
                Fingerprint.ECFP6 => FingerprintECFP6,
                Fingerprint.ECFP8 => FingerprintECFP8,
                Fingerprint.ECFP10 => FingerprintECFP10,
                _ => throw new IndexOutOfRangeException($"Index fingerprint type {fptype} not exist"),
            },
            Setter = (fptype, fp) =>
            {
                switch (fptype)
                {
                    case Fingerprint.MACCS: FingerprintMACCS = fp; return;
                    case Fingerprint.FP2: FingerprintFP2 = fp; return;
                    case Fingerprint.FP3: FingerprintFP3 = fp; return;
                    case Fingerprint.FP4: FingerprintFP4 = fp; return;
                    case Fingerprint.ECFP0: FingerprintECFP0 = fp; return;
                    case Fingerprint.ECFP2: FingerprintECFP2 = fp; return;
                    case Fingerprint.ECFP4: FingerprintECFP4 = fp; return;
                    case Fingerprint.ECFP6: FingerprintECFP6 = fp; return;
                    case Fingerprint.ECFP8: FingerprintECFP8 = fp; return;
                    case Fingerprint.ECFP10: FingerprintECFP10 = fp; return;
                }
                throw new IndexOutOfRangeException($"Index fingerprint type {fptype} not exist");
            },
        };
    }

    #endregion

    public void Init(string smiles)
    {
        Id = smiles.Trim().ComputeHashInt64();
        Smiles = smiles;
        Created = DateTime.UtcNow;
        Update();
    }

    public void Update()
    {
        Updated = DateTime.UtcNow;
    }
}
