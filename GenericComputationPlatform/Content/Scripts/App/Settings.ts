
class Settings {
    drugStyle: NodeStyle = {
        borderPaint: HslColor.fromHtml("#6fd0f5"),
        borderWidth: 2,
        fillColor: HslColor.fromHtml("#fff"),
        selectedFillColor: HslColor.fromHtml("#ff0"),
        size: 100.0,
        labelColor: HslColor.fromHtml("#000"),
        selectedLabelColor: HslColor.fromHtml("#000"),
        labelFontSize: 14,
        roundRectRadius: 4,
    }

    knownTargetStyle: NodeStyle = {
        borderPaint: HslColor.fromHtml("#000"),
        borderWidth: 0,
        fillColor: HslColor.fromHtml("#5cff54"),
        selectedFillColor: HslColor.fromHtml("#ff0"),
        size: 35,
        labelColor: HslColor.fromHtml("#000"),
        selectedLabelColor: HslColor.fromHtml("#000"),
        labelFontSize: 11,
        roundRectRadius: 0,
    }

    unknownTargetStyle: NodeStyle = {
        borderPaint: HslColor.fromHtml("#000"),
        borderWidth: 0,
        fillColor: HslColor.fromHtml("#fd81fe"),
        selectedFillColor: HslColor.fromHtml("#ff0"),
        size: 35,
        labelColor: HslColor.fromHtml("#000"),
        selectedLabelColor: HslColor.fromHtml("#000"),
        labelFontSize: 11,
        roundRectRadius: 0,
    }

    knownInteractionStyle: InteractionStyle = {
        lineWidth: 2,
        strokeStyle: HslColor.fromHtml("#5cff54"),
        labelColor: HslColor.fromHtml("#007723"),
        labelFontSize: 11,
        labelFontBold: true,
    }

    unknownInteractionStyle: InteractionStyle = {
        lineWidth: 2,
        dashLinePatten: [6, 4],
        strokeStyle: HslColor.fromHtml("#6297f0"),
        labelColor: HslColor.fromHtml("#320077"),
        labelFontSize: 11,
        labelFontBold: true,
    }

    showLabel = false;
    showDepiction = true;
    branchesPerRound = 18;
    rowHeight = 1.8;
    targetDistance = 1.2;
}