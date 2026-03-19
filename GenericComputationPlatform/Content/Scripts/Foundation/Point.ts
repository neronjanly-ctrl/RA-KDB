
type _Point = {
    x: number;
    y: number;
}

class Point {
    x: number;
    y: number;

    constructor(x?: number, y?: number) {
        this.x = x === undefined ? 0 : x;
        this.y = y === undefined ? 0 : y;
    }

    move(dx: number, dy: number) {
        this.x += dx;
        this.y += dy;
    }

    distance(point: Point): number {
        return Math.sqrt((this.x - point.x) * (this.x - point.x) + (this.y - point.y) * (this.y - point.y));
    }

    clone(): Point {
        return new Point(this.x, this.y);
    }
}
