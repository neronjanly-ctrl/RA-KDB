
class PaletteRenderer {
    hue = 0;
    saturation = 0;
    lightness = 0;

    strip: Size = new Size(200, 40);
    block: Size = new Size(80, 60);
    paletteMargin = new Point(8, 8);
    stripMargin = .25;

    init(width: number, height: number, color: HslColor): void {
        const client = new Size(width - 2 * this.paletteMargin.x, height - 2 * this.paletteMargin.y);
        this.strip = new Size(client.width, client.height / 4);
        this.block = new Size(client.width * .3, client.height / 4);
        this.hue = color.h;
        this.saturation = color.s;
        this.lightness = color.l;
    }

    hitTest(x: number, y: number): { x: number; y: string } | null {
        x -= this.paletteMargin.x;
        y -= this.paletteMargin.y;

        if (x < 0 || y < 0
            || x > this.strip.width || y > this.strip.height * 3) {
            return null;
        }
        if (y < this.strip.height) {
            return { x: x / this.strip.width, y: "h" };
        }

        y -= this.strip.height;
        if (y < 0) {
            return null;
        }
        if (y < this.strip.height) {
            return { x: x / this.strip.width, y: "s" };
        }

        y -= this.strip.height;
        if (y < 0) {
            return null;
        }
        if (y < this.strip.height) {
            return { x: x / this.strip.width, y: "l" };
        }

        return null;
    }

    select(sel: { x: number; y: string }): void {
        switch (sel.y) {
            case "h":
                this.hue = sel.x;
                break;
            case "s":
                this.saturation = sel.x;
                break;
            case "l":
                this.lightness = sel.x;
                break;
        }
    }

    private drawSlider(ctx: CanvasRenderingContext2D, x: number, y: number, value: number): void {
        ctx.beginPath();
        ctx.moveTo(x + value * this.strip.width, y);
        ctx.lineTo(x + value * this.strip.width - this.strip.height * .1, y + this.strip.height * .2);
        ctx.lineTo(x + value * this.strip.width + this.strip.height * .1, y + this.strip.height * .2);
        ctx.closePath();
        ctx.fillStyle = "#000";
        ctx.fill();
    }

    draw(canvas: HTMLCanvasElement): void {
        const ctx = canvas.getContext("2d");
        if (ctx === null)
            return;

        ctx.save();

        ctx.clearRect(0, 0, canvas.width, canvas.height);
        ctx.scale(window.devicePixelRatio, window.devicePixelRatio);

        const width = this.strip.width, height = this.strip.height * (1 - this.stripMargin);

        // draw hue strip
        const x = this.paletteMargin.x;
        let y = this.paletteMargin.y;

        const grd1 = ctx.createLinearGradient(x, 0, x + width, 0);
        grd1.addColorStop(0 / 6, "rgb(255,000,000)");
        grd1.addColorStop(1 / 6, "rgb(255,255,000)");
        grd1.addColorStop(2 / 6, "rgb(000,255,000)");
        grd1.addColorStop(3 / 6, "rgb(000,255,255)");
        grd1.addColorStop(4 / 6, "rgb(000,000,255)");
        grd1.addColorStop(5 / 6, "rgb(255,000,255)");
        grd1.addColorStop(6 / 6, "rgb(255,000,000)");

        ctx.fillStyle = grd1;
        ctx.fillRect(x, y, width, height);

        this.drawSlider(ctx, x, y + height, this.hue);

        // draw saturation strip
        y += this.strip.height;

        let color = RgbColor.fromHsl(this.hue, 1, .5).toHtml();
        const grd2 = ctx.createLinearGradient(x, 0, x + width, 0);
        grd2.addColorStop(0, "rgb(127,127,127)");
        grd2.addColorStop(1, color);

        ctx.fillStyle = grd2;
        ctx.fillRect(x, y, width, height);

        this.drawSlider(ctx, x, y + height, this.saturation);

        // draw value strip
        y += this.strip.height;

        color = RgbColor.fromHsl(this.hue, this.saturation, .5).toHtml();
        const grd3 = ctx.createLinearGradient(x, 0, x + width, 0);
        grd3.addColorStop(0, "rgb(0,0,0)");
        grd3.addColorStop(.5, color);
        grd3.addColorStop(1, "rgb(255,255,255)");

        ctx.fillStyle = grd3;
        ctx.fillRect(x, y, width, height);

        this.drawSlider(ctx, x, y + height, this.lightness);

        // draw result
        y += this.strip.height;

        color = RgbColor.fromHsl(this.hue, this.saturation, this.lightness).toHtml();
        ctx.fillStyle = color;
        ctx.fillRect(x, y, this.block.width, this.block.height);
        //ctx.lineWidth = 1;
        //ctx.strokeStyle = "#000";
        //ctx.strokeRect(x, y, 80, 60);

        ctx.restore();
    }
}