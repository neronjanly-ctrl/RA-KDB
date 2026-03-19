
class HslColor {
    h: number;
    s: number;
    l: number;

    constructor(h?: number, s?: number, l?: number) {
        this.h = h === undefined ? 0 : h;
        this.s = s === undefined ? 0 : s;
        this.l = l === undefined ? 0 : l;
    }

    // r, g, b components are in range [0, 1]
    static fromRgb(r: number, g: number, b: number): HslColor {
        const max = Math.max(r, g, b), min = Math.min(r, g, b);

        let [h, s, l] = [0, 0, (max + min) / 2];

        if (max !== min) {
            const df = max - min, sm = max + min;

            s = l > 0.5 ? df / (2 - sm) : df / sm;

            switch (max) {
                case r: h = (g - b) / df + (g < b ? 6 : 0);
                    break;
                case g: h = (b - r) / df + 2;
                    break;
                case b: h = (r - g) / df + 4;
                    break;
            }

            h /= 6;
        }

        return new HslColor(h, s, l);
    }

    // returned hsl components are in range [0, 1]
    static fromHtml(color: string): HslColor {
        const { r, g, b } = RgbColor.fromHtml(color);

        return HslColor.fromRgb(r, g, b);
    }

    toRgb(): RgbColor {
        return RgbColor.fromHsl(this.h, this.s, this.l);
    }

    toHtml(): string {
        return this.toRgb().toHtml();
    }
}