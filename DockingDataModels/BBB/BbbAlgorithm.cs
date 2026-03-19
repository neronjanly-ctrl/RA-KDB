using CommonTools;

namespace DockingDataModels;

public enum BbbAlgorithm
{
    [Match("Adaboost", "AdaBoost")]
    [Name("AdaBoost", InternalName = "Adaboost")]
    AdaBoost,

    [Match("SVM")]
    [Name("SVM", InternalName = "SVM")]
    SVM,
}
