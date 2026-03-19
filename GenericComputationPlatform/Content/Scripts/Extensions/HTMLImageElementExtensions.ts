
interface HTMLImageElement {
    naturalSize(): Size;
}

HTMLImageElement.prototype.naturalSize = function () {
    return new Size(this.naturalWidth, this.naturalHeight);
}
