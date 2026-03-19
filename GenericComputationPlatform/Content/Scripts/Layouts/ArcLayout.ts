
class ArcLayout {
    static measure(itemCount: number, itemSize: number, innerRadius: number, itemDensity: number, fieldAngle: number = Math.PI * 2): number {
        if (itemCount === 0)
            return innerRadius;

        const firstRound = Math.round(itemDensity * fieldAngle / Math.PI / 2);
        const radius = innerRadius + itemSize * 5 / 2;

        // only one arc
        if (itemCount <= firstRound)
            return radius + itemSize / 2;

        // two arcs
        if (itemCount <= firstRound * 2 - 1)
            return radius + itemSize * 2;

        // more arcs
        const rounds = Math.floor((itemCount - 1) / firstRound) + 1;
        return radius + (rounds - 1) * itemSize * 1.5 + itemSize / 2;
    }

    static layout(center: _Point, itemCount: number, itemSize: number, innerRadius: number, itemDensity: number, direction: number = 0, fieldAngle: number = Math.PI * 2): _Point[] {
        let firstRound = Math.round(itemDensity * fieldAngle / Math.PI / 2);
        const radius = innerRadius + itemSize * 5 / 2;
        const coords: _Point[] = [];

        // only one arc
        if (itemCount <= firstRound) {
            const sectorAngle = Math.min(Math.PI * 2 / itemDensity, fieldAngle / itemCount);
            for (let i = 0; i < itemCount; i++) {
                const degree = direction + (1 - itemCount + i * 2) * sectorAngle / 2;
                const x = center.x + Math.sin(degree) * radius;
                const y = center.y - Math.cos(degree) * radius;
                coords.push({ x, y });
            }
            return coords;
        }

        // two arcs
        if (itemCount <= firstRound * 2 - 1) {
            firstRound = Math.floor(itemCount / 2) + 1;
            const sectorAngle = Math.min(Math.PI * 2 / itemDensity, fieldAngle / firstRound);
            for (let i = 0; i < itemCount; i++) {
                const row = Math.floor(i / firstRound), col = i % firstRound;
                const degree = direction + (1 - firstRound + col * 2 + row % 2) * sectorAngle / 2;
                const x = center.x + Math.sin(degree) * (radius + row * itemSize * 1.5);
                const y = center.y - Math.cos(degree) * (radius + row * itemSize * 1.5);
                coords.push({ x, y });
            }
            return coords;
        }

        // more arcs
        const sectorAngle = Math.min(Math.PI * 2 / itemDensity, fieldAngle / firstRound);
        const rounds = Math.floor((itemCount - 1) / firstRound) + 1;
        for (let i = 0; i < itemCount; i++) {
            const row = Math.floor(i / firstRound), col = i % firstRound;
            const degree = direction + (1 - firstRound + col * 2) * sectorAngle / 2 + row % rounds * sectorAngle / rounds;
            const x = center.x + Math.sin(degree) * (radius + row * itemSize * 1.5);
            const y = center.y - Math.cos(degree) * (radius + row * itemSize * 1.5);
            coords.push({ x, y });
        }
        return coords;
    }
}