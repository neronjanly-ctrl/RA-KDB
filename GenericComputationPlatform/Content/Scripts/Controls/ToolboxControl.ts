
class ToolboxControl {
    toolboxContainer: HTMLElement;

    private onchange?: (style: StyleBag) => void;
    private paletteControl?: PaletteControl;

    constructor(elements: JQuery<HTMLElement>) {
        if (elements.length === 0)
            throw new Error("Toolbox container is required");

        const tb = elements[0];
        const jtb = $(tb);

        this.toolboxContainer = tb;

        jtb.find("input")
            .keypress(event => this.inputKeypress(event))
            .keyup(event => this.inputKeyup(event));

        jtb.find("div")
            .click(event => this.pickerClick(event));
    }

    setStyle(style: NodeStyle) {
        const jtb = $(this.toolboxContainer);

        jtb.find("div:eq(0)").css("background", style.fillColor.toHtml());
        jtb.find("div:eq(0)").data("hsl", style.fillColor);
        jtb.find("div:eq(0)").data("target", "fillColor");

        jtb.find("div:eq(1)").css("background", style.borderPaint.toHtml());
        jtb.find("div:eq(1)").data("hsl", style.borderPaint);
        jtb.find("div:eq(1)").data("target", "borderPaint");

        jtb.find("div:eq(2)").css("background", style.labelColor.toHtml());
        jtb.find("div:eq(2)").data("hsl", style.labelColor);
        jtb.find("div:eq(2)").data("target", "labelColor");

        jtb.find("input:eq(0)").val(style.size);
        jtb.find("input:eq(0)").data("target", "size");
        jtb.find("input:eq(0)").css("color", "#000");

        jtb.find("input:eq(1)").val(style.borderWidth);
        jtb.find("input:eq(1)").data("target", "borderWidth");
        jtb.find("input:eq(1)").css("color", "#000");

        jtb.find("input:eq(2)").val(style.labelFontSize);
        jtb.find("input:eq(2)").data("target", "labelFontSize");
        jtb.find("input:eq(2)").css("color", "#000");
    }

    show() {
        const jtb = $(this.toolboxContainer);
        jtb.fadeIn();

        if (this.paletteControl !== undefined)
            this.paletteControl.hide();
    }

    hide() {
        const jtb = $(this.toolboxContainer);
        jtb.fadeOut();

        if (this.paletteControl !== undefined)
            this.paletteControl.hide();
    }

    change(onchange: (style: StyleBag) => void): ToolboxControl {
        this.onchange = onchange;
        return this;
    }

    private inputKeypress(event: JQuery.KeyPressEvent): boolean {
        if (event.key === undefined || event.key !== "." && (event.key < "0" || event.key > "9"))
            return false;
        event.stopPropagation();
        return true;
    }

    private inputKeyup(event: JQuery.KeyUpEvent): boolean {
        const numPane = $(event.target as HTMLInputElement);

        if (numPane.length === 0)
            return false;

        const num = parseFloat(numPane.val() as string);
        const max = parseInt(numPane.attr("max") as string);
        const min = parseInt(numPane.attr("min") as string);

        if (isNaN(num) || num < min || num > max) {
            numPane.css("color", "#F00");
            return false;
        }

        numPane.css("color", "#000");

        const style = new StyleBag();
        switch (numPane.data("target")) {
            case "borderWidth":
                style.borderWidth = num;
                break;
            case "labelFontSize":
                style.labelFontSize = num;
                break;
            case "size":
                style.size = num;
                break;
            default:
                break;
        }

        if (this.onchange !== undefined)
            this.onchange(style);

        return false;
    }

    private pickerClick(event: JQuery.ClickEvent) {
        const colorPane = $(event.target as HTMLElement);
        const jtb = $(this.toolboxContainer);

        const outerWidth = jtb.outerWidth();
        if (outerWidth === undefined)
            return;

        const x = jtb.position().left + outerWidth;
        const y = colorPane.position().top + jtb.position().top;

        const curColor = colorPane.data("hsl") as HslColor;

        const pl = new PaletteControl(x, y, curColor)
            .change(color => {
                colorPane.css("background", color.toHtml());

                const style = new StyleBag();
                switch (colorPane.data("target") as string) {
                    case "borderPaint":
                        style.borderPaint = color;
                        break;
                    case "fillColor":
                        style.fillColor = color;
                        break;
                    case "labelColor":
                        style.labelColor = color;
                        break;
                    default:
                        break;
                }

                if (this.onchange !== undefined)
                    this.onchange(style);
            });

        this.paletteControl = pl;

        jtb.after(pl.paletteCanvas);
        pl.show();
    }
}