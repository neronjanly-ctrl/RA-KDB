
class SpiralLayout {
    static measure(itemCount: number, itemSize: number, innerRadius: number, itemDensity: number): number {
        const rounds = Math.floor((itemCount - 1) / itemDensity) + 1;
        const branchesPerRound = (rounds > 1 ? itemCount / rounds : itemDensity);

        //console.log(`rounds:${rounds}, branches:${branchesPerRound}`);
        // radius: the distance from the drug node center to the target node center
        const radius = innerRadius + itemSize / 2;

        // layout 1-degree target nodes around a drug node
        const j = itemCount - 1;
        let subRadiusRatio = 2;
        //*/
        const radiusIncrement = 2;
        /*/
        const round = j % rounds + 1;
        const radiusIncrement = (Math.pow(round, 0.8) * 2) / round;
        //*/
        subRadiusRatio = 1 + radiusIncrement * (j % rounds + Math.floor(j / rounds) / branchesPerRound);
        //console.log(`${j}/${round}: ${radiusIncrement}, ${subRadiusRatio}`);
        const realRadius = radius + itemSize * subRadiusRatio;
        return realRadius + itemSize / 2;
    }

    static layout(center: _Point, itemCount: number, itemSize: number, innerRadius: number, itemDensity: number, direction: number = 0): _Point[] {
        const rounds = Math.floor((itemCount - 1) / itemDensity) + 1;
        const branchesPerRound = (rounds > 1 ? itemCount / rounds : itemDensity);

        //console.log(`rounds:${rounds}, branches:${branchesPerRound}`);
        // radius: the distance from the drug node center to the target node center
        const degree = Math.PI * 2 / (rounds > 1 ? itemCount : itemDensity);
        const radius = innerRadius + itemSize / 2;

        // layout 1-degree target nodes around a drug node
        const coords: _Point[] = [];
        for (let j = 0; j < itemCount; j++) {
            const subDegree = direction - (itemCount - 1) * degree / 2 + j * degree;
            let subRadiusRatio = 2;
            //*/
            const radiusIncrement = 2;
            /*/
            const round = j % rounds + 1;
            const radiusIncrement = (Math.pow(round, 0.8) * 2) / round;
            //*/
            subRadiusRatio = 1 + radiusIncrement * (j % rounds + Math.floor(j / rounds) / branchesPerRound);
            //console.log(`${j}/${round}: ${radiusIncrement}, ${subRadiusRatio}`);
            const realRadius = radius + itemSize * subRadiusRatio;
            const x = center.x + Math.sin(subDegree) * realRadius;
            const y = center.y - Math.cos(subDegree) * realRadius;
            coords.push({ x, y });
        }

        return coords;
    }
}