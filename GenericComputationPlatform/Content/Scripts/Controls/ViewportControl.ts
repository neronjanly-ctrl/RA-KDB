
class ViewportControl {
    private readonly viewportCanvas: HTMLCanvasElement;
    private readonly renderer: ViewportRenderer;

    private oncancel?: () => void;
    private onselect?: (style: NodeStyle) => void;
    private onmultiselect?: () => void;

    private dragging: boolean;
    private dragged: boolean;
    private cursorX: number;
    private cursorY: number;

    constructor(elements: JQuery<HTMLElement>, model: InputData, imgUrls: { [key: string]: string }) {
        if (elements.length === 0)
            throw new Error("Viewport canvas is required");

        this.dragging = false;
        this.dragged = false;
        this.cursorX = 0;
        this.cursorY = 0;

        const vp = elements[0] as HTMLCanvasElement;
        const jvp = $(vp);

        this.viewportCanvas = vp;

        jvp.mousedown(event => this.mousedown(event));
        jvp.mouseup(event => this.mouseup(event));
        jvp.mousemove(event => this.mousemove(event));
        jvp.mousewheel((event, delta) => this.mousewheel(event, delta));

        $(window as any).resize(event => this.resize(event));
        $(document as any).keypress(event => this.keypress(event));

        const width = jvp.width() as number, height = jvp.height() as number;

        this.renderer = new ViewportRenderer(model);
        this.renderer.layout(width, height);

        for (let i = 0; i < model.drugs.length; i++) {
            let img = $("<img/>");
            img.one("load", () => {
                this.renderer.drugs[i].img = img[0] as HTMLImageElement;
                this.renderer.layout(width, height);
                this.invalidate();
                //console.log(`img ${i}: ${imgUrls[i][1]} loaded`);
            });
            img.attr("src", imgUrls[model.drugs[i][1]]);
        }

        $(window as any).resize();
    }

    invalidate() {
        //console.log("ViewportControl:invalidate");
        this.renderer.draw(this.viewportCanvas);
    }

    setSelectionStyle(style: StyleBag) {
        this.renderer.setSelectionStyle(style);
    }

    cancel(oncancel: () => void): ViewportControl {
        this.oncancel = oncancel;
        return this;
    }

    select(onselect: (style: NodeStyle) => void): ViewportControl {
        this.onselect = onselect;
        return this;
    }

    multiselect(onmultiselect: () => void): ViewportControl {
        this.onmultiselect = onmultiselect;
        return this;
    }
    // ***************************** Below are private event handlers ***************************** //

    private mousedown(event: JQuery.MouseDownEvent): boolean {
        if (event.offsetX === undefined || event.offsetY === undefined)
            return false;

        this.dragged = false;

        this.cursorX = event.offsetX;
        this.cursorY = event.offsetY;

        this.dragging = true;

        if (event.ctrlKey)
            return false;

        const pos = this.renderer.navigation.toLogical(event.offsetX, event.offsetY);
        const sel = this.renderer.hitTest(pos.x, pos.y);
        let dirty = false;

        if (sel === null) { // clicked on the blank area
            if (this.renderer.unselectAll()) {
                if (this.oncancel !== undefined)
                    this.oncancel();
                dirty = true;
            }
        }
        else if (this.renderer.isInteractionId(sel)) {
            const id = this.renderer.decodeInteractionId(sel);
            this.renderer.interactions[id].reverse = !this.renderer.interactions[id].reverse;
            dirty = true;
        }
        else { // clicked on something
            if (this.renderer.select(sel)) {
                const style = this.renderer.getSelectionStyle();
                if (style === null)
                    return false;

                if (this.onselect !== undefined)
                    this.onselect(style);
                dirty = true;
            }
        }

        if (dirty)
            this.invalidate();

        return false;
    }

    private mouseup(event: JQuery.MouseUpEvent): boolean {
        if (event.offsetX === undefined || event.offsetY === undefined)
            return false;

        this.dragging = false;

        if (!event.ctrlKey)
            return false;

        if (this.dragged)
            return false;

        let dirty = false;

        const pos = this.renderer.navigation.toLogical(event.offsetX, event.offsetY);
        const sel = this.renderer.hitTest(pos.x, pos.y);

        if (sel === null) { // clicked on the blank area
        }
        else { // clicked on something
            if (this.renderer.multiSelect(sel)) {
                if (this.onmultiselect !== undefined)
                    this.onmultiselect();
                dirty = true;
            }
        }

        if (dirty)
            this.invalidate();

        return false;
    }

    private mousemove(event: JQuery.MouseMoveEvent): boolean {
        if (event.offsetX === undefined || event.offsetY === undefined)
            return false;

        if (!this.dragging)
            return false;

        this.dragged = true;

        let dirty = false;

        if (event.shiftKey) { // pan the viewport
            this.renderer.navigation.pan(event.offsetX - this.cursorX, event.offsetY - this.cursorY);
            this.cursorX = event.offsetX;
            this.cursorY = event.offsetY;
            dirty = true;
        }
        else { // move selected items
            const dx = (event.offsetX - this.cursorX) / this.renderer.navigation.scale;
            const dy = (event.offsetY - this.cursorY) / this.renderer.navigation.scale;

            if (this.renderer.shift(dx, dy)) {
                this.cursorX = event.offsetX;
                this.cursorY = event.offsetY;
                dirty = true;
            }
        }

        if (dirty)
            this.invalidate();

        return false;
    }

    private mousewheel(event: JQueryMousewheel.JQueryMousewheelEventObject, delta: number): boolean {
        if (event.offsetX === undefined || event.offsetY === undefined)
            return false;

        this.renderer.navigation.zoom(event.offsetX, event.offsetY, delta);
        this.invalidate();

        return false;
    }

    private resize(event: JQuery.ResizeEvent) {
        const vp = $(this.viewportCanvas);

        const width = vp.width();
        const height = vp.height();

        if (width === undefined || height === undefined)
            return false;

        vp.prop("width", width * window.devicePixelRatio);
        vp.prop("height", height * window.devicePixelRatio);

        this.invalidate();

        return false;
    }

    private keypress(event: JQuery.KeyPressEvent) {
        let dirty = false;

        if (event.which === 32) {
            this.renderer.settings.showLabel = !this.renderer.settings.showLabel;

            for (let i = 0; i < this.renderer.interactions.length; i++)
                this.renderer.interactions[i].reverse = false;

            dirty = true;
        }
        else if (event.key === 'd' || event.key === 'D') {
            this.renderer.settings.showDepiction = !this.renderer.settings.showDepiction;

            dirty = true;
        }

        if (dirty)
            this.invalidate();

        return false;
    }
}