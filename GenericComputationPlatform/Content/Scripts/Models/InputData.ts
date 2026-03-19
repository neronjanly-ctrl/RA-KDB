
interface InputData {
    drugs: [string, string][]; // [ligand name, ligand id]
    targets: [string, string][]; // [protein/gene sym, organism sym]
    targetStates: number[];
    targetDrugs: number[][];
    drugTargets: number[][];
    interactions: number[][];
}