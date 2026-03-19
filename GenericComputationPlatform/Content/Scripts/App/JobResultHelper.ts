class JobResultHelper {
    static setResult(cavityId: string, ligandId: string, dockingScores: (number | null)[], dockingIds: (string | null)[], mostSimilarActiveCompound: ChemblCompound | null, prediction: Prediction | null) {
        for (let i = 0; i < dockingScores.length; i++) {
            const score = dockingScores[i];
            const dockingId = dockingIds[i];
            if (score !== null && dockingId !== "" && dockingId !== null)
                this.setDockingScoreColumn(cavityId, ligandId, i, score.toFixed(2), dockingId);
        }

        if (mostSimilarActiveCompound !== null && mostSimilarActiveCompound.activity !== "Unknown") {
            this.setSimilarityScoreColumn(cavityId, ligandId, `${(Math.round(mostSimilarActiveCompound.similarity * 10000) / 100).toFixed(2)}%`);
            this.setBestMatchColumn(cavityId, ligandId, mostSimilarActiveCompound.id);
        }

        if (prediction !== null && prediction.activity !== "Unknown") {
            this.setResultColumns(cavityId, ligandId, prediction.activity, `${(Math.round(prediction.confidenceLevel * 10000) / 100).toFixed(2)}%`);
        }
    }

    private static setDockingScoreColumn(cavityId: string, ligandId: string, modelId: number, score: string, dockingId: string) {
        let a = $(`.c${cavityId}.l${ligandId} .d${modelId}`).text(score).parent("a");
        // in table view unvisible rows are unaccessible.
        if (a.length === 0)
            return;

        a.attr("href", (a.attr("href") as string).replace(/\/0$/, `/${dockingId}`));

        a.next().not("a").remove(); // remove the ? placeholder
        a.removeClass("d-none"); // show the anchor
    }

    private static setSimilarityScoreColumn(cavityId: string, ligandId: string, score: string) {
        $(`.c${cavityId}.l${ligandId} .s4`).text(score);
    }

    private static setBestMatchColumn(cavityId: string, ligandId: string, similarChemblId: string) {
        let a = $(`.c${cavityId}.l${ligandId} .s6`).text(similarChemblId).parent("a");

        a.next().not("a").remove(); // remove the ? placeholder
        a.removeClass("d-none"); // show the anchor
    }

    private static setResultColumns(cavityId: string, ligandId: string, prediction: string, confidence: string) {
        $(`.c${cavityId}.l${ligandId} .s5`).text(prediction);
        $(`.c${cavityId}.l${ligandId} .s7`).text(confidence);
    }
}