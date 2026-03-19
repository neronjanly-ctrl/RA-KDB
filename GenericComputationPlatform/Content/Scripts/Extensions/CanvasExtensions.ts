
interface CanvasRenderingContext2D {
    dashedLineTo(fromX: number, fromY: number, toX: number, toY: number, pattern?: number[]): CanvasRenderingContext2D;

    drawRoundRect(left: number, top: number, width: number, height: number, radius: number,
        fillColor: RgbColor | HslColor,
        borderWidth: number, borderColor: RgbColor | HslColor,
        label: string, labelColor: RgbColor | HslColor, labelSize: number): CanvasRenderingContext2D;

    drawRound(
        centerX: number, centerY: number, radius: number,
        fillColor: RgbColor | HslColor,
        borderWidth: number, borderColor: RgbColor | HslColor,
        label: string, labelColor: RgbColor | HslColor, labelSize: number): CanvasRenderingContext2D;
}

CanvasRenderingContext2D.prototype.dashedLineTo = function (fromX, fromY, toX, toY, pattern) {
    if (pattern === undefined || pattern.length < 2)
        throw new Error("Invalid pattern");

    // calculate the delta x and delta y
    const dx = (toX - fromX);
    const dy = (toY - fromY);
    const patternLen = pattern[0] + pattern[1];
    const distance = Math.floor(Math.sqrt(dx * dx + dy * dy));
    const dashlineInteveral = distance / patternLen;

    const delta = new Point(dx / distance * patternLen, dy / distance * patternLen);
    const delta0 = new Point(dx / distance * pattern[0], dy / distance * pattern[0]);

    // draw dash line
    this.beginPath();
    for (let dl = 0; dl < dashlineInteveral; dl++) {
        this.moveTo(fromX + dl * delta.x, fromY + dl * delta.y);
        this.lineTo(fromX + dl * delta.x + delta0.x, fromY + dl * delta.y + delta0.y);
    }
    this.stroke();

    return this;
};

CanvasRenderingContext2D.prototype.drawRoundRect = function (left, top, width, height, radius,
    fillColor, borderWidth, borderColor, label, labelColor, labelSize) {

    this.beginPath();
    this.moveTo(left + radius, top);
    this.arcTo(left + width, top, left + width, top + height, radius);
    this.arcTo(left + width, top + height, left, top + height, radius);
    this.arcTo(left, top + height, left, top, radius);
    this.arcTo(left, top, left + width, top, radius);
    this.closePath();

    if (borderWidth > 0) {
        this.lineWidth = borderWidth * 2;
        this.strokeStyle = borderColor.toHtml();
        this.stroke();
    }

    this.fillStyle = fillColor.toHtml();
    this.fill();

    if (label !== undefined && label !== "") {
        this.font = `bold ${labelSize}px Arial`;

        const textWidth = this.measureText(label).width;

        this.fillStyle = labelColor.toHtml();
        this.fillText(label, left + width / 2 - textWidth / 2, top + height - labelSize / 6); // fillText(text, left, bottom)
    }

    return this;
}

CanvasRenderingContext2D.prototype.drawRound = function (centerX, centerY, radius,
    fillColor, borderWidth, borderColor, label, labelColor, labelSize) {

    this.beginPath();
    this.arc(centerX, centerY, radius, 0, Math.PI * 2);
    this.closePath();

    if (borderWidth > 0) {
        this.lineWidth = borderWidth * 2;
        this.strokeStyle = borderColor.toHtml();
        this.stroke();
    }

    this.fillStyle = fillColor.toHtml();
    this.fill();

    if (label !== undefined && label !== "") {
        this.font = `bold ${labelSize}px Arial`;
        this.fillStyle = labelColor.toHtml();

        let lines = label.split('\n');
        for (let i = 0; i < lines.length; i++) {
            const textWidth = this.measureText(lines[i]).width;
            this.fillText(lines[i], centerX - textWidth / 2, centerY - labelSize * (lines.length - i * 2 - 1) / 2 + labelSize / 3);
        }
    }

    return this;
}