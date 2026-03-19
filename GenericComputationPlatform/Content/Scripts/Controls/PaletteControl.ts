
class PaletteControl {
    paletteCanvas: HTMLCanvasElement;

    private readonly renderer: PaletteRenderer;
    private onchange?: (color: HslColor) => void;
    private sliding: boolean;

    constructor(x: number, y: number, color: HslColor) {
        // clean up previous control
        this.hide();

        this.sliding = false;

        const palette = $("<canvas class='palette'>");

        const pltWidth = 304, pltHeight = 192;
        palette.prop("width", pltWidth * window.devicePixelRatio);
        palette.prop("height", pltHeight * window.devicePixelRatio);
        palette.width(pltWidth);
        palette.height(pltHeight);
        palette.css("left", x);
        palette.css("top", y);

        palette.mousedown(event => this.mousedown(event));
        palette.mouseup(event => this.mouseup(event));
        palette.mousemove(event => this.mousemove(event));

        this.paletteCanvas = palette[0] as Node as HTMLCanvasElement;

        this.renderer = new PaletteRenderer();
        this.renderer.init(pltWidth, pltHeight, color);
        this.renderer.draw(this.paletteCanvas);
    }

    show() {
        const jpl = $(this.paletteCanvas);
        jpl.fadeIn();
    }

    hide() {
        const jpls = $("canvas.palette");
        jpls.remove();
    }

    change(onchange: (color: HslColor) => void): PaletteControl {
        this.onchange = onchange;
        return this;
    }

    private mousedown(event: JQuery.MouseDownEvent) {
        if (event.offsetX === undefined || event.offsetY === undefined)
            return false;

        if (this.sliding)
            return false;

        let sel = this.renderer.hitTest(event.offsetX, event.offsetY);
        if (sel === null)
            return false;

        this.sliding = true;

        sel = this.renderer.hitTest(event.offsetX, event.offsetY);
        if (sel === null)
            return false;

        this.renderer.select(sel);
        this.renderer.draw(this.paletteCanvas);

        const selected = new HslColor(this.renderer.hue, this.renderer.saturation, this.renderer.lightness);

        if (this.onchange !== undefined)
            this.onchange(selected);

        return false;
    }

    private mouseup(event: JQuery.MouseUpEvent) {
        this.sliding = false;
        return false;
    }

    private mousemove(event: JQuery.MouseMoveEvent) {
        if (event.offsetX === undefined || event.offsetY === undefined)
            return false;

        if (!this.sliding)
            return false;

        const sel = this.renderer.hitTest(event.offsetX, event.offsetY);
        if (sel === null)
            return false;

        this.renderer.select(sel);
        this.renderer.draw(this.paletteCanvas);

        const selected = new HslColor(this.renderer.hue, this.renderer.saturation, this.renderer.lightness);

        if (this.onchange !== undefined)
            this.onchange(selected);

        return false;
    }
}