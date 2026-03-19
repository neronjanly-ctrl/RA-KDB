
class Navigation {
    scale = 1.0;
    offsetX = 0;
    offsetY = 0;

    pan(deltaX: number, deltaY: number): void {
        this.offsetX += deltaX / this.scale;
        this.offsetY += deltaY / this.scale;
    }

    zoom(centerX: number, centerY: number, delta: number): void {
        const scale = this.scale;
        this.scale *= 1 + Math.max(Math.min(delta / 30, 0.6), -0.6);
        this.scale = Math.max(Math.min(this.scale, 10), 0.1);
        this.offsetX += centerX * (1 / this.scale - 1 / scale);
        this.offsetY += centerY * (1 / this.scale - 1 / scale);
    }

    toPhysical(posX: number, posY: number): { x: number, y: number } {
        return { x: (posX + this.offsetX) * this.scale, y: (posY + this.offsetY) * this.scale };
    }

    toLogical(posX: number, posY: number): { x: number, y: number } {
        return { x: posX / this.scale - this.offsetX, y: posY / this.scale - this.offsetY };
    }
}