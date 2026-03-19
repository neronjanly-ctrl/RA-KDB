using CommonTools;

namespace DockingDataModels;

public enum MachineLearningAlgorithm
{
    [Match("RF")]
    [Name("RF", InternalName = "RF")]
    RandomForest,

    [Match("LR")]
    [Name("LR", InternalName = "LR")]
    LogisticRegression,

    [Match("MLP", "ANN")]
    [Name("MLP", InternalName = "MLP")]
    MultiLayerPerceptron,

    [Match("SVM")]
    [Name("SVM", InternalName = "SVM")]
    SupportVectorMachine,
}
