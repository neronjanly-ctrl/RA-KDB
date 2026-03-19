interface JsmeApplet {
    clear(): void;
    setWidth(width: string): void;
    readGenericMolecularInput(smiles: string): void;
    repaint(): void;
    smiles(): string;
}