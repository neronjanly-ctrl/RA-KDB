
type _Size = {
    width: number;
    height: number;
}

class Size {
    width: number;
    height: number;

    constructor(width?: number, height?: number) {
        this.width = width === undefined ? 0 : width;
        this.height = height === undefined ? 0 : height;
    }

    fit(side: number, fitShort = true): Size {
        if (this.width === 0 || this.height === 0)
            this.width = this.height = side;
        else if (this.width < this.height && fitShort || this.width > this.height && !fitShort) {
            this.height = this.height / this.width * side;
            this.width = side;
        } else {
            this.width = this.width / this.height * side;
            this.height = side;
        }
        return this;
    }

    add(cx: number, cy: number): Size {
        this.width += cx;
        this.height += cy;
        return this;
    }
}