
class RgbColor {
    r: number;
    g: number;
    b: number;

    constructor(r?: number, g?: number, b?: number) {
        this.r = r === undefined ? 0 : r;
        this.g = g === undefined ? 0 : g;
        this.b = b === undefined ? 0 : b;
    }

    private static hueToRgb(p: number, q: number, t: number): number {
        if (t < 0) t += 1;
        if (t > 1) t -= 1;
        if (t < 1 / 6) return p + (q - p) * 6 * t;
        if (t < 1 / 2) return q;
        if (t < 2 / 3) return p + (q - p) * (2 / 3 - t) * 6;
        return p;
    }

    // h, s, l components are in range [0, 1]
    static fromHsl(h: number, s: number, l: number): RgbColor {
        let [r, g, b] = [l, l, l]; // achromatic

        if (s !== 0) {
            const q = l < 0.5 ? l * (1 + s) : l + s - l * s;
            const p = 2 * l - q;
            r = RgbColor.hueToRgb(p, q, h + 1 / 3);
            g = RgbColor.hueToRgb(p, q, h);
            b = RgbColor.hueToRgb(p, q, h - 1 / 3);
        }

        return new RgbColor(r, g, b);
    }

    // returned rgb components range: [0, 1]
    static fromHtml(color: string): RgbColor {
        let [r, g, b] = [0, 0, 0];

        if (color.length === 4) // #fff
            r = parseInt(color[1] + color[1], 16), g = parseInt(color[2] + color[2], 16), b = parseInt(color[3] + color[3], 16);
        else if (color.length === 7) // #ffffff
            r = parseInt(color.substr(1, 2), 16), g = parseInt(color.substr(3, 2), 16), b = parseInt(color.substr(5, 2), 16);

        return new RgbColor(r / 255, g / 255, b / 255);
    }

    toHsl(): HslColor {
        return HslColor.fromRgb(this.r, this.g, this.b);
    }

    private static toHex(a: number) {
        const res = Math.round(a * 255).toString(16);
        return res.length === 1 ? `0${res}` : res;
    }

    toHtml(): string {
        return `#${RgbColor.toHex(this.r)}${RgbColor.toHex(this.g)}${RgbColor.toHex(this.b)}`;
    }
}