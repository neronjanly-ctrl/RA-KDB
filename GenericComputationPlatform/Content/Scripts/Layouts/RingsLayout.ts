
class RingsLayout {
    static radius(n: number, r: number): number {
        if (n === 0) return 0;
        if (n === 1) return 0.5;
        return r / 2 / Math.sin(Math.PI / n) + 0.5;
    }

    static measure(itemCount: number, itemSize: number, itemDensity: number): number {
        if (itemCount === 0)
            return 0;
        if (itemCount === 1)
            return itemSize / 2;

        let dp: number[] = [];
        for (let i = 0; i <= itemCount; i++)
            dp.push(this.radius(i, itemDensity));

        for (let k = 2; ; k++) {
            //console.log(dp);
            const t: number[] = new Array<number>(itemCount + 1);
            t.fill(Infinity);
            for (let i = k; i <= itemCount; i++) {
                for (let j = 0; j < i; j++) {
                    t[i] = Math.min(t[i], Math.max(dp[j] + itemDensity, this.radius(i - j, itemDensity)));
                }
            }
            if (t[itemCount] >= dp[itemCount])
                break;
            dp = t;
        }
        return dp[itemCount] * itemSize;
    }

    static layout(center: _Point, itemCount: number, itemSize: number, itemDistance: number): _Point[] {
        if (itemCount === 0)
            return [];
        if (itemCount === 1)
            return [center];

        const dp: [number, number][][] = [];
        dp[1] = [];
        for (let i = 0; i <= itemCount; i++)
            dp[1].push([this.radius(i, itemDistance), -1]);

        for (let k = 2; ; k++) {
            dp[k] = new Array<[number, number]>(itemCount + 1);
            dp[k].fill([Infinity, -1]);
            for (let i = k; i <= itemCount; i++) {
                for (let j = 0; j < i; j++) {
                    const v = Math.max(dp[k - 1][j][0] + itemDistance, this.radius(i - j, itemDistance));
                    if (v < dp[k][i][0])
                        dp[k][i] = [v, j];
                }
            }
            if (dp[k][itemCount][0] >= dp[k - 1][itemCount][0])
                break;
        }
        dp.pop();
        //console.log(dp);

        const path: [number, number][] = [];
        for (let i = dp.length - 1, j = itemCount; i > 0; j = dp[i--][j][1])
            path.unshift([dp[i][j][0], j]);
        path.unshift([0, 0]);
        //console.log(path);

        const coords: _Point[] = [];
        for (let i = 1; i < path.length; i++) {
            const n = path[i][1] - path[i - 1][1], radius = (path[i][0] - 0.5) * itemSize;
            for (let j = 0; j < n; j++) {
                const theta = Math.PI * 2 * j / n;
                const x = center.x + Math.sin(theta) * radius;
                const y = center.y + Math.cos(theta) * radius;
                coords.push({ x, y });
            }
        }

        return coords;
    }
}