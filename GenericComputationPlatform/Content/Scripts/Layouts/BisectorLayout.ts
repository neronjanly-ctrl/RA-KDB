
class BisectorLayout {
    static measure(itemCount: number, itemSize: number, rowHeight: number, colWidth: number, spanWidth: number): _Size {
        rowHeight *= itemSize;
        colWidth *= itemSize;

        const rowSize = Math.floor((spanWidth + colWidth - itemSize) / colWidth);
        const rows = Math.floor((itemCount + rowSize - 1) / rowSize);
        const cols = Math.ceil(itemCount / rows);

        return { width: (cols - 1) * colWidth + itemSize, height: (rows - 1) * rowHeight + itemSize };
    }

    static layout(anchor1: _Point, anchor2: _Point, itemCount: number, itemSize: number, rowHeight: number, colWidth: number, spanWidth: number, offset: number = 0): _Point[] {
        rowHeight *= itemSize;
        colWidth *= itemSize;

        const rowSize = Math.floor((spanWidth + colWidth - itemSize) / colWidth);
        const rows = Math.floor((itemCount + rowSize - 1) / rowSize);
        const cols = Math.ceil(itemCount / rows);

        const dx = anchor2.x - anchor1.x, dy = anchor2.y - anchor1.y, l = Math.sqrt(dx * dx + dy * dy), alpha = Math.atan2(dy, dx) - Math.PI / 2;
        const center: _Point = { x: (anchor1.x + anchor2.x) / 2 + offset * dy / l, y: (anchor1.y + anchor2.y) / 2 - offset * dx / l };
        //console.log(`[${anchor1.x},${anchor1.y}], [${anchor2.x},${anchor2.y}]; center ${center.x},${center.y}; alpha ${alpha * 180 / Math.PI};`);

        const coords: _Point[] = [];

        // Layout multiple-degree target nodes in the canvas center
        for (let i = 0; i < itemCount; i++) {
            const row = Math.floor(i / cols), col = i % cols;

            const ox = colWidth * (1 - cols + 2 * col) / 2, oy = rowHeight * (1 - rows + 2 * row) / 2;
            const ol = Math.sqrt(ox * ox + oy * oy), theta = Math.atan2(oy, ox);
            //console.log(`len ${ol}, theta ${theta * 180 / Math.PI}: ${ox},${oy} -> ${ol * Math.cos(alpha + theta)},${ol * Math.sin(alpha - theta)}`);
            const x = center.x + ol * Math.cos(alpha - theta);
            const y = center.y + ol * Math.sin(alpha - theta);

            coords.push({ x, y });
        }

        return coords;
    }
}