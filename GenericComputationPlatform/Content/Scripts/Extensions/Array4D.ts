class Array4D {
    static create<T>(length0: number, length1: number, length2: number): T[][][][] {
        const r: T[][][][] = [];
        for (let i = 0; i < length0; i++) {
            r[i] = [];
            for (let j = 0; j < length1; j++) {
                r[i][j] = [];
                for (let k = 0; k < length2; k++)
                    r[i][j][k] = [];
            }
        }
        return r;
    }

    static createMono<T>(length: number): T[][][][] {
        return this.create<T>(length, length, length);
    }

    static fill<T>(length0: number, length1: number, length2: number, length3: number, value: T): T[][][][] {
        const r: T[][][][] = [];
        for (let i = 0; i < length0; i++) {
            r[i] = [];
            for (let j = 0; j < length1; j++) {
                r[i][j] = [];
                for (let k = 0; k < length2; k++) {
                    r[i][j][k] = [];
                    for (let l = 0; l < length3; l++)
                        r[i][j][k][l] = value;
                }
            }
        }
        return r;
    }

    static fillMono<T>(length: number, value: T): T[][][][] {
        return this.fill<T>(length, length, length, length, value);
    }
}